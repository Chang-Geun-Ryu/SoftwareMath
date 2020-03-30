using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    public static class FrequencyTable
    {
        public static List<Tuple<Tuple<int, int>, int>> GetFrequencyTable(int[] data, int maxBinCount)
        {
            if (data.Length < 1) 
            {
                return null;
            }

            List<Tuple<Tuple<int, int>, int>> table = new List<Tuple<Tuple<int, int>, int>> { };

            var numbers = new List<int>(data);
            int nBinSize = (int)Math.Ceiling((double)(numbers.Max() - numbers.Min()) / (double)maxBinCount);
            nBinSize = nBinSize == 0 ? 1 : nBinSize;

            while (numbers.Min() + nBinSize * maxBinCount <= numbers.Max())
            {
                Console.WriteLine("nBinSize: {0}", nBinSize);
                nBinSize++;
            }

            Tuple<int, int> range = new Tuple<int, int>(numbers.Min(), numbers.Min() + nBinSize);

            for (int i = 0; i < maxBinCount; i++)
            {
                int nCount = numbers.FindAll(p => (p >= range.Item1) && (p < range.Item2)).Count;
                table.Add(Tuple.Create(range, nCount));

                range = Tuple.Create(range.Item1 + nBinSize,
                                    range.Item2 + nBinSize);

                int nCount2 = numbers.FindAll(p => p >= range.Item1).Count;

                if (nCount2 == 0) 
                {
                    Console.WriteLine("break: {0}", table);
                    break;
                }
            }
            
            return table;
        }
    }
}