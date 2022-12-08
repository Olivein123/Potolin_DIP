namespace Potolin_DIP2
{
    public partial class Form1 : Form
    {
        Bitmap imageB, imageA, colorgreen, processed;
        OpenFileDialog op = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            op.ShowDialog();
            imageB = new Bitmap(op.FileName);
            pictureBox1.Image = imageB;
        }

        private void loadBackgroundBtn_Click(object sender, EventArgs e)
        {
            op.ShowDialog();
            imageA = new Bitmap(op.FileName);
            pictureBox2.Image = imageA;
        }

        private void subtractButton_Click(object sender, EventArgs e)
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