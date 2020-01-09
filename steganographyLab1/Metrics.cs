using Emgu.CV;
using Emgu.CV.Quality;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace steganographyLab1
{
    class Metrics
    {
        //нахождение побитовой ошибки Bit Error Rate метрикой
        public static double BER(Bitmap img1, Bitmap img2)
        {
            if(img1.Height != img2.Height || img1.Width != img2.Width)
            {
                MessageBox.Show(string.Format("Невозмодно найти значение BER, так как размеры изображений отличаются"));
                return 0;
            }

            double BER;
            int errors = 0;
            int width = img1.Width;
            int height = img1.Height;
            int total = width * height * 24;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel1 = img1.GetPixel(x, y);
                    Color pixel2 = img2.GetPixel(x, y);
                    byte[] byteArr = new byte[6];
                    byteArr[0] = pixel1.R;
                    byteArr[1] = pixel1.G;
                    byteArr[2] = pixel1.B;
                    byteArr[3] = pixel2.R;
                    byteArr[4] = pixel2.G;
                    byteArr[5] = pixel2.B;
                    for (int j = 0; j < 3; j++)
                    {
                        string str1, str2;
                        str1 = Service.byteToBin(byteArr[j]);
                        str2 = Service.byteToBin(byteArr[j + 3]);
                        for (int i = 0; i < 8; i++)
                        {
                            if (str1[i] != str2[i]) errors++;
                        }
                    }
                }
            }
            BER = (double)errors / total;
            return 100 * BER;
        }
        public static double PSNR(Bitmap img1, Bitmap img2)
        {
            if (img1.Height != img2.Height || img1.Width != img2.Width)
            {
                MessageBox.Show(string.Format("Невозмодно найти значение PSNR, так как размеры изображений отличаются"));
                return 0;
            }

            Bitmap srcimg = new Bitmap(img1);
            Bitmap srcimgMarked = new Bitmap(img2);

            QualityPSNR PSNROpenCV = new QualityPSNR(Service.MatFromImage(srcimg));

            MCvScalar PSNROpenCVScalar = PSNROpenCV.Compute(Service.MatFromImage(srcimgMarked));

            double PSNR = (PSNROpenCVScalar.V0 + PSNROpenCVScalar.V1 + PSNROpenCVScalar.V2) / 3;

            PSNROpenCV.Dispose();

            return PSNR;
        }
        public static double RMS(Bitmap img1, Bitmap img2)
        {
            if (img1.Height != img2.Height || img1.Width != img2.Width)
            {
                MessageBox.Show(string.Format("Невозмодно найти значение RMS, так как размеры изображений отличаются"));
                return 0;
            }

            Bitmap srcimg = new Bitmap(img1);
            Bitmap srcimgMarked = new Bitmap(img2);

            QualityMSE RMSOpenCV = new QualityMSE(Service.MatFromImage(srcimg));

            MCvScalar RMSOpenCVScalar = RMSOpenCV.Compute(Service.MatFromImage(srcimgMarked));

            double RMS = (RMSOpenCVScalar.V0 + RMSOpenCVScalar.V1 + RMSOpenCVScalar.V2) / 3;

            RMSOpenCV.Dispose();

            return RMS;
        }
        public static double SSIM(Bitmap img1, Bitmap img2)
        {
            if (img1.Height != img2.Height || img1.Width != img2.Width)
            {
                MessageBox.Show(string.Format("Невозмодно найти значение SSIM, так как размеры изображений отличаются"));
                return 0;
            }

            Bitmap srcimg = new Bitmap(img1);
            Bitmap srcimgMarked = new Bitmap(img2);

            QualitySSIM SSIMOpenCV = new QualitySSIM(Service.MatFromImage(srcimg));

            MCvScalar SSIMOpenCVScalar = SSIMOpenCV.Compute(Service.MatFromImage(srcimgMarked));

            double SSIM = (SSIMOpenCVScalar.V0 + SSIMOpenCVScalar.V1 + SSIMOpenCVScalar.V2) / 3;

            SSIMOpenCV.Dispose();

            return SSIM;
        }
        public static double NCC(Bitmap img1, Bitmap img2)
        {
            if (img1.Height != img2.Height || img1.Width != img2.Width)
            {
                MessageBox.Show(string.Format("Невозмодно найти значение NCC, так как размеры изображений отличаются"));
                return 0;
            }

            Bitmap srcimg = new Bitmap(img1);
            Bitmap srcimgMarked = new Bitmap(img2);

            Mat some = new Mat();

            CvInvoke.MatchTemplate(Service.MatFromImage(srcimg), Service.MatFromImage(srcimgMarked), some, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);

            Array ar = some.GetData();

            float[,] ar2 = (float[,])ar.Clone();

            double NCC = ar2[0, 0];

            return NCC;
        }
    }
}
