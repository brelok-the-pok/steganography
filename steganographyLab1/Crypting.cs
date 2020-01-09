using Accord.Math.Decompositions;
using Accord.Math.Wavelets;
using System.Drawing;

namespace steganographyLab1
{
    class Crypting
    {
        //Зашифровка изображения методом Наименьшего значащего бита Leas-Significant-Bit
        public static Bitmap LSB(Bitmap img1, Bitmap img2)
        {
            Bitmap resImg;//Изображение контейнер
            Bitmap markImg;//Изображение водный-знак
            resImg = (Bitmap)img1.Clone();
            markImg = (Bitmap)img2.Clone();
            int[] startPixelCoordinates = new int[2];//Начало отрисовки водного знака (Координаты первого пикселя)
            startPixelCoordinates[0] = (resImg.Width - markImg.Width) / 2;//Абсциса первого пикселя 
            startPixelCoordinates[1] = (resImg.Height - markImg.Height) / 2;//Ордината первого пикселя
            int[] endPixelCoordinates = new int[2];//Конец отрисовки водяного знака (Координаты последего пикселя)
            endPixelCoordinates[0] = (resImg.Width + markImg.Width) / 2;//Абсциса последнего пикселя
            endPixelCoordinates[1] = (resImg.Height + markImg.Height) / 2;//Ордината последнего пикселя

            int x2 = 0, y2 = 0;
            for (int x = startPixelCoordinates[0]; x < endPixelCoordinates[0]; x++)
            {
                for (int y = startPixelCoordinates[1]; y < endPixelCoordinates[1]; y++)
                {
                    Color srcPixel = resImg.GetPixel(x, y);
                    Color markPixel = markImg.GetPixel(x2, y2);
                    resImg.SetPixel(x, y, Service.CryptPixelLSB(srcPixel, markPixel));
                    y2++;
                }
                x2++;
                y2 = 0;
            }
            return resImg;
        }
        public static Bitmap KJB(Bitmap img1, Bitmap img2)//Зашифровка изображения методом Кутера-Джордена-Боссена
        {
            Bitmap resImg = (Bitmap)img1.Clone();//Изображение контейнер
            Bitmap markImg = (Bitmap)img2.Clone();//Изображение водный-знак
            int[] startPixelCoordinates = new int[2];//Начало отрисовки водного знака (Координаты первого пикселя)
            startPixelCoordinates[0] = (resImg.Width + 2 - markImg.Width) / 2;//Абсциса первого пикселя 
            startPixelCoordinates[1] = (resImg.Height + 2 - markImg.Height) / 2;//Ордината первого пикселя
            int[] endPixelCoordinates = new int[2];//Конец отрисовки водного знака (Координаты последего пикселя)
            endPixelCoordinates[0] = (resImg.Width - 2 + markImg.Width) / 2;//Абсциса последнего пикселя
            endPixelCoordinates[1] = (resImg.Height - 2 + markImg.Height) / 2;//Ордината последнего пикселя


            for (int k = 0; k < 2; k++)
            {
                int x2 = 0, y2 = 0;
                for (int x = startPixelCoordinates[0]; x < endPixelCoordinates[0] - 1; x++)
                {
                    for (int y = startPixelCoordinates[1]; y < endPixelCoordinates[1] - 1; y++)
                    {
                        Color srcPixel = resImg.GetPixel(x, y);
                        Color markPixel = markImg.GetPixel(x2, y2);
                        byte R = srcPixel.R;
                        byte G = srcPixel.G;
                        byte B = srcPixel.B;
                        double Y = (0.299 * R + 0.587 * G + 0.114 * B);
                        double Y2 = (0.299 * markPixel.R + 0.587 * markPixel.G + 0.114 * markPixel.B);
                        double lymbda = 0.05;
                        if (Y2 > 126) B += (byte)(Y * lymbda);
                        else B -= (byte)(Y * lymbda);
                        resImg.SetPixel(x, y, Color.FromArgb(R, G, B));
                        y2++;
                    }
                    x2++;
                    y2 = 0;
                }
            }
            return resImg;
        }
        public static Bitmap RobustImageWatermarkingCrypt(Bitmap img1, Bitmap img2, int alphaInput)
        {
            //Read Images
            Bitmap bmp = new Bitmap(img1);

            Service.getRGB(bmp, out double[,] R, out double[,] G, out double[,] B);

            //Apply three-level DWT on the host image.
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

            double[,] UR, UG, UB;
            double[,] SR, SG, SB;
            double[,] VR, VG, VB;
            //USVT←SVD (LL3); Perform SVD on the selected sub - band
            SingularValueDecomposition singularR = new SingularValueDecomposition(RLL3, true, true, true, true);
            SingularValueDecomposition singularG = new SingularValueDecomposition(GLL3, true, true, true, true);
            SingularValueDecomposition singularB = new SingularValueDecomposition(BLL3, true, true, true, true);

            UR = singularR.LeftSingularVectors;
            VR = singularR.RightSingularVectors;
            SR = singularR.DiagonalMatrix;

            UG = singularG.LeftSingularVectors;
            VG = singularG.RightSingularVectors;
            SG = singularG.DiagonalMatrix;

            UB = singularB.LeftSingularVectors;
            VB = singularB.RightSingularVectors;
            SB = singularB.DiagonalMatrix;

            //Save diagonal matrix
            Service.WriteMatrixInFile("SR.txt", SR);
            Service.WriteMatrixInFile("SG.txt", SG);
            Service.WriteMatrixInFile("SB.txt", SB);

            Bitmap mark = new Bitmap(img2);
            double[,] Rmark, Gmark, Bmark;
            Service.getRGB(mark, out Rmark, out Gmark, out Bmark);

            //Watermark encryption by Arnold transform
            int transformPeriod = 5;
            Rmark = Service.Arnold(Rmark, transformPeriod);
            Gmark = Service.Arnold(Gmark, transformPeriod);
            Bmark = Service.Arnold(Bmark, transformPeriod);

            //Select the optimized scaling factor from 0.1 to 1 manually.
            double alpha = (double)alphaInput / 100;

            double[,] SwR = (double[,])SR.Clone();
            double[,] SwG = (double[,])SG.Clone();
            double[,] SwB = (double[,])SB.Clone();

            for (int i = 0; i < R.GetLength(0) / 8; i++)//Sw = S + α × W
            {
                for (int j = 0; j < R.GetLength(1) / 8; j++)
                {
                    SwR[i, j] += alpha * Rmark[i, j];
                    SwG[i, j] += alpha * Gmark[i, j];
                    SwB[i, j] += alpha * Bmark[i, j];
                }
            }

            //Dual SVD on watermarked singular matrix
            SingularValueDecomposition singularSwR = new SingularValueDecomposition(SwR, true, true, true, true);
            SingularValueDecomposition singularSwG = new SingularValueDecomposition(SwG, true, true, true, true);
            SingularValueDecomposition singularSwB = new SingularValueDecomposition(SwB, true, true, true, true);

            //Save left matrix
            Service.WriteMatrixInFile($"UwR{alphaInput}.txt", singularSwR.LeftSingularVectors);
            Service.WriteMatrixInFile($"UwG{alphaInput}.txt", singularSwG.LeftSingularVectors);
            Service.WriteMatrixInFile($"UwB{alphaInput}.txt", singularSwB.LeftSingularVectors);
            //Save rigth matrix
            Service.WriteMatrixInFile($"VwR{alphaInput}.txt", singularSwR.RightSingularVectors);
            Service.WriteMatrixInFile($"VwG{alphaInput}.txt", singularSwG.RightSingularVectors);
            Service.WriteMatrixInFile($"VwB{alphaInput}.txt", singularSwB.RightSingularVectors);

            double[,] LL3WR = Accord.Math.Matrix.Dot(Accord.Math.Matrix.Dot(UR, singularSwR.DiagonalMatrix), Accord.Math.Matrix.Transpose(VR));
            double[,] LL3WG = Accord.Math.Matrix.Dot(Accord.Math.Matrix.Dot(UG, singularSwG.DiagonalMatrix), Accord.Math.Matrix.Transpose(VG));
            double[,] LL3WB = Accord.Math.Matrix.Dot(Accord.Math.Matrix.Dot(UB, singularSwB.DiagonalMatrix), Accord.Math.Matrix.Transpose(VB));

            for (int i = 0; i < R.GetLength(0) / 8; i++)
            {
                for (int j = 0; j < R.GetLength(1) / 8; j++)
                {
                    R[i, j] = LL3WR[i, j];
                    G[i, j] = LL3WG[i, j];
                    B[i, j] = LL3WB[i, j];
                }
            }

            Haar.IWT(R, 3);
            Haar.IWT(G, 3);
            Haar.IWT(B, 3);

            for (int i = 0; i < R.GetLength(0); i++)
            {
                for (int j = 0; j < R.GetLength(1); j++)
                {
                    if (R[i, j] > 255) R[i, j] = 255;
                    if (G[i, j] > 255) G[i, j] = 255;
                    if (B[i, j] > 255) B[i, j] = 255;

                    if (R[i, j] < 0) R[i, j] = 0;
                    if (G[i, j] < 0) G[i, j] = 0;
                    if (B[i, j] < 0) B[i, j] = 0;
                }
            }

            Service.setRGB(bmp , R, G, B);

            Service.WriteKeypointsInFile(bmp, $"points{alphaInput}.txt");

            return bmp;
        }
    }
}
