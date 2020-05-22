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
            myPen = new Pen(buttonColor.BackColor, (float)numericUpDownWidth.Value);
            myPen.EndCap = myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            nowyToolStripMenuItem_Click(null, null);
        }
        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxMyImage.Image = new Bitmap(800,600);
            graphics = Graphics.FromImage(pictureBoxMyImage.Image);
            graphics.Clear(Color.White);
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMyImage.Image = Image.FromFile(openFileDialog.FileName);
                graphics = Graphics.FromImage(pictureBoxMyImage.Image); 
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
                temppoint = e.Location;
            }
        }

        private void pictureBoxMyImage_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                if (radioButtonCurve.Checked)
                {
                    graphics.DrawLine(myPen, temppoint, e.Location);
                    pictureBoxMyImage.Refresh();
                    temppoint = e.Location;
                }
            }
        }

        private void pictureBoxMyImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (radioButtonCurve.Checked)
                {
                    graphics.DrawLine(myPen, temppoint, e.Location);
                }
                else if (radioButtonLine.Checked)
                {
                    graphics.DrawLine(myPen, temppoint, e.Location);
                }
                else if (radioButtonRectangle.Checked)
                {
                    graphics.DrawRectangle(myPen,
                        Math.Min(temppoint.X, e.X),
                        Math.Min(temppoint.Y, e.Y),
                        Math.Abs(temppoint.X - e.X),
                        Math.Abs(temppoint.Y - e.Y));
                }
                else if (radioButtonEllipse.Checked)
                {
                    graphics.DrawEllipse(myPen,
                        Math.Min(temppoint.X, e.X),
                        Math.Min(temppoint.Y, e.Y),
                        Math.Abs(temppoint.X - e.X),
                        Math.Abs(temppoint.Y - e.Y));
                }
                pictureBoxMyImage.Refresh();
            }
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            myPen.Width = (float)numericUpDownWidth.Value;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = colorDialog.Color;
                myPen.Color = colorDialog.Color;
            }
        }

    }
}
