using System;
using System.Drawing;
using System.Windows.Forms;

namespace Block1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(this.OnPaint);
            this.BackColor = Color.LemonChiffon;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawParallelepiped(g, Pens.Black, 50, 50, 100, 100, 20);

            g.FillEllipse(Brushes.DarkRed, this.ClientSize.Width - 150, 50, 100, 100);

            Point[] trianglePoints = { new Point(50, this.ClientSize.Height - 50), new Point(150, this.ClientSize.Height - 50), new Point(50, this.ClientSize.Height - 150) };
            g.FillPolygon(Brushes.OliveDrab, trianglePoints);

            g.FillEllipse(Brushes.Indigo, this.ClientSize.Width - 150, this.ClientSize.Height - 100, 100, 50);
        }

        private void DrawParallelepiped(Graphics g, Pen pen, int x, int y, int width, int height, int depth)
        {
            Point[] frontFace = {
                new Point(x, y),
                new Point(x + width, y),
                new Point(x + width, y + height),
                new Point(x, y + height)
            };
            g.DrawPolygon(pen, frontFace);

            Point[] backFace = {
                new Point(x + depth, y - depth),
                new Point(x + width + depth, y - depth),
                new Point(x + width + depth, y + height - depth),
                new Point(x + depth, y + height - depth)
            };
            g.DrawPolygon(pen, backFace);

            g.DrawLine(pen, x, y, x + depth, y - depth);
            g.DrawLine(pen, x + width, y, x + width + depth, y - depth);
            g.DrawLine(pen, x, y + height, x + depth, y + height - depth);
            g.DrawLine(pen, x + width, y + height, x + width + depth, y + height - depth);
        }
    }
}
