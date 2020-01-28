using System;
using System.Collections.Generic;
using System.Linq;

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
            var otherList = other.ToList();
            MultiSet set = new MultiSet();
            HashSet<string> tempSet = new HashSet<string> { };

            foreach (string element in mList)
            {
                tempSet.Add(element);
            }
            foreach (string element in otherList)
            {
                tempSet.Add(element);
            }

            foreach (string element in tempSet)
            {
                set.Add(element);

                uint nElementCount = this.GetMultiplicity(element);
                uint nElementOtherCount = other.GetMultiplicity(element);
                uint nMultiElement = nElementCount >= nElementOtherCount ? nElementCount : nElementOtherCount;

                for (uint i = set.GetMultiplicity(element); i < nMultiElement; i++)
                {
                    set.Add(element);
                }
            }
            
            return set;
        }

        public MultiSet Intersect(MultiSet other)
        {
            var otherList = other.ToList();
            var thisList = this.mList;
            MultiSet set = new MultiSet();
            List<string> tempList = new List<string> { };

            foreach (string otherElement in otherList)
            {
                foreach (string element in thisList)
                {
                    if (otherElement == element)
                    {
                        set.Add(element);
                        thisList.Remove(element);
                        break;
                    }
                }
            }

            return set;
        }

        public MultiSet Subtract(MultiSet other)
        {
            var otherList = other.ToList();
            var thisList = this.mList;
            MultiSet set = new MultiSet();
            List<string> tempList = new List<string> { };

            var diffList = thisList.FindAll(element => otherList.FindIndex(x => x == element) == -1);

            foreach (string element in diffList)
            {
                set.Add(element);
            }

            return set;
        }

        public List<MultiSet> FindPowerSet()
        {
            List<MultiSet> powerSet = new List<MultiSet> { };

            for (int i = 0; i < 1 << mList.Count; i++)
            {
                bool[] caseArray = getCaseBoolArray(i);
                int idx = 0;
                var subList = mList.FindAll(x => caseArray[idx++]);
                MultiSet powElement = new MultiSet();

                subList.ForEach(element => powElement.Add(element));

                var overlapList = powerSet.Where(element => element.ToList().SequenceEqual(subList));

                if (overlapList.Count() == 0)
                {
                    powerSet.Add(powElement);
                }
                
            }

            //Func<MultiSet, List<MultiSet>, bool> overlap = (finder, power) => 
            //powerSet.Where(finder => { (finder.ToList(), powerSet) => true};) ;

            return powerSet;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            return false;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            return false;
        }

        private bool[] shiftBoolArray(bool[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] && arr[i+1] == false)
                {
                    arr[i] = false;
                    arr[i + 1] = true;
                    return arr;
                }
            }

            arr[0] = true;
            return arr;
        }

        private bool[] getCaseBoolArray(int nNumber)
        {
            bool[] bPowerFlagArr = Enumerable.Repeat(false, mList.Count).ToArray();

            for (int i = 0; i < mList.Count; i++)
            {
                int nCase = 1 << i;
                if ((nNumber & nCase) == nCase)
                {
                    bPowerFlagArr[i] = true;
                }
            }

            return bPowerFlagArr;
        }

        private bool checkFalse(bool[] arr)
        {
            foreach (bool element in arr)
            {
                if (element == false)
                {
                    return true;
                }
            }

            return false;
        }

        public bool findEqual(MultiSet other)
        {
            return this.Subtract(other).ToList().Count > 0 ? true : false;
        }
    }
}