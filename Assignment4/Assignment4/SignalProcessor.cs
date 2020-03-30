
using System.Drawing;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            var size = (int)(sigma * 6d);
            size = size % 2 == 0 ? size++; size;
            var center = size / 2;
            double[] valueArray = new double[] { };

            for (int i = 0; i < size; i++)
            {
                var pos = -Math.Pow(Math.Abs(center - i), 2);
                double square = pos / (2 * sigma * sigma)
                valueArray[i] = (1d / (sigma * Math.Sqrt(Math.PI * 2))) * Math.Pow(Math.E, square);
            }


            return null;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            return null;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            return null;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            return null;
        }
    }
}