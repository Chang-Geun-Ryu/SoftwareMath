﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void ss()
        {
            MultiSet set1 = new MultiSet();
            MultiSet set2 = new MultiSet();

            set1.Add("a");
            set1.Add("b");
            set1.Add("b");

            set2.Add("a");
            set2.Add("b");
            set2.Add("c");
            set2.Add("b");
            set2.Add("a");

            set1.IsSubsetOf(set2); // true
            set2.IsSubsetOf(set1); // false
        }

        static void dd()
        {
            MultiSet set1 = new MultiSet();
            MultiSet set2 = new MultiSet();

            set1.Add("a");
            set1.Add("a");
            set1.Add("b");
            set1.Add("d");

            set2.Add("d");
            set2.Add("b");
            set2.Add("a");

            set1.IsSupersetOf(set2); // true
            set2.IsSupersetOf(set1); // false
        }

        static void Main(string[] args)
        {
            ss();
            dd();

            //MultiSet set = new MultiSet();

            //set.Add("cattle");
            //set.Add("bee");
            //set.Add("cattle");
            //set.Add("bee");
            //set.Add("happy");
            //set.Add("zachariah");

            //Debug.Assert(set.Remove("zachariah"));
            //Debug.Assert(!set.Remove("fun"));

            //Debug.Assert(set.GetMultiplicity("cattle") == 2);

            //List<string> expectedList = new List<string> { "bee", "bee", "cattle", "cattle", "happy" };
            //List<string> list = set.ToList();

            //Debug.Assert(list.Count == 5);

            //for (int i = 0; i < expectedList.Count; i++)
            //{
            //    Debug.Assert(expectedList[i] == list[i]);
            //}

            //MultiSet set2 = new MultiSet();

            //set2.Add("cattle");
            //set2.Add("cattle");
            //set2.Add("bee");

            //list = set.Union(set2).ToList();
            //Debug.Assert(list.Count == 5);

            //for (int i = 0; i < expectedList.Count; i++)
            //{
            //    Debug.Assert(expectedList[i] == list[i]);
            //}

            //expectedList = new List<string> { "bee", "cattle", "cattle" };
            //list = set.Intersect(set2).ToList();
            //Debug.Assert(list.Count == 3);

            //for (int i = 0; i < expectedList.Count; i++)
            //{
            //    Debug.Assert(expectedList[i] == list[i]);
            //}

            //expectedList = new List<string> { "bee", "happy" };
            //list = set.Subtract(set2).ToList();
            //Debug.Assert(list.Count == 2);

            //for (int i = 0; i < expectedList.Count; i++)
            //{
            //    Debug.Assert(expectedList[i] == list[i]);
            //}

            //List<MultiSet> expectedPowerset = getExpectedPowerset();
            //List<MultiSet> set2PowerSet = set2.FindPowerSet();
            //Debug.Assert(set2PowerSet.Count == expectedPowerset.Count);

            //for (int i = 0; i < expectedPowerset.Count; i++)
            //{
            //    expectedList = expectedPowerset[i].ToList();
            //    list = set2PowerSet[i].ToList();

            //    Debug.Assert(expectedList.Count == list.Count);

            //    for (int j = 0; j < expectedList.Count; j++)
            //    {
            //        Debug.Assert(expectedList[j] == list[j]);
            //    }
            //}

            //Debug.Assert(!set.IsSubsetOf(set2));
            //Debug.Assert(set.IsSupersetOf(set2));
        }

        private static List<MultiSet> getExpectedPowerset()
        {
            List<MultiSet> powerset = new List<MultiSet>();

            MultiSet set = new MultiSet();
            powerset.Add(set);

            set = new MultiSet();
            set.Add("bee");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("bee");
            set.Add("cattle");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("bee");
            set.Add("cattle");
            set.Add("cattle");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("cattle");

            powerset.Add(set);

            set = new MultiSet();
            set.Add("cattle");
            set.Add("cattle");

            powerset.Add(set);

            return powerset;
        }
    }
}
