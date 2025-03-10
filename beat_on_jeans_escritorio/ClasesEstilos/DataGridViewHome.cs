using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class DataGridViewHome
{
    // Método para aplicar el diseño al DataGridView
    public static void ApplyDesign(DataGridView grid)
    {
        // Establecer fondo blanco
        grid.BackgroundColor = Color.White;

        // Quitar el borde por defecto (si es necesario)
        grid.BorderStyle = BorderStyle.None;

        // Configurar estilo de celdas
        grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        grid.GridColor = Color.Orange;  // Establecer el color del borde del grid

        // Dibujar bordes redondeados
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        grid.RowHeadersDefaultCellStyle.BackColor = Color.White;
        grid.DefaultCellStyle.BackColor = Color.White;

        // Configuración opcional para las celdas si quieres bordes más suaves
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 243, 226); // Fondo cuando se selecciona una celda
        grid.DefaultCellStyle.SelectionForeColor = Color.Black; // Color de la fuente de la celda seleccionada

        // Asegurarte de que el borde del control DataGridView sea de color naranja
        grid.Paint += (sender, e) =>
        {
            // Borde redondeado (círculo) alrededor del DataGridView
            using (Pen pen = new Pen(Color.Orange, 2)) // Borde de 2 píxeles de color naranja
            {
                // Dibujar el borde redondeado
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int cornerRadius = 20; // Radio de las esquinas redondeadas
                Rectangle rect = new Rectangle(0, 0, grid.Width - 1, grid.Height - 1);
                // Usar un path para dibujar bordes redondeados
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90); // Esquina superior izquierda
                    path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90); // Esquina superior derecha
                    path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Esquina inferior derecha
                    path.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Esquina inferior izquierda
                    path.CloseFigure();
                    e.Graphics.DrawPath(pen, path);
                }
            }
        };
    }
}
