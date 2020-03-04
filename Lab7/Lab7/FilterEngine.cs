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
                    int nMatch = 0;
                    int nPriority = 7;
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
                        });
                    
                    nSortKey |= (1 << 8 + nMatch);

                    Console.WriteLine($"p: {p.Name}, nMatch: {nMatch}, sortKey: {nSortKey}");
                    return nSortKey;
                } );
            //return new List<int> {0,1,2,3,4,5,6};
        }

    }
}