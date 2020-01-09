using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Accord.Imaging;

namespace steganographyLab1
{
    public partial class MainForm : Form
    {
        public MainForm(string desktopDirectory)
        {
            InitializeComponent();
            this.desktopDirectory = desktopDirectory;
            MethodBox.SelectedIndex = 2;
            DecodMethodBox.SelectedIndex = 0;
            attackBox.SelectedIndex = 0;
        }


        private string desktopDirectory;//Путь к рабочему столу

        
        private void OrigBtn_Click_1(object sender, EventArgs e)//Слушатель на клик кнопки выбора изображения-контейнера
        {
            origImg.Image = Service.GetImageFromUser(desktopDirectory);
            string info = string.Format("Высота = {0}px\nШирина = {1}px", origImg.Image.Height, origImg.Image.Width);
            OrigImgInfo.Text = info;
            OrigImgInfo.Visible = true;
        }
        private void WaterBtn_Click(object sender, EventArgs e)//Слушатель на клик кнопки выбора изобрадения-водного знака
        {
            waterMark.Image = Service.GetImageFromUser(desktopDirectory);
            string info = string.Format("Высота = {0}px\nШирина = {1}px", waterMark.Image.Height, waterMark.Image.Width);
            WatermarkImgInfo.Text = info;
            WatermarkImgInfo.Visible = true;
        }
        private void CryptBtn_Click(object sender, EventArgs e)//Слушатель на клик кнопки ввода водного знака в изображение-контейнер
        {
            Bitmap imgSrc = (Bitmap)origImg.Image.Clone();//Изображение контейнер
            Bitmap markScr = (Bitmap)waterMark.Image.Clone();//Изображение водный-знак
            Bitmap resImg;

            if (MethodBox.SelectedIndex == 0)
            {
                if (imgSrc.Height < markScr.Height || imgSrc.Width < markScr.Width)
                {
                    MessageBox.Show("Размер стегосообщения слишом велик, оно не может быть записано в контейнер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resImg = Crypting.LSB(imgSrc, markScr);
            }
            else if (MethodBox.SelectedIndex == 1)
            {
                if (imgSrc.Height - 4 <= markScr.Height || imgSrc.Width - 4 <= markScr.Width)
                {
                    MessageBox.Show("Размер стегосообщения слишом велик, оно не может быть записано в контейнер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resImg = Crypting.KJB(imgSrc, markScr);
            }
            else if (MethodBox.SelectedIndex == 2)
            {
                resImg = Crypting.RobustImageWatermarkingCrypt(imgSrc, markScr, (int)alphaInput.Value);
            }
            else
            {
                MessageBox.Show("Неизвестный метод кодировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap differenceImg = Service.imgDiff(imgSrc, resImg);


            ResultImageForm result = new ResultImageForm(resImg, differenceImg, desktopDirectory);
            result.Show();
        }
        private void DecodeButton_Click(object sender, EventArgs e)//Расшифровка изображения
        {
            Bitmap img = Service.GetImageFromUser(desktopDirectory);
            cryptedImg.Image = img;
            if (DecodMethodBox.SelectedIndex == 0) 
                decryptedImg.Image = DeCrypting.decryptImgLSB(img);
            else if (DecodMethodBox.SelectedIndex == 1) 
                decryptedImg.Image = DeCrypting.decryptImgKJB(img);
            else if (DecodMethodBox.SelectedIndex == 2) 
                decryptedImg.Image = DeCrypting.RobustImageWatermarkingDeCrypt(img, (int)alphaDecode.Value);
            else 
                MessageBox.Show("Неизвестная кодировка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void SaveWaterMark_Click(object sender, EventArgs e)//Сохранение ЦВЗ полученного из зашифрованного изображения
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = desktopDirectory;
            //dialog.InitialDirectory = desktopDirectory;
            dialog.Filter = "bmp files (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                decryptedImg.Image.Save(dialog.FileName);
            }
            else
            {
                return;
            }
        }
        private void WatemarksDiff_Click(object sender, EventArgs e)//Нахождение разницы между исходным водяным знаком и его версией полученной из зашифрованного изображения
        {

        }
        private void attackBtn_Click(object sender, EventArgs e)//Совершение атаки на изображение
        {
            System.Drawing.Image img = Service.GetImageFromUser(desktopDirectory);
            int index = attackBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    img = Attacks.brightnesAttack((Bitmap)img, (int)attackPercent.Value);
                    break;
                case 1:
                    img = Attacks.blurAttack((Bitmap)img, (int)attackPercent.Value);
                    break;
                case 2:
                    img = Attacks.SharpenAttack((Bitmap)img, (int)attackPercent.Value);
                    break;
                case 3:
                    img = Attacks.JittersAttack((Bitmap)img, (int)attackPercent.Value);
                    break;
                case 4:
                    img = Service.RotateImg((Bitmap)img, (int)attackPercent.Value);
                    break;
                case 5:
                    img = Attacks.CropAttack((Bitmap)img, (int)attackPercent.Value);
                    break;
                default:
                    MessageBox.Show("Неизвестная атака", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            attacedImg.Image = img;
        }
        private void saveAttackedImgBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            //dialog.InitialDirectory = desktopDirectory;
            dialog.InitialDirectory = desktopDirectory;
            dialog.Filter = "bmp files (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                attacedImg.Image.Save(dialog.FileName);
            }
            else
            {
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            origImageInMetrick.Image = Service.GetImageFromUser(desktopDirectory);

        }
        private void CheckAllMetricksBtn_Click(object sender, EventArgs e)
        {
            Bitmap srcimg = new Bitmap(origImageInMetrick.Image);
            Bitmap srcimgMarked = new Bitmap(markedImg.Image);

            double BER = Metrics.BER(srcimg, srcimgMarked);

            double RMS = Metrics.RMS(srcimg, srcimgMarked);

            double PSNR = Metrics.PSNR(srcimg, srcimgMarked);

            double SSIM = Metrics.SSIM(srcimg, srcimgMarked);

            double NCC = Metrics.NCC(srcimg, srcimgMarked);

            var wr = new System.IO.StreamWriter(@"метрики.txt", true);
            wr.Write("RMS = "+RMS.ToString("F5"));
            wr.Write("\t");
            wr.Write("PSNR = " + PSNR.ToString("F5"));
            wr.Write("\t");
            wr.Write("BER = " + BER.ToString("F5"));
            wr.Write("\t");
            wr.Write("SSIM = " + SSIM.ToString("F5"));
            wr.Write("\t");
            wr.WriteLine("NCC = " + NCC.ToString("F5"));
            wr.Close();

            metricksData.Text = $"RMS = {RMS.ToString("F5")}\nPSNR = {PSNR.ToString("F5")}\nBER = {BER.ToString("F5")}\nSSIM = {SSIM.ToString("F5")}\nNCC = {NCC.ToString("F5")}";
            metricksData.Visible = true;
        }
        private void EncryptedImgBtn_Click(object sender, EventArgs e)
        {
            markedImg.Image = Service.GetImageFromUser(desktopDirectory);
        }
    }
}