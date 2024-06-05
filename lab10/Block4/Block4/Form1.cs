using System;
using System.Drawing;
using System.Windows.Forms;

namespace Block4
{
    public partial class Form1 : Form
    {
        private PictureBox rocketPictureBox;
        private PictureBox firePictureBox;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer fire1Timer; 

        private int rocketSpeed = 2;

        public Form1()
        {
            this.BackColor = Color.LemonChiffon;
            InitializeComponent();
            InitializeRocket();
            InitializeFire();
            InitializeTimer();
            InitializeFire1Timer(); 
        }

        private void InitializeRocket()
        {
            rocketPictureBox = new PictureBox();
            rocketPictureBox.Image = ResizeImage(Properties.Resources.rocket, 0.2f);
            rocketPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            rocketPictureBox.Location = new Point((ClientSize.Width - rocketPictureBox.Width) / 2, ClientSize.Height);
            Controls.Add(rocketPictureBox);
        }

        private void InitializeFire()
        {
            firePictureBox = new PictureBox();
            firePictureBox.Image = ResizeImage(Properties.Resources.fire2, 0.5f);
            firePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            firePictureBox.Location = new Point(rocketPictureBox.Location.X + (rocketPictureBox.Width - firePictureBox.Width) / 2, rocketPictureBox.Location.Y + rocketPictureBox.Height);
            Controls.Add(firePictureBox);
            firePictureBox.SendToBack();
        }

        private void InitializeTimer()
        {
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            rocketPictureBox.Location = new Point(rocketPictureBox.Location.X, rocketPictureBox.Location.Y - rocketSpeed);
            firePictureBox.Location = new Point(rocketPictureBox.Location.X + (rocketPictureBox.Width - firePictureBox.Width) / 2, rocketPictureBox.Location.Y + rocketPictureBox.Height);

            if (rocketPictureBox.Location.Y + rocketPictureBox.Height < 0)
            {
                animationTimer.Stop();
                MessageBox.Show("Ракета злетіла!");
            }
        }

        private Image ResizeImage(Image image, float scale)
        {
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);
            return new Bitmap(image, new Size(newWidth, newHeight));
        }

        private void ChangeFireImage(Image newFireImage)
        {
            
            Controls.Remove(firePictureBox);
            firePictureBox.Dispose();

            firePictureBox = new PictureBox();
            firePictureBox.Image = ResizeImage(newFireImage, 0.5f);
            firePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            firePictureBox.Location = new Point(rocketPictureBox.Location.X + (rocketPictureBox.Width - firePictureBox.Width) / 2, rocketPictureBox.Location.Y + rocketPictureBox.Height);
            Controls.Add(firePictureBox);
            firePictureBox.SendToBack();
        }

        private void Fire1Timer_Tick(object sender, EventArgs e)
        {
            ChangeFireImage(Properties.Resources.fire1);
        }

        private void InitializeFire1Timer()
        {
            fire1Timer = new System.Windows.Forms.Timer();
            fire1Timer.Interval = 2500; 
            fire1Timer.Tick += Fire1Timer_Tick;
            fire1Timer.Start();
        }
    }
}
