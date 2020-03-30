using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 33, 43, 36, 35, 39, 38, 43, 34, 43, 39, 34, 43, 37, 33, 33, 38, 34, 43, 34, 41 };
            List<Tuple<Tuple<int, int>, int>> frequencyTable =  FrequencyTable.GetFrequencyTable(data, 6);

            Console.WriteLine("test: {0}", frequencyTable);
        }

        private static int getTotalCount(List<Tuple<Tuple<int, int>, int>>  frequencyTable)
        {
            int count = 0;

            foreach (var tup in frequencyTable)
            {
                count += tup.Item2;
            }

            return count;
        }
    }
}