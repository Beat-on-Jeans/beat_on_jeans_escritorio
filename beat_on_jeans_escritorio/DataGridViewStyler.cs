using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace beat_on_jeans_escritorio
{
    public static class DataGridViewStyler
    {
        public static void RedondearBordes(DataGridView dgv, int radio)
        {
            if (dgv == null || dgv.Width == 0 || dgv.Height == 0) return;

            // 🔹 Elimina el borde negro
            dgv.BorderStyle = BorderStyle.None;

            // 🔹 Redondea el borde
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(dgv.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(dgv.Width - radio, dgv.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, dgv.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();

            dgv.Region = new Region(path);
        }
    }
}
