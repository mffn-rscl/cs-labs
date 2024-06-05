using System;
using System.Drawing;
using System.Windows.Forms;

namespace Block2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Cholovichok";
            this.Size = new Size(800, 600);
            this.BackColor = Color.LemonChiffon;
            this.Paint += new PaintEventHandler(this.OnPaint);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawEllipse(Pens.Black, 350, 100, 100, 100);

            g.DrawLine(Pens.Black, 400, 200, 400, 400);

            g.DrawLine(Pens.Black, 400, 250, 300, 200);
            g.DrawLine(Pens.Black, 400, 250, 500, 200);

            g.DrawLine(Pens.Black, 400, 400, 350, 500);
            g.DrawLine(Pens.Black, 400, 400, 450, 500);
        }
    }
}
