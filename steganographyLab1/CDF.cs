using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace HaarFramework2
{
    class CDF
    {
        

        public CDF()
        {
        }

        public float[,] fwt97(float[,] s, int width, int height)
        {
            double a1 = -1.586134342;
            double a2 = -0.05298011854;
            double a3 = 0.8829110762;
            double a4 = 0.4435068522;

            double k1 = 0.81289306611596146; 
            double k2 = 0.61508705245700002;

            for (int col = 0; col < height; col++)
            {
                for (int row = 1; row < height - 1; row += 2)
                {
                    s[row, col] += (float)(a1 * (s[row - 1, col] + s[row + 1, col]));
                }
                s[height - 1, col] += (float)(2 * a1 * s[height - 2, col]);

                for (int row = 2; row < height; row += 2)
                {
                    s[row, col] += (float)(a2 * (s[row-1, col] + s[row+1, col]));
                }
                s[0, col] += (float)(2 * a2 * s[1, col]);

                for (int row = 1; row < height - 1; row += 2)
                {
                    s[row, col] += (float)(a3 * (s[row - 1, col] + s[row+1, col]));
                }
                s[height - 1, col] += (float)(2 * a3 * s[height - 2, col]);

        
                for (int row = 2; row < height; row += 2)
                {
                    s[row, col] += (float)(a4 * (s[row - 1, col] + s[row + 1, col]));
                }
                s[0, col] += (float)(2 * a4 * s[1, col]);
            }

            
            float[,] temp_bank = new float[width, height];
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (row % 2 == 0)
                    {
                        temp_bank[col, row / 2] = (float)k1 * s[row, col];
                    }
                    else
                    {
                        temp_bank[col, row / 2 + height / 2] = (float)k2 * s[row, col];
                    }
                }
            }

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    s[row, col] = temp_bank[row, col];
                }
            }

            return s;
        } // fwt97

        public void fwt97_2d(ref float[,] m, int nlevels)
        {
            int w = m.GetLength(0);
            int h = m.GetLength(1);

            for (int i = 0; i < nlevels; i++)
            {
                m = fwt97(m, w, h); // cols
                m = fwt97(m, w, h); // rows
                w /= 2;
                h /= 2;
            }
        } // fwt97_2d

        public float[,] iwt97(float[,] s, int width, int height)
        {
            double a1 = 1.586134342;
            double a2 = 0.05298011854;
            double a3 = -0.8829110762;
            double a4 = -0.4435068522;

            double k1 = 1.230174104914;
            double k2 = 1.6257861322319229;

            float[,] temp_bank = new float[width, height];
            for (int col = 0; col < width/2; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    temp_bank[col * 2, row] = (float)k1 * s[row, col];
                    temp_bank[col * 2 + 1, row] = (float)k2 * s[row, col + width / 2];
                }
            }

            for (int row = 0; row < width; row++) 
            {
                for (int col = 0; col < height; col++)
                {
                    s[row, col] = temp_bank[row, col];
                }
            }

            for (int col = 0; col < width; col++)
            {
                for (int row = 2; row < height; row += 2)
                {
                    s[row, col] += (float)a4 * (s[row-1, col] + s[row+1, col]);
                }
                s[0, col] += 2 * (float)a4 * s[1, col];

                for (int row = 1; row < height-1; row += 2)
                {
                    s[row, col] += (float)a3 * (s[row-1, col] + s[row+1, col]);
                }
                s[height - 1, col] += 2 * (float)a3 * s[height - 2, col];

                for (int row = 2; row < height; row += 2)
                {
                    s[row, col] += (float)a2 * (s[row-1, col] + s[row+1, col]);
                }
                s[0, col] += 2 * (float)a2 * s[1, col];

                for (int row = 1; row < height-1; row += 2)
                {
                    s[row, col] += (float)a1 * (s[row-1, col] + s[row+1, col]);
                }
                s[height - 1, col] += 2 * (float)a1 * s[height - 2, col];


            }

            return s;
        } // ifwt97

        public void iwt97_2d(ref float[,] m, int nlevels)
        {

        int w = m.GetLength(0);
        int h = m.GetLength(1);

        for (int i = 0; i < nlevels - 1; i++)
        {
            h /= 2;
            w /= 2;
        }

        for (int i = 0; i < nlevels; i++)
        {
            m = iwt97(m, w, h); // rows
            m = iwt97(m, w, h); // cols
            h *= 2;
            w *= 2;
        }

        //return m
        }
    }
}
