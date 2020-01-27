using System.Collections.Generic;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> mList = new List<string> {};

        public void Add(string element)
        {
            mList.Add(element);

            mList.Sort();
        }

        public bool Remove(string element)
        {
            return mList.Remove(element);
        }

        public uint GetMultiplicity(string element)
        {
            var list = mList.FindAll(x => x == element);

            return (uint)list.Count;
        }

        public List<string> ToList()
        {
            return mList;
        }

        public MultiSet Union(MultiSet other)
        {
            return null;
        }

        public MultiSet Intersect(MultiSet other)
        {
            return null;
        }

        public MultiSet Subtract(MultiSet other)
        {
            return null;
        }

        public List<MultiSet> FindPowerSet()
        {
            return null;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            return false;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            return false;
        }
    }
}