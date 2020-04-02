
using System.Drawing;
using System;

namespace Assignment4
{
    public static class SignalProcessor
    {
        private static int getArraySize(double sigma)
        {
            int size = (int)(sigma * 6.0);
            if (size % 2 == 0)
            {
                size += 1;
                Console.WriteLine("size:{0} (+1), sigma:{1} X 6 = {2}", size, sigma, sigma * 6.0);
            }
            else if ((double)size == (sigma * 6.0))
            {
                // size += 2;
                Console.WriteLine("size:{0} (+0), sigma:{1} X 6 = {2}", size, sigma, sigma * 6.0);
            }
            else
            {
                size += 2;
                Console.WriteLine("size:{0} (+2), sigma:{1} X 6 = {2}", size, sigma, sigma * 6.0);
            }

            return size;
        }


        public static double[] GetGaussianFilter1D(double sigma)
        {
            int size = getArraySize(sigma);
            double[] valueArray = new double[size];
            int index = 0;
            for (int i = -size / 2; i <= size / 2; i++)
            {
                // double pos = -Math.Pow(Math.Abs(center - i), 2);
                double pos = -Math.Pow(i, 2);
                double square = pos / (2.0 * sigma * sigma);
                valueArray[index++] = (1.0 / (sigma * Math.Sqrt(Math.PI * 2.0))) * Math.Pow(Math.E, square);
            }

            return valueArray;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            double[] resultArr = new double[signal.Length];
            var center = filter.Length / 2;
            var reverse = new double[filter.Length];
            Array.Copy(filter, reverse, filter.Length);
            Array.Reverse(reverse);

            for (int i = 0; i < resultArr.Length; i++)
            {
                double sum = 0d;
                for (int j = 0; j < reverse.Length; j++)
                {
                    int index = i - (center - j);
                    double signalValue = index >= 0 && index < resultArr.Length ? signal[index] : 0;
                    sum += signalValue * reverse[j];
                }
                resultArr[i] = sum;
            }

            return resultArr;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            // var size = (int)(sigma * 6.0);
            // size = size % 2 == 0 ? size + 1 : size;
            int size = getArraySize(sigma);
            var center = size / 2;
            double[,] valueArray = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var pos = -(Math.Pow(Math.Abs(center - i), 2) + Math.Pow(Math.Abs(center - j), 2));
                    double square = (double)pos / (2.0 * sigma * sigma);
                    valueArray[i, j] = (1.0 / (2.0 * Math.PI * sigma * sigma)) * Math.Pow(Math.E, square);
                }
            }

            return valueArray;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            double[,] flipArr = flipMatrix(filter);

            for (int w = 0; w < bitmap.Width; w++)
            {
                for (int h = 0; h < bitmap.Height; h++)
                {
                    Color color = getColorMatrix(bitmap, flipArr, w, h);
                    
                    bitmap.SetPixel(w, h, color);
                }
            }

            return bitmap;
        }

        private static Color getColorMatrix(Bitmap bitmap, double[,] filter, int posX, int posY)
        {
            Color[,] colorArr = new Color[filter.GetLength(1), filter.GetLength(0)];

            int centerX = filter.GetLength(0) / 2;
            int centerY = filter.GetLength(1) / 2;
            
            int r = 0;
            int g = 0;
            int b = 0;

            for (int w = 0; w < filter.GetLength(0); w++)
            {
                for (int h = 0; h < filter.GetLength(1); h++)
                {
                    int indexX = posX - (centerX - w);
                    int indexY = posY - (centerY - h);

                    if (indexX < 0 || indexY < 0 || indexX >= bitmap.Width || indexY >= bitmap.Height)
                    {
                        colorArr[w, h] = Color.Black;
                    }
                    else 
                    {
                        colorArr[w, h] = bitmap.GetPixel(indexX, indexY);
                    }

                    // Console.WriteLine("({0},{1}: {2})", indexX, indexY, colorArr[w, h]);

                    r += (int)((double)colorArr[w, h].R * filter[w, h]);
                    g += (int)((double)colorArr[w, h].G * filter[w, h]);
                    b += (int)((double)colorArr[w, h].B * filter[w, h]);
                }
            }

            Color resultColor = Color.FromArgb(r, g, b);
            return resultColor;
        }


        private static double[,] flipMatrix(double[,] filter)
        {
            double[,] flipArr = new double[filter.GetLength(1), filter.GetLength(0)];

            for (int w = 0; w < filter.GetLength(1); w++)
            {
                for (int h = 0; h < filter.GetLength(0); h++)
                {
                    flipArr[w, h] = filter[filter.GetLength(1) - 1 - w, filter.GetLength(0) - 1 - h];
                }
            }

            return flipArr;
        }
    }
}