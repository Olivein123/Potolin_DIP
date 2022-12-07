namespace Potolin_DIP
{
    public partial class Form1 : Form
    {
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
             processed = new Bitmap(loaded.Width   , loaded.Height);
        
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}