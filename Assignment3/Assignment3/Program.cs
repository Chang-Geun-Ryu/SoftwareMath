using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> expectedValue1 = new List<int> { 100, 102, 112, 114, 116, 118, 120, 123, 125, 127, 130, 132, 135, 137, 139, 141, 143, 146, 148, 150, 153, 155, 158, 160, 162, 165, 167, 170 };
            List<int> expectedValue2 = new List<int> { 100, 102, 112, 115, 117, 120, 122, 124, 127, 129, 132, 134, 136, 139, 141, 143, 145, 147, 150, 152, 155, 157, 159, 162, 164, 166, 168, 170 };
            List<int> expectedValue3 = new List<int> { 100, 102, 112, 115, 116, 117, 117, 123, 122, 124, 128, 132, 138, 139, 143, 146, 151, 151, 161, 170 };

            int[] steps = new int[] { 100, 102, 112, 170 };

            INoise noise = new ZeroNoise();
            // List<int> newSteps = StepMaker.MakeSteps(steps, noise);

            // Debug.Assert(expectedValue1.Count == newSteps.Count);

            // for (int i = 0; i < expectedValue1.Count; i++)
            // {
            //     Debug.Assert(expectedValue1[i] == newSteps[i]);
            // }

            // noise = new ConstantNoise();
            // newSteps = StepMaker.MakeSteps(steps, noise);

            // Debug.Assert(expectedValue2.Count == newSteps.Count);

            // for (int i = 0; i < expectedValue2.Count; i++)
            // {
            //     Debug.Assert(expectedValue2[i] == newSteps[i]);
            // }

            noise = new SineNoise();
            List<int> arr = new List<int> {0,1,2,3,4,5,6,7,8,9};
            arr.ForEach(p => Console.WriteLine("{1}noise: {0}", noise.GetNext(p), p));
            
            noise = new SineNoise();
            List<int> newSteps = StepMaker.MakeSteps(steps, noise);

            Debug.Assert(expectedValue3.Count == newSteps.Count);

            for (int i = 0; i < expectedValue3.Count; i++)
            {
                Debug.Assert(expectedValue3[i] == newSteps[i]);
            }

        }
    }
}

namespace Assignment3
{
    public sealed class ZeroNoise : INoise
    {
        public int GetNext(int level)
        {
            return 0;
        }
    }
}
namespace Assignment3
{
    public sealed class ConstantNoise : INoise
    {
        public int GetNext(int level)
        {
            return 1;
        }
    }
}

namespace Assignment3
{
    public sealed class SineNoise : INoise
    {
        private const double BASE_SAMPLING_WIDTH = Math.PI / 4;
        private double mX = -BASE_SAMPLING_WIDTH;

        public int GetNext(int level)
        {
            mX += BASE_SAMPLING_WIDTH / Math.Pow(2, level);
            return (int)(5 * Math.Sin(mX));
        }
    }
}


namespace Assignment3
{
    public sealed class CosineNoise : INoise
    {
        private const double BASE_SAMPLING_WIDTH = Math.PI / 4;
        private double mX = -BASE_SAMPLING_WIDTH;

        public int GetNext(int level)
        {
            mX += BASE_SAMPLING_WIDTH / Math.Pow(2, level);
            return (int)(5 * Math.Cos(mX));
        }
    }
}