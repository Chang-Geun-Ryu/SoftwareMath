
using System.Drawing;
using System;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            var size = (int)(sigma * 6.0);
            size = size % 2 == 0 ? size + 1 : size;
            var center = size / 2;
            double[] valueArray = new double[size];

            for (int i = 0; i < size; i++)
            {
                var pos = -Math.Pow(Math.Abs(center - i), 2);
                double square = (double)pos / (2.0 * sigma * sigma);
                valueArray[i] = (1.0 / (sigma * Math.Sqrt(Math.PI * 2))) * Math.Pow(Math.E, square);
            }

            return valueArray;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            double[] resultArr = new double[signal.Length];
            var center = filter.Length / 2;

            for (int i = 0; i < resultArr.Length; i++)
            {
                double sum = 0d;
                for (int j = 0; j < filter.Length; j++)
                {
                    int index = i - (center - j);
                    double signalValue = index >= 0 && index < resultArr.Length ? signal[index] : 0;
                    sum += signalValue * filter[j];
                }
                resultArr[i] = sum;
            }

            return resultArr;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            var size = (int)(sigma * 6.0);
            size = size % 2 == 0 ? size + 1 : size;
            var center = size / 2;
            double[,] valueArray = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var pos = -(Math.Pow(Math.Abs(center - i), 2) +  Math.Pow(Math.Abs(center - j), 2));
                    double square = (double)pos / (2.0 * sigma * sigma);
                    valueArray[i, j] = (1.0 / (2.0 * Math.PI * sigma * sigma)) * Math.Pow(Math.E, square);
                }
            }

            return valueArray;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            Color pixelColor = bitmap.GetPixel(0,0);

            return null;
        }
    }
}