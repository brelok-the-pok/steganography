using System.Drawing;
using Accord.Imaging.Filters;

namespace steganographyLab1
{
    class Attacks
    {
        public static Bitmap brightnesAttack(Bitmap img, int attackPercent)
        {
            Bitmap resImg = new Bitmap(img);
            int lymbda = attackPercent;
            var filter = new BrightnessCorrection(lymbda);
            filter.ApplyInPlace(resImg);
            return resImg;
        }
        public static Bitmap blurAttack(Bitmap img, int attackPercent)
        {
            Bitmap bmp = new Bitmap(img);
            var filter = new Blur();

            int coeff = (int)((double)attackPercent / 100 * 5) + 1;

            int[,] kernel =
            {
                {1+coeff, 2+coeff, 3+coeff, 2+coeff, 1+coeff},
                {2+coeff, 4-coeff, 5-coeff, 4-coeff, 2+coeff},
                {3+coeff, 5-coeff, 6-coeff, 5-coeff, 3+coeff},
                {2+coeff, 4-coeff, 5-coeff, 4-coeff, 2+coeff},
                {1+coeff, 2+coeff, 3+coeff, 2+coeff, 1+coeff}

            };
            filter.Kernel = kernel;

            filter.ApplyInPlace(bmp);

            return bmp;
        }
        public static Bitmap SharpenAttack(Bitmap img, int attackPercent)
        {
            Bitmap bmp = new Bitmap(img);
            var filter = new Sharpen();

            int coeff = (int)((double)attackPercent / 100 * 5) + 1;

            int[,] kernel =
            {
                {0, -1-coeff, 0},
                {-1+coeff, 5, -1+coeff },
                {0, -1-coeff, 0},
            };
            filter.Kernel = kernel;

            filter.ApplyInPlace(bmp);
            return bmp;
        }
        public static Bitmap JittersAttack(Bitmap img, int attackPercent)
        {
            Bitmap bmp = new Bitmap(img);
            double rad = (double)attackPercent / 100 * 9 + 1;
            var filter = new Jitter((int)rad);
            filter.ApplyInPlace(bmp);
            return bmp;
        }

        public static Bitmap CropAttack(Bitmap img, int attackPercent)
        {
            Bitmap bmp = new Bitmap(img);
            double val = (double)attackPercent / 100;
            int rectA = (int)(bmp.Width * val);
            int rectB = (int)(bmp.Height * val);
            int x = bmp.Width / 2 - rectA / 2;
            int y = bmp.Height / 2 - rectB / 2;
            CanvasFill filter = new CanvasFill(new Rectangle(
                        x, y, rectA, rectB), Color.Black);
            filter.ApplyInPlace(bmp);
            return bmp;
        }
    }
}
