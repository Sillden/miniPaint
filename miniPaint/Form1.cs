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
        Graphics graphics;
        Point temppoint;
        Pen myPen;
        public Form1()
        {
            InitializeComponent();
            openFileDialog.Filter = "Grafika BMP|*.bmp|Grafika PNG|*.png|Grafika JPG|*.jpg";
            saveFileDialog.Filter = "Grafika BMP|*.bmp|Grafika PNG|*.png|Grafika JPG|*.jpg";
            myPen = new Pen(Color.Red, 5);
            myPen.EndCap = myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMyImage.Image = Image.FromFile(openFileDialog.FileName);
                graphics = Graphics.FromImage(pictureBoxMyImage.Image); ;
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
                        imageFormat = ImageFormat.Jpeg;
                        break;
                }
                pictureBoxMyImage.Image.Save(saveFileDialog.FileName, imageFormat);
            }
        }

        private void pictureBoxMyImage_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                //graphics.DrawEllipse(new Pen(Color.Red), e.X, e.Y, 20, 20);
                //pictureBoxMyImage.Refresh();

                temppoint = e.Location;
            }
        }

        private void pictureBoxMyImage_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) { 
                graphics.DrawLine(myPen, temppoint, e.Location);
                pictureBoxMyImage.Refresh();
            }
            temppoint = e.Location;
        }

        private void pictureBoxMyImage_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
