using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    public static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> list, EFeatureFlags features)
        {
            return list.FindAll(p => (p.Features & features) != EFeatureFlags.Default);
        }

        public static List<Frame> FilterOutFrames(List<Frame> list, EFeatureFlags features)
        {
            return list.FindAll(p => (p.Features & features) == EFeatureFlags.Default);
        }

        public static List<Frame> Intersect(List<Frame> list1, List<Frame> list2)
        {
            return list1.FindAll(p1 => list2.Find(p2 => p2.ID == p1.ID) != null ? true : false);
        }

        public static List<int> GetSortKeys(List<Frame> list, List<EFeatureFlags> featureList)
        {
            return list.ConvertAll(p => 
                {
                    int nMatch = -1;
                    int nPriority = featureList.Count - 1;
                    int nSortKey = 0;

                    featureList.ForEach(
                        feature => 
                        {
                            if ((feature & p.Features) != EFeatureFlags.Default)
                            {
                                nMatch++;
                                nSortKey |= 1 << nPriority;
                            }
                            nPriority--;
                            Console.WriteLine($"bit: {Convert.ToString(nSortKey, 2).PadLeft(32, '0')}");
                        });
                    
                    nSortKey |= nMatch == -1 ? 0 : (1 << featureList.Count + nMatch);
                    Console.WriteLine($"result5: {Convert.ToString(nSortKey, 2).PadLeft(32, '0')}");
                    Console.WriteLine($"p: {p.Name}, p Count: {featureList.Count}, nMatch: {nMatch}, sortKey: {nSortKey}");
                    return nSortKey;
                });
        }

        // public static List<int> GetSortKeys(List<Frame> list, List<EFeatureFlags> featureList)
        // {
        //     return list.ConvertAll(p => 
        //         {
        //             int nMatch = 0;
        //             int nPriority = featureList.Count;
        //             int nSortKey = 0;

        //             featureList.ForEach(
        //                 feature => 
        //                 {
        //                     if ((feature & p.Features) != EFeatureFlags.Default)
        //                     {
        //                         nMatch++;
        //                         nSortKey += nPriority;
        //                     }
        //                     nPriority--;
        //                     Console.WriteLine($"bit: {Convert.ToString(nSortKey, 2).PadLeft(32, '0')}");
        //                 });
                    
        //             nSortKey |= nMatch == 0 ? 0 : (1 << featureList.Count + nMatch);
        //             Console.WriteLine($"result5: {Convert.ToString(nSortKey, 2).PadLeft(32, '0')}");
        //             Console.WriteLine($"p: {p.Name}, p Count: {featureList.Count}, nMatch: {nMatch}, sortKey: {nSortKey}");
        //             return nSortKey;
        //         });
        // }

    }
}