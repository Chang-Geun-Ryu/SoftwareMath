﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> StringList = new List<string> { };

        public void Add(string element)
        {
            StringList.Add(element);

            StringList.Sort();
        }

        public bool Remove(string element)
        {
            return StringList.Remove(element);
        }

        public uint GetMultiplicity(string element)
        {
            var list = StringList.FindAll(x => x == element);

            return (uint)list.Count;
        }

        public List<string> ToList()
        {
            return StringList;
        }

        public MultiSet Union(MultiSet other)
        {
            var otherList = other.ToList();
            MultiSet set = new MultiSet();
            HashSet<string> tempSet = new HashSet<string> { };

            foreach (string element in StringList)
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
            var thisList = new List<string>(StringList);
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
            var thisList = new List<string>(StringList);
            MultiSet set = new MultiSet();
            List<string> tempList = new List<string> { };

            //var diffList = thisList.FindAll(element => otherList.FindIndex(x => x == element) == -1);
            foreach (string deletElement in otherList)
            {
                foreach (string element in thisList)
                {
                    if (deletElement == element)
                    {
                        thisList.Remove(deletElement);
                        break;
                    }
                }
            }

            foreach (string element in thisList)
            {
                set.Add(element);
            }

            return set;
        }

        public List<MultiSet> FindPowerSet()
        {
            List<MultiSet> powerSet = new List<MultiSet> { };

            for (int i = 0; i < 1 << StringList.Count; i++)
            {
                bool[] caseArray = getCaseBoolArray(i);
                int idx = 0;
                var subList = StringList.FindAll(x => caseArray[idx++]);
                MultiSet powElement = new MultiSet();

                subList.ForEach(element => powElement.Add(element));

                var overlapList = powerSet.Where(element => element.ToList().SequenceEqual(subList));

                if (overlapList.Count() == 0)
                {
                    powerSet.Add(powElement);
                }
            }

            powerSet.Sort(sortMultiSet);

            return powerSet;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            var otherList = new List<string>(other.ToList());
            var thisList = new List<string>(StringList);

            foreach (string element in thisList)
            {
                bool bCheck = false;
                foreach (string otherElement in otherList)
                {
                    if (element == otherElement)
                    {
                        bCheck = true;
                        otherList.Remove(element);
                        break;
                    }
                }

                if (bCheck)
                {
                    continue;
                }
                
                return false;
            }
            
            return true;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            return other.IsSubsetOf(this);
        }

        private bool[] shiftBoolArray(bool[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] && arr[i + 1] == false)
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
            bool[] bPowerFlagArr = Enumerable.Repeat(false, StringList.Count).ToArray();

            for (int i = 0; i < StringList.Count; i++)
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

        private bool findEqual(MultiSet other)
        {
            return this.Subtract(other).ToList().Count > 0 ? true : false;
        }

        private int sortMultiSet(MultiSet x, MultiSet y)
        {
            var xArr = x.ToList().ToArray();
            var yArr = y.ToList().ToArray();

            
            int size = xArr.Length - yArr.Length >= 0 ? yArr.Length : xArr.Length;

            for (int idx = 0; idx < size; idx++)
            {
                var compare = xArr[idx].CompareTo(yArr[idx]);

                if (compare != 0)
                    return compare;
            }

            if (xArr.Length == yArr.Length)
            {
                return 0;
            }
            else if (xArr.Length < yArr.Length)
            {
                return -1;
            }

            return 1;
        }
    }
}