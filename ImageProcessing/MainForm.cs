using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Bitmap originalImage = null;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                originalImage = new Bitmap(ofd.FileName);
                picOriginal.Image = originalImage;
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                Bitmap copy = new Bitmap(originalImage);
                Processing.ConvertToGray(copy);
                picResult.Image = copy;
            }
        }

        private void btnPicReset_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                picResult.Image = originalImage;
            }
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                Bitmap copy = new Bitmap(originalImage);
                Processing.Blur(copy, Convert.ToInt32(blurLvl.Value));
                picResult.Image = copy;
            }
        }

        private void btnSobel_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                Bitmap copy = new Bitmap(originalImage);
                Bitmap output = new Bitmap(copy.Width, copy.Height);
                Processing.Sobel(copy, output);
                picResult.Image = output;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPEG|*.jpeg|PNG|*.png|GIF|*.gif;";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 0:
                            {
                                picResult.Image.Save(sfd.FileName, ImageFormat.Jpeg);
                                break;
                            }
                        case 1:
                            {
                                picResult.Image.Save(sfd.FileName, ImageFormat.Png);
                                break;
                            }
                        default: 
                            {
                                picResult.Image.Save(sfd.FileName, ImageFormat.Gif);
                                break;
                            }
                    }
                }
            }
        }
    }
}
