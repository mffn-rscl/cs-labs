using System;
using System.Drawing;
using System.Windows.Forms;

namespace Block3
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private double angle1; 
        private double angle2; 
        private const int circleRadius = 50; 
        private const int centerY = 300;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Rotating Circles";
            this.Size = new Size(800, 600);
            this.BackColor = Color.LemonChiffon;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            angle1 += 0.05; 
            if (angle1 >= 2 * Math.PI)
            {
                angle1 -= 2 * Math.PI;
            }

            angle2 -= 0.05; 
            if (angle2 <= 0)
            {
                angle2 += 2 * Math.PI;
            }

            this.Invalidate(); 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int centerX1 = (int)(this.ClientSize.Width / 4.0);
            int centerX2 = (int)(this.ClientSize.Width * 3 / 4.0);

            float x1 = centerX1 + (float)Math.Cos(angle1) * circleRadius;
            g.DrawEllipse(Pens.Black, x1 - circleRadius, centerY - circleRadius, circleRadius * 2, circleRadius * 2);

            float x2 = centerX2 + (float)Math.Cos(angle2) * circleRadius;
            g.DrawEllipse(Pens.Black, x2 - circleRadius, centerY - circleRadius, circleRadius * 2, circleRadius * 2);
        }
    }
}
