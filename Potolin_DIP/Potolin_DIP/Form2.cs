using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potolin_DIP
{
    public partial class Form2 : Form
    {
        Bitmap imageB, imageA, colorgreen, processed;
        OpenFileDialog op = new OpenFileDialog();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            op.ShowDialog();
            imageB = new Bitmap(op.FileName);
            pictureBox1.Image = imageB;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            op.ShowDialog();
            imageA = new Bitmap(op.FileName);
            pictureBox2.Image = imageA;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(imageB.Width, imageB.Height);
            Color green = Color.FromArgb(0, 0, 255);
            int greyGreen = (green.R + green.G + green.B) / 3;
            int threshold = 5;

            for (int x = 0; x < imageB.Width; x++)
            {
                for (int y = 0; y < imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backPixel = imageA.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractVal = Math.Abs(grey - greyGreen);

                    if (subtractVal < threshold)
                    {
                        processed.SetPixel(x, y, backPixel);
                    }
                    else
                    {
                        processed.SetPixel(x, y, pixel);
                    }
                }
            }
            pictureBox3.Image = processed;
        }
    }
}
