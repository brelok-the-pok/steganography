using System;
using System.Drawing;
using System.Windows.Forms;

namespace steganographyLab1
{
    public partial class ResultImageForm : Form
    {
        public ResultImageForm(Bitmap cryptedImg, Bitmap differenceImg, string desktopDirectory)
        {
            InitializeComponent();
            this.cryptedImg.Image = cryptedImg;
            this.differenceImg.Image = differenceImg;
            this.desktopDirectory = desktopDirectory;
        }
        private string desktopDirectory;
        private void SaveCryptedImgButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = desktopDirectory;
            dialog.Filter = "bmp files (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cryptedImg.Image.Save(dialog.FileName);
            }
            else
            {
                return;
            }
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
