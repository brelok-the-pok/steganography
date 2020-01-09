using Accord.Imaging;
using Accord.Math;
using Accord.Math.Decompositions;
using Accord.Math.Wavelets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace steganographyLab1
{
    
    class DeCrypting
    {
        private static double eps = 0.05;
        public static Bitmap decryptImgLSB(Bitmap cryptedImg)//Расшифровка изображения зашифрованного методом LSB
        {
            Bitmap img = new Bitmap(cryptedImg.Width, cryptedImg.Height);

            for (int x = 0; x < cryptedImg.Width; x++)
            {
                for (int y = 0; y < cryptedImg.Height; y++)
                {
                    Color curPixel = cryptedImg.GetPixel(x, y);
                    Color newPixel = Service.decryptPixelLSB(curPixel);
                    img.SetPixel(x, y, newPixel);
                }
            }
            return img;
        }
        public static Bitmap decryptImgKJB(Bitmap cryptedImg)//Расшифровка изображения зашифрованного методом Кутера-Джордена-Боссена
        {
            Bitmap img = new Bitmap(cryptedImg.Width - 2, cryptedImg.Height - 2);

            for (int x = 2; x < cryptedImg.Width - 2; x++)
            {
                for (int y = 2; y < cryptedImg.Height - 2; y++)
                {
                    int B = 0;
                    for (int i = 1; i < 3; i++)
                    {
                        B += cryptedImg.GetPixel(x - i, y).B +
                             cryptedImg.GetPixel(x + i, y).B +
                             cryptedImg.GetPixel(x, y - i).B +
                             cryptedImg.GetPixel(x, y + i).B;
                    }
                    B /= 8;
                    int G = cryptedImg.GetPixel(x, y).B > B ? 128 : 0;
                    int realB = B == 128 ? B : G;
                    cryptedImg.SetPixel(x, y, Color.FromArgb(cryptedImg.GetPixel(x, y).R, cryptedImg.GetPixel(x, y).G, realB));
                    img.SetPixel(x, y, Color.FromArgb(255, G, G, G));
                }
            }
            return img;
        }
        public static Bitmap RobustImageWatermarkingDeCrypt(Bitmap img1, int alphaInput)
        {
            if(alphaInput == 0)
            {
                MessageBox.Show(string.Format("Встраивание водяного знака с таким значением не имеет смысла"));
                return new Bitmap(img1.Width / 8, img1.Height / 8);
            }

            Bitmap bmp = new Bitmap(img1);
            IEnumerable<FastRetinaKeypoint> origKeyPoints, bmpKeyPoints;

            origKeyPoints = Service.ReadKeypointsFromFile($"points{alphaInput}.txt");
            bmpKeyPoints = Service.FindKeyPoints(bmp);

            double rotation = Service.RotateResync(Service.FindCorrelationPoint(origKeyPoints, bmpKeyPoints, 0.5));
            if (Math.Abs(rotation - eps) > eps)
            {
                bmp = Service.RotateImg(bmp, (float)rotation);
            }

            double[,] R, G, B;
            Service.getRGB(bmp, out R, out G, out B);

            Haar.FWT(R, 3);
            Haar.FWT(G, 3);
            Haar.FWT(B, 3);

            //Select LL3 sub - band
            double[,] RLL3 = new double[R.GetLength(0) / 8, R.GetLength(1) / 8];
            double[,] GLL3 = new double[R.GetLength(0) / 8, R.GetLength(1) / 8];
            double[,] BLL3 = new double[R.GetLength(0) / 8, R.GetLength(1) / 8];
            for (int i = 0; i < R.GetLength(0) / 8; i++)
            {
                for (int j = 0; j < R.GetLength(1) / 8; j++)
                {
                    RLL3[i, j] = R[i, j];
                    GLL3[i, j] = G[i, j];
                    BLL3[i, j] = B[i, j];
                }
            }

            SingularValueDecomposition singularR = new SingularValueDecomposition(RLL3, true, true, true, true);
            SingularValueDecomposition singularG = new SingularValueDecomposition(GLL3, true, true, true, true);
            SingularValueDecomposition singularB = new SingularValueDecomposition(BLL3, true, true, true, true);

            double[,] UwR = Service.ReadMatrixFromFile($"UwR{alphaInput}.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
            double[,] UwG = Service.ReadMatrixFromFile($"UwG{alphaInput}.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
            double[,] UwB = Service.ReadMatrixFromFile($"UwB{alphaInput}.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);

            double[,] VwR = Service.ReadMatrixFromFile($"VwR{alphaInput}.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
            double[,] VwG = Service.ReadMatrixFromFile($"VwG{alphaInput}.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
            double[,] VwB = Service.ReadMatrixFromFile($"VwB{alphaInput}.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);

            double[,] SwR = singularR.DiagonalMatrix;
            double[,] SwG = singularG.DiagonalMatrix;
            double[,] SwB = singularB.DiagonalMatrix;

            double[,] SretR = Matrix.Dot(Matrix.Dot(UwR, SwR), Matrix.Transpose(VwR));
            double[,] SretG = Matrix.Dot(Matrix.Dot(UwG, SwG), Matrix.Transpose(VwG));
            double[,] SretB = Matrix.Dot(Matrix.Dot(UwB, SwB), Matrix.Transpose(VwB));

            double[,] WeR = new double[R.GetLength(0) / 8, R.GetLength(1) / 8];
            double[,] WeG = new double[R.GetLength(0) / 8, R.GetLength(1) / 8];
            double[,] WeB = new double[R.GetLength(0) / 8, R.GetLength(1) / 8];

            double[,] SR = Service.ReadMatrixFromFile("SR.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
            double[,] SG = Service.ReadMatrixFromFile("SG.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
            double[,] SB = Service.ReadMatrixFromFile("SB.txt", R.GetLength(0) / 8, R.GetLength(1) / 8);
           
            Service.setRGB(bmp, R, G, B);         
           
            double alpha = (double)alphaInput / 100;

            for (int i = 0; i < R.GetLength(0) / 8; i++)
            {
                for (int j = 0; j < R.GetLength(1) / 8; j++)
                {
                    WeR[i, j] = (SretR[i, j] - SR[i, j]) / alpha;
                    WeG[i, j] = (SretG[i, j] - SG[i, j]) / alpha;
                    WeB[i, j] = (SretB[i, j] - SB[i, j]) / alpha;
                }
            }

            for (int i = 0; i < WeR.GetLength(0); i++)
            {
                for (int j = 0; j < WeR.GetLength(1); j++)
                {
                    if (WeR[i, j] > 255) WeR[i, j] = 255;
                    if (WeG[i, j] > 255) WeG[i, j] = 255;
                    if (WeB[i, j] > 255) WeB[i, j] = 255;

                    if (WeR[i, j] < 0) WeR[i, j] = 0;
                    if (WeG[i, j] < 0) WeG[i, j] = 0;
                    if (WeB[i, j] < 0) WeB[i, j] = 0;
                }
            }
            int transformPeriod = 5;
            WeR = Service.ArnoldRevese(WeR, transformPeriod);
            WeG = Service.ArnoldRevese(WeG, transformPeriod);
            WeB = Service.ArnoldRevese(WeB, transformPeriod);

            var mark = new Bitmap(R.GetLength(0) / 8, R.GetLength(1) / 8);
            using (var g = Graphics.FromImage(mark))
                g.Clear(Color.Black);
            Service.setRGB(mark, WeR, WeG, WeB);

            return mark;
        }
    }
}