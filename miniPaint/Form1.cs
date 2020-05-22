using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog.Filter = "Grafika BMP|*.bmp|Grafika PNG|*.png|Grafika JPG|*.jpg";
            saveFileDialog.Filter = "Grafika BMP|*.bmp|Grafika PNG|*.png|Grafika JPG|*.jpg";
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMyImage.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName);
                ImageFormat imageFormat = ImageFormat.Bmp; ;
                switch (extension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".jpg":
                        imageFormat = ImageFormat.Jpg;
                        break;
                }
                pictureBoxMyImage.Image.Save(saveFileDialog.FileName, imageFormat);
            }
        }
    }
}
