using Accord.Imaging.Filters;
using Accord.Math.Wavelets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace steganographyLab1
{
    public partial class Form3 : Form
    {
        public int count = 0;
        public Form3()
        {
            InitializeComponent();
            img.Image = new Bitmap(@"C:\Users\Admin\Desktop\Lenna.bmp");
            img2.Image = new Bitmap(@"C:\Users\Admin\Desktop\blackMarkVSTU.bmp");
            label1.Text = count.ToString();
        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap orig = new Bitmap(img.Image);
            Bitmap mark = new Bitmap(img2.Image);
            Bitmap marked = new Bitmap(img2.Image);
            Bitmap markOut = new Bitmap(img2.Image);

            List<int> alpha = new List<int>();
            alpha.Add(1);
            alpha.Add(2);
            alpha.Add(5);
            alpha.Add(10);
            alpha.Add(20);
            alpha.Add(30);
            alpha.Add(40);
            alpha.Add(50);
            alpha.Add(60);
            alpha.Add(70);
            alpha.Add(80);
            alpha.Add(90);
            alpha.Add(100);

            

            List<int> percent = new List<int>();
            percent.Add(10);
            percent.Add(30);
            percent.Add(50);

            foreach (int j in percent)//Яркость  
            {
                foreach (int i in alpha)
                {
                    //Криптим
                    marked = Crypting.RobustImageWatermarkingCrypt(orig, mark, i);
                    //marked.Save($"C:\\Users\\Admin\\Desktop\\Arnold5\\{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\Stats5\\orig{j}.txt", orig, marked);

                    //Декриптим
                    markOut = DeCrypting.RobustImageWatermarkingDeCrypt(marked, i);
                    //markOut.Save($"C:\\Users\\Admin\\Desktop\\markArnold5\\{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\Stats5\\mark{j}.txt", mark, markOut);

                    ////Атакуем поворотом
                    //Bitmap attacked = Service.RotateImg(marked, j);
                    //attacked.Save($"C:\\Users\\Admin\\Desktop\\Arnold5Rot\\{j}\\{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsRot5\\attacked{j}.txt", orig, attacked);

                    ////Декриптим атакованое поворотом
                    //markOut = DeCrypting.RobustImageWatermarkingDeCrypt(attacked, i);
                    //markOut.Save($"C:\\Users\\Admin\\Desktop\\markArnold5Rot\\{j}\\mark{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsRot5\\attackedMark{j}.txt", mark, markOut);


                    //Атакуем вырезкой
                    Bitmap attacked = Attacks.CropAttack(marked, j);
                    System.IO.Directory.CreateDirectory($"C:\\Users\\Admin\\Desktop\\Arnold5Cut\\{j}");

                    attacked.Save($"C:\\Users\\Admin\\Desktop\\Arnold5Cut\\{j}\\{i}.bmp");
                    WriteStats($"C:\\Users\\Admin\\Desktop\\StatsCut5\\attacked{j}.txt", orig, attacked);


                    //Декриптим атакованое вырезкой
                    markOut = DeCrypting.RobustImageWatermarkingDeCrypt(attacked, i);
                    System.IO.Directory.CreateDirectory($"C:\\Users\\Admin\\Desktop\\Arnold5Cut\\{j}");
                    
                    markOut.Save($"C:\\Users\\Admin\\Desktop\\markArnold5Cut\\{j}\\mark{i}.bmp");
                    WriteStats($"C:\\Users\\Admin\\Desktop\\StatsCut5\\attackedMark{j}.txt", mark, markOut);


                    ////Атакуем яркостью
                    //Bitmap attacked = Attacks.brightnesAttack(marked, j);
                    //attacked.Save($"C:\\Users\\Admin\\Desktop\\Arnold5Bright\\{j}\\{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsBright5\\attacked{j}.txt", orig, attacked);

                    ////Декриптим атакованое яркостью
                    //markOut = DeCrypting.RobustImageWatermarkingDeCrypt(attacked, i);
                    //markOut.Save($"C:\\Users\\Admin\\Desktop\\markArnold5Bright\\{j}\\mark{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsBright5\\attackedMark{j}.txt", mark, markOut);




                    ////Атакуем размытием
                    //attacked = Attacks.blurAttack(marked, j);
                    //attacked.Save($"C:\\Users\\Admin\\Desktop\\Arnold5Blur\\{j}\\{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsBlur5\\attacked{j}.txt", orig, attacked);

                    ////Декриптим атакованое размытием
                    //markOut = DeCrypting.RobustImageWatermarkingDeCrypt(attacked, i);
                    //markOut.Save($"C:\\Users\\Admin\\Desktop\\markArnold5Blur\\{j}\\mark{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsBlur5\\attackedMark{j}.txt", mark, markOut);




                    //Атакуем Дрожанием
                    //attacked = Attacks.JittersAttack(marked, j);
                    //attacked.Save($"C:\\Users\\Admin\\Desktop\\Arnold5Jitters\\{j}\\{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsJitters5\\attacked{j}.txt", orig, attacked);

                    ////Декриптим атакованое Дрожанием
                    //markOut = DeCrypting.RobustImageWatermarkingDeCrypt(attacked, i);
                    //markOut.Save($"C:\\Users\\Admin\\Desktop\\markArnold5Jitters\\{j}\\mark{i}.bmp");
                    //WriteStats($"C:\\Users\\Admin\\Desktop\\StatsJitters5\\attackedMark{j}.txt", mark, markOut);
                }
                
            }
        }

        private void match_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(img.Image);

            

            img2.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void WriteStats(string filename, Bitmap img1, Bitmap img2)
        {
            var markwr = new System.IO.StreamWriter(filename, true);

            double BER = Metrics.BER(img1, img2);
            double RMS = Metrics.RMS(img1, img2);
            double PSNR = Metrics.PSNR(img1, img2);
            double SSIM = Metrics.SSIM(img1, img2);
            double NCC = Metrics.NCC(img1, img2);

            markwr.Write(RMS.ToString("F5"));
            markwr.Write("\t");
            markwr.Write(PSNR.ToString("F5"));
            markwr.Write("\t");
            markwr.Write(BER.ToString("F5"));
            markwr.Write("\t");
            markwr.Write(SSIM.ToString("F5"));
            markwr.Write("\t");
            markwr.WriteLine(NCC.ToString("F5"));

            markwr.Close();
        }
    }
}
