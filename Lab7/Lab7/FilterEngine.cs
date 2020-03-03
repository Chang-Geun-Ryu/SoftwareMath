using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> list, EFeatures features)
        {
            return list.FindAll(p => (p.Features & features) != EFeatures.Default);
        }

        public static List<Frame> FilterOutFrames(List<Frame> list, EFeatures features)
        {
            return list.FindAll(p => (p.Features & features) == EFeatures.Default);
        }

        public static List<Frame> Intersect(List<Frame> list1, List<Frame> list2)
        {
            return list1.FindAll(
                p1 => list2.Find(p2 => p2.ID == p1.ID) != null ? true : false
            );
        }

        public static List<int> GetSortKeys(List<Frame> list, List<EFeatures> featureList)
        {
            
            return new List<int> {0,1,2,3,4,5,6};
        }

    }
}