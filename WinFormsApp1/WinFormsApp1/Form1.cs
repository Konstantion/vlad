using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Stopwatch swTimeSinceStart;
        int frameSinceStart;
        Bitmap bitmap;
        Graphics g;
        Block3 block3;
        public Form1()
        {
            InitializeComponent();
            swTimeSinceStart = new Stopwatch();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            block3 = new Block3(g, pictureBox1.Height, pictureBox1.Width);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            swTimeSinceStart.Restart();
            timer1.Interval = Convert.ToInt32(Math.Round(1000 / numericUpDown1.Value));
            frameSinceStart = 0;
            swTimeSinceStart.Start();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            pictureBox1.Image = bitmap;
            frameSinceStart++;
            double tms = swTimeSinceStart.ElapsedMilliseconds;
            label3.Text = $"time interval {timer1.Interval}\n{tms}, {frameSinceStart} frames ({Math.Round((frameSinceStart * 1000 / tms), 2)}) fps";
            label8.Text = $"LCM {block3.LCM}\nx_center {block3.x_center}\ny_center {block3.y_center}\nx_factor {block3.x_factor}\ny_factor {block3.y_factor}";
            block3.Animate();
        }

        

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            block3.x_factor = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            block3.y_factor = (int)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            block3.x_period = (int)numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            block3.y_period = (int)numericUpDown5.Value;
        }
    }
}
