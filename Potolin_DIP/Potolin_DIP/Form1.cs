using System.Drawing.Imaging;

namespace Potolin_DIP
{
    public partial class Form1 : Form
    {
        //PART 1 DIP STARTS HERE

        Bitmap loaded, processed;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        { 
             processed = new Bitmap(loaded.Width, loaded.Height);
        
             for(int x = 0; x < loaded.Width; x++)
            {
                for(int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    Color greyscale = Color.FromArgb(grey, grey, grey);
                    processed.SetPixel(x,y, greyscale);
                }
            }
            pictureBox2.Image = processed;
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color sample;
            Color gray;
            Byte graydata;
            var a = new Bitmap(loaded.Width, loaded.Height);
            //Grayscale Convertion;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }
            }

            //histogram 1d data;
            int[] histdata = new int[256]; // array from 0 to 255
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    histdata[sample.R]++; // can be any color property r,g or b
                }
            }

            // Bitmap Graph Generation
            // Setting empty Bitmap with background color
            var b = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    b.SetPixel(x, y, Color.White);
                }
            }
            // plotting points based from histdata
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, b.Height - 1); y++)
                {
                    b.SetPixel(x, (b.Height - 1) - y, Color.Black);
                }
            }

            pictureBox2.Image = b;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;

            for (int y = 0; y < loaded.Height; y++)
            {
                for (int x = 0; x < loaded.Width; x++)
                {
                    //get pixel value
                    pixel = loaded.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = pixel.A;
                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    processed.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox2.Image = processed;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "JPG(*.JPG)| *.JPG";

            if(sf.ShowDialog() == DialogResult.OK)
            {
                processed.Save(sf.FileName);
            }
            
        }

        //PART 1 DIP ENDS HERE

        //PART 2 DIP STARTS HERE


        //PART 2 DIP ENDS HERE
    }
}