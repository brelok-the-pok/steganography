using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Math;
using Accord.Math.Distances;
using Emgu.CV;
using Emgu.CV.Structure;

namespace steganographyLab1
{
    class Service
    {
        public static IEnumerable<FastRetinaKeypoint>  FindKeyPoints(Bitmap img)
        {
            Bitmap bmp = new Bitmap(img);

            FastRetinaKeypointDetector freak = new FastRetinaKeypointDetector(20);

            IEnumerable<FastRetinaKeypoint>  keyPoints = freak.Transform(bmp);

            return keyPoints;
        }
        //LSB start//
        //Запись в LSB пикселя
        public static Color CryptPixelLSB(Color basePixel, Color markPixel)
        {
            byte R, G, B;
            R = CryptByteLSB(basePixel.R, markPixel.R);
            G = CryptByteLSB(basePixel.G, markPixel.G);
            B = CryptByteLSB(basePixel.B, markPixel.B);
            return Color.FromArgb(R, G, B);
        }
        //Запись в последний бит 
        public static byte CryptByteLSB(byte src, byte mark)
        {
            string srcStr = byteToBin(src);
            string markStr = byteToBin(mark);
            srcStr = srcStr.Insert(7, markStr);
            return binToByte(srcStr);
        }
        public static Color decryptPixelLSB(Color cryptedPixel)//Расшифровка пикселя зашифрованного методом LSB
        {
            byte R = (cryptedPixel.R % 2 == 1) ? (byte)128 : (byte)0;//Если последний бит байта R - единица, то R = 128, иначе 0
            byte G = (cryptedPixel.G % 2 == 1) ? (byte)128 : (byte)0;
            byte B = (cryptedPixel.B % 2 == 1) ? (byte)128 : (byte)0;
            return Color.FromArgb(R, G, B);
        }
        //LSB end//
        //Преобразование байта в его битовое представление
        public static string byteToBin(byte number)
        {
            string result = string.Empty;

            for (int i = 7; i >= 0; i--)
            {
                if ((number & (1 << i)) != 0)//Текущий бит - единичка
                {
                    result += '1';
                }
                else//Текущий бит - ноль
                {
                    result += '0';
                }
            }

            return result;
        }
        //Преобразование строчного представления байта в байт
        public static byte binToByte(string str)
        {
            byte result = 0;

            for (int i = 0; i < 8; i++)
            {
                if (str[i] == '1')//Если текущий бит - единичка
                {
                    result += (byte)(1 << (7 - i));//Заменить нулевой бит на бит равный единице
                }
            }
            return result;
        }
        public static void getRGB(Bitmap bmp, out double[,] R, out double[,] G, out double[,] B)
        {
            //Берём биты пикселей
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int size = rgbValues.Length / 4;
           
            double[] Rtmp = new double[size];
            double[] Gtmp = new double[size];
            double[] Btmp = new double[size];
            //Сохраняем их в наш массив
            for (int i = 0; i < size; i++)
            {
                Btmp[i] = rgbValues[i * 4];
                Gtmp[i] = rgbValues[i * 4 + 1];
                Rtmp[i] = rgbValues[i * 4 + 2];
            }
            //Конвертируем в 2d массив
            R = convertTo2DArr(bmp.Height, bmp.Width, Rtmp);
            G = convertTo2DArr(bmp.Height, bmp.Width, Gtmp);
            B = convertTo2DArr(bmp.Height, bmp.Width, Btmp);
            //Возвращаем биты в изображение
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
        }
        public static void setRGB(Bitmap bmp, double[,] R, double[,] G, double[,] B)
        {
            //Берём биты пикселей
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int height = bmp.Height;
            int width = bmp.Width;

            for (int i = 0; i < height; i++)
            {
                int z = i * 4 * width;
                for (int j = 0; j < width - 1; j++)
                {
                    rgbValues[z] = (byte)B[i, j];
                    z += 4;
                }
                z = 1 + i * 4 * width;
                for (int j = 0; j < width - 1; j++)
                {
                    rgbValues[z] = (byte)G[i, j];
                    z += 4;
                }
                z = 2 + i * 4 * width;
                for (int j = 0; j < width - 1; j++)
                {
                    rgbValues[z] = (byte)R[i, j];
                    z += 4;
                }
            }

            //Возвращаем биты в изображение
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
        }
        public static double[,] convertTo2DArr(int height, int width, double[] arrSource)
        {
            double[,] arr = new double[height, width];

            int k = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = arrSource[k++];
                }
            }
            return arr;

        }
        public static double[,] Arnold(double[,] input, int period)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            double[,] output = new double[height, width];
            double[,] buff = (double[,])input.Clone();

            for (int i = 0; i < period; i++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        
                        output[(2 * x + y) % width, (x + y) % height] = buff[x, y];
                    }
                }
                buff = (double[,])output.Clone();
            }
            return output;
        }
        public static double[,] ArnoldMy(double[,] input, int period)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            double[,] output = new double[height, width];
            double[,] buff = (double[,])input.Clone();

            for (int i = 0; i < period; i++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        output[x, y] = buff[(2 * x + y) % width, (x + y) % height];
                        //output[(2 * x + y) % width, (x + y) % height] = buff[x, y];
                    }
                }
                buff = (double[,])output.Clone();
            }
            return output;
        }

        public static double[,] ArnoldRevese(double[,] input, int period)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            double[,] output = new double[height, width];
            double[,] buff = (double[,])input.Clone();

            for (int i = 0; i < period; i++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        //output[x, y] = input[(2 * x + y) % width, (x + y) % height];
                        output[x, y] = buff[(2 * x + y) % width, (x + y) % height];
                    }
                }
                buff = (double[,])output.Clone();
            }
            return output;
        }
        public static Mat MatFromImage(System.Drawing.Image image)//Какой-то ужас
        {
            Bitmap bmp = new Bitmap(image);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            int stride;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
        }
        public static Bitmap GetImageFromUser(string desktopDirectory)//Выбор пути к изображению пользлвателем
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = desktopDirectory; 
            openFileDialog.Filter = "bmp files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog.FileName);
                return image;
            }
            else
            {
                return new Bitmap(512, 512);
            }
        }
        public static Bitmap imgDiff(Bitmap img1, Bitmap img2)//Нахождение попиксельной разности двух изображений
        {
            Bitmap img = (Bitmap)img1.Clone();
            for (int x = 0; x < img1.Width; x++)
            {
                for (int y = 0; y < img1.Height; y++)
                {
                    Color pixel1 = img1.GetPixel(x, y);
                    Color pixel2 = img2.GetPixel(x, y);
                    Color curPixel = pixelDiff(pixel1, pixel2);
                    img.SetPixel(x, y, curPixel);
                }
            }
            return img;
        }
        private static Color pixelDiff(Color pixel1, Color pixel2)//Нахождение побитовой разницы двух пикселей
        {
            if (pixel1 == pixel2)
            {
                return Color.Black;
            }
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
                    if (str1[i] != str2[i])
                    {
                        str1 = str1.Insert(i, "1");
                    }
                    else
                    {
                        str1 = str1.Insert(i, "0");
                    }
                }
                byteArr[j] = Service.binToByte(str1);
            }
            return Color.FromArgb(255, byteArr[0], byteArr[1], byteArr[2]);
        }

        public static double[,] ReadMatrixFromFile(string fileName, int size1, int size2)
        {
            double[,] array = new double[size1, size2];
            if (!File.Exists(fileName))
            {
                MessageBox.Show(string.Format("Файл {0} не существует, для его создания необходимо провести встраивание водяного знака с заданым в названии файла процентом встраивания", fileName));
                return new double[size1, size2];
            }

            StreamReader str = new StreamReader(fileName);
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    array[i, j] = double.Parse(str.ReadLine());
                }
            }
            str.Close();

            return array;
        }
        public static bool WriteMatrixInFile(string fileName, double[,] matrix)
        {
            StreamWriter str = new StreamWriter(fileName);
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    str.WriteLine(matrix[i, j]);
                }
            }
            str.Close();
            return true;
        }
        public static bool WriteKeypointsInFile(Bitmap bmp, string fileName)
        {
            IEnumerable<FastRetinaKeypoint> BmpKeyPoints;
            BmpKeyPoints = FindKeyPoints(bmp);

            StreamWriter str = new StreamWriter(fileName);
            FastRetinaKeypoint[] asd = BmpKeyPoints.ToArray();
            for (int i = 0; i < asd.Length; i++)
            {
                str.Write(asd[i].ToHex());
                str.Write(' ');
                str.Write(asd[i].X);
                str.Write(' ');
                str.Write(asd[i].Y);
                str.Write(' ');
                str.Write(asd[i].Orientation);
                str.Write(' ');
                str.WriteLine(asd[i].Scale);
            }

            str.Close();
            return true;
        }
        public static IEnumerable<FastRetinaKeypoint> ReadKeypointsFromFile(string fileName)
        {
            List<FastRetinaKeypoint> points = new List<FastRetinaKeypoint>();
            if (!File.Exists(fileName))
            {
                MessageBox.Show(string.Format("Файл {0} не существует, для его создания необходимо провести встраивание водяного знака с заданым в названии файла процентом встраивания", fileName));
                return new List<FastRetinaKeypoint>();
            }

            StreamReader str = new StreamReader(fileName);
            while (!str.EndOfStream)
            {
                string line = str.ReadLine();
                string[] splitedLine = line.Split(' ');

                byte[] descriptor = HexStringToByteArray(splitedLine[0]);
                double x = double.Parse(splitedLine[1]);
                double y = double.Parse(splitedLine[2]);
                double orientation = double.Parse(splitedLine[3]);
                double scale = double.Parse(splitedLine[4]);

                var point = new FastRetinaKeypoint(x, y);
                point.Descriptor = descriptor;
                point.Orientation = orientation;
                point.Scale = scale;

                points.Add(point);
            }

            str.Close();
            return points;
        }
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static IntPoint[][] FindCorrelationPoint(IEnumerable<FastRetinaKeypoint> points1, IEnumerable<FastRetinaKeypoint> points2,
            double treshold = 0.001, double probability = 0.99)
        {
            if(points1.Count() < 1 || points2.Count() < 1)
            {
                MessageBox.Show(string.Format("Невозможно найти коррелирующие точки, так как ключевые точки изображений пусты"));
                return null;
            }

            var matcher = new KNearestNeighborMatching<byte[]>(5, new Hamming());
            IntPoint[][] matches = matcher.Match(points1, points2);

            IntPoint[] correlationPoints1 = matches[0];
            IntPoint[] correlationPoints2 = matches[1];

            RansacHomographyEstimator ransac = new RansacHomographyEstimator(treshold, probability);
            MatrixH homography = ransac.Estimate(correlationPoints1, correlationPoints2);

            // Plot RANSAC results against correlation results
            IntPoint[] inliers1 = correlationPoints1.Get(ransac.Inliers);
            IntPoint[] inliers2 = correlationPoints2.Get(ransac.Inliers);

            matches[0] = inliers1;
            matches[1] = inliers2;

            return matches;
        }
        public static double RotateResync(IntPoint[][] matches)
        {
            if(matches == null)
            {
                MessageBox.Show(string.Format("Невозможно найти угол поворота, так как массив коррелирующих точек пуст"));
                return 0;
            }

            double ar = 0;

            Accord.Point startPos, W, A;
            startPos.X = 512 / 2;
            startPos.Y = 512 / 2;


            IntPoint[] correlationPoints1 = matches[0];
            IntPoint[] correlationPoints2 = matches[1];

            for (int i = 0; i < correlationPoints1.Length; i++)
            {
                W.X = correlationPoints1[i].X;
                W.Y = correlationPoints1[i].Y;

                A.X = correlationPoints2[i].X;
                A.Y = correlationPoints2[i].Y;

                float angle = Accord.Math.Geometry.GeometryTools.GetAngleBetweenVectors(startPos, W, A);
                if (!double.IsNaN(angle))
                {
                    ar += angle;
                }
            }
            ar /= correlationPoints1.Length;

            if (double.IsNaN(ar)) ar = 0;
            return ar;
        }
        public static double TranslationResync(IntPoint[][] matches)
        {
            double ar = 0;

            return ar;
        }
        public static double[] ScaleResync(IntPoint[][] matches)
        {
            double[] scale = new double[2];

            IntPoint[] correlationPoints1 = matches[0];
            IntPoint[] correlationPoints2 = matches[1];

            for (int i = 0; i < correlationPoints1.Length; i++)
            {
                scale[0] += (double)correlationPoints1[i].X / correlationPoints2[i].X;
                scale[1] += (double)correlationPoints1[i].Y / correlationPoints2[i].Y;
            }
            scale[0] /= correlationPoints1.Length;
            scale[1] /= correlationPoints1.Length;

            return scale;
        }
        public static Bitmap RotateImg(Bitmap bmp, float angle)
        {
            var newBitmap = new Bitmap(bmp.Width, bmp.Height);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            graphics.DrawImage(bmp, new System.Drawing.Point(0, 0));
            return newBitmap;
        }
        public static Bitmap ResizeImg(Bitmap b, double[] scale)
        {
            // create filter
            ResizeBilinear filter = new ResizeBilinear((int)(b.Width * scale[0]), (int)(b.Height * scale[1]));
            // apply the filter
            Bitmap image = filter.Apply(b);

            return image;
        }
    }
}