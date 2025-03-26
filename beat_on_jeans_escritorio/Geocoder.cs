using GMap.NET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

public static class Geocoder
{
    private static readonly Dictionary<string, PointLatLng> _cache = new Dictionary<string, PointLatLng>();
    private static readonly object _lock = new object();
    private static readonly TimeSpan _delay = TimeSpan.FromMilliseconds(1000); // 1 segundo entre peticiones
    private static DateTime _lastRequestTime = DateTime.MinValue;

    public static PointLatLng GetCoordinates(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            return PointLatLng.Empty;

        string normalizedAddress = NormalizeAddress(address);

        // Verificar caché primero
        lock (_lock)
        {
            if (_cache.TryGetValue(normalizedAddress, out PointLatLng cachedCoords))
            {
                return cachedCoords;
            }
        }

        // Intentar con diferentes formatos
        var formats = new List<string>
        {
            normalizedAddress,
            $"{normalizedAddress}, Barcelona, Spain",
            $"{RemoveNumber(normalizedAddress)}, Barcelona, Spain",
            $"{GetStreetName(normalizedAddress)}, Barcelona, Spain"
        };

        foreach (var format in formats)
        {
            var coords = TryGeocode(format);
            if (!coords.IsEmpty)
            {
                lock (_lock)
                {
                    _cache[normalizedAddress] = coords;
                }
                return coords;
            }
        }

        return PointLatLng.Empty;
    }

    private static PointLatLng TryGeocode(string address)
    {
        try
        {
            // Respetar el límite de peticiones
            var timeSinceLast = DateTime.Now - _lastRequestTime;
            if (timeSinceLast < _delay)
            {
                Thread.Sleep(_delay - timeSinceLast);
            }

            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("User-Agent", "BeatOnJeansApp");
                string url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}&addressdetails=1&limit=1";
                string json = webClient.DownloadString(url);

                _lastRequestTime = DateTime.Now;

                var results = JsonConvert.DeserializeObject<JArray>(json);
                if (results != null && results.Count > 0)
                {
                    var firstResult = results[0];
                    double lat = firstResult["lat"].Value<double>();
                    double lon = firstResult["lon"].Value<double>();

                    return new PointLatLng(lat, lon);
                }
            }
        }
        catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.Forbidden)
        {
            Console.WriteLine("Error 403: Demasiadas solicitudes. Esperando...");
            Thread.Sleep(5000); // Esperar 5 segundos si nos bloquean
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al geocodificar: {ex.Message}");
        }

        return PointLatLng.Empty;
    }

    private static string NormalizeAddress(string address)
    {
        return Regex.Replace(address.Trim(), @"\s+", " ")
                   .Replace(", ", ",")
                   .Replace(" ,", ",")
                   .Replace(",,", ",");
    }

    private static string RemoveNumber(string address)
    {
        var match = Regex.Match(address, @"^(.*?),\s*\d+");
        return match.Success ? match.Groups[1].Value : address;
    }

    private static string GetStreetName(string address)
    {
        var parts = address.Split(',');
        return parts.Length > 1 ? parts[0].Trim() : address;
    }

    public static void ClearCache()
    {
        lock (_lock)
        {
            _cache.Clear();
        }
    }
}