using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenFuck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Remove this dialogs if you want
            var git = MessageBox.Show("This project was made by Londiuh. The project is for educational purposes only. Do you want to open the original repository?", "Credits", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (git == DialogResult.Yes) 
            {
                Process.Start("https://github.com/Londiuh/ScreenFuck");
            }
            var alert = MessageBox.Show("ScreenFuck is going to start! Your screen will be a mess and your PC can freeze, please only execute this program if you know what are you doing and you know how to stop it!", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (alert == DialogResult.OK) 
            {
                timer1.Enabled = true;
                timer1.Start();
                timer2.Enabled = true;
                timer2.Start();
            }
            else
            {
                Process.Start("cmd", "/C taskkill /IM ScreenFuck.exe /F");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Not  today", "Wut?", MessageBoxButtons.OK);
            e.Cancel = true;
        }
        public static Cursor CreateCursor(Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            return new Cursor(bm.GetHicon()); //get cursor icon
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Random random = new Random();//random class
            int num = random.Next(0, 150);
            int num1 = random.Next(0, 150);
            int num2 = random.Next(0, 150);
            int num3 = random.Next(0, 150);
            //random numbers
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(num, num3, num1, num2, bmp.Size);
            g.CopyFromScreen(num3, num2, num, num1, bmp.Size);
            //get screenshot
            int width = random.Next(500, 1500);
            int height = random.Next(250, 800);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Color p = bmp.GetPixel(x, y);


                    int a = p.A;
                    int r = p.R;
                    int gr = p.G;
                    int b = p.B;


                    r = 255 - r;
                    gr = 255 - gr;
                    b = 255 - b;


                    bmp.SetPixel(x, y, Color.FromArgb(a, r, gr, b));

                }
                pictureBox2.Location = Cursor.Position;
                pictureBox1.Image = bmp;


            }
            //change every pixel until all the area becomes inverted and then put the screenshot on screen
            this.Cursor = CreateCursor((Bitmap)imageList1.Images[0], new Size(32, 32));//set cursor to error icon from imagelist
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Disk C: error 0x982l", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
