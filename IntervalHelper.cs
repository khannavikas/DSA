using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class IntervalHelper
    {
        // Leetcode 986
        // Important
        public static int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            int l1 = 0;
            int l2 = 0;

            List<int[]> lst = new List<int[]>();

            while (l1 < firstList.Length && l2 < secondList.Length)
            {

                int st = Math.Max(firstList[l1][0], secondList[l2][0]);
                int end = Math.Min(firstList[l1][1], secondList[l2][1]);

                // Important
                if (st <= end)
                    lst.Add(new int[] { st, end });

                if (firstList[l1][1] > secondList[l2][1])
                {
                    l2++;
                }
                else if (firstList[l1][1] < secondList[l2][1])
                {
                    l1++;
                }
                else
                {
                    l1++;
                    l2++;
                }
            }

            return lst.ToArray();
        }

        public static List<int[]> MergeInterval(int[][] a)
        {
            int[] start = new int[a.Length];
            int[] end = new int[a.Length];

            for (int k = 0; k < a.Length; k++)
            {
                start[k] = a[k][0];
                end[k] = a[k][1];
            }

            List<int[]> lis = new List<int[]>();
            System.Array.Sort(start);
            System.Array.Sort(end);


            for (int i = 0, j = 0; i < a.Length; i++)
            { // j is start of interval.
              // Compare start of next to end of previous
              // If last start or start after next end
                if (i == a.Length - 1 || start[i + 1] > end[i])
                {
                    // Difficult part to understand
                    lis.Add(new int[] { start[j], end[i] });
                    j = i + 1;
                }
            }

            return lis;
        }

        private class InvComparer : IComparer<Interval>
        {
            public int Compare(Interval x, Interval y)
            {
                // Ascending order
                if (x.Start > y.Start)
                    return 1;
                if (x.Start < y.Start)
                    return -1;

                return 0;
            }
        }

        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        public static List<int[]> MergeIntervals(List<Interval> invs)
        {
            invs.Sort(new InvComparer());

            Stack<Interval> s = new Stack<Interval>();

            s.Push(invs.First());

            for (int i = 1; i < invs.Count; i++)
            {
                var x = s.Peek();

                if (invs[i].Start < x.End)
                {
                    x.End = Math.Max(x.End, invs[i].End);
                    s.Pop();
                    s.Push(x);
                }
                else
                {
                    s.Push(invs[i]);

                }
            }

            List<int[]> ls = new List<int[]>();
            while (s.Count > 0)
            {
                var y = s.Pop();
                ls.Add(new int[] { y.Start, y.End });
            }
            return ls;
        }


        //List<Interval> ai = new List<Interval>();
        //ai.Add(new Interval() { Start = 1, End = 2 });
        //ai.Add(new Interval() { Start = 5, End = 6 });


        //List<Interval> bi = new List<Interval>();
        //bi.Add(new Interval() { Start = 4, End = 6 });
        //    bi.Add(new Interval() { Start = 8, End = 10 });

        //    IntervalHelper.MergeIntervalList(ai, bi);

        public static List<Interval> MergeSortedIntervalList(List<Interval> A, List<Interval> B)
        {
            List<Interval> res = new List<Interval>();
            int m = A.Count(), n = B.Count();
            int i = 0, j = 0;
            while (i < m || j < n)
            {
                if (i == m)
                {
                    res.Add(B[j]);
                    j++;
                }
                else if (j == n)
                {
                    res.Add(A[i]);
                    i++;
                }
                else if (A[i].Start < B[j].Start)
                {
                    res.Add(A[i]);
                    i++;
                }
                else res.Add(B[j++]);
            }
            return res;

           
        }


        public class Log
        {
            public string id;
            public int time;
            public int childtime;
        }


        public static int[] ExclusiveTime(int n, IList<string> logs)
        {

            Stack<Log> stk = new Stack<Log>();
            int[] result = new int[n];
            foreach (string s in logs)
            {

                string[] split = s.Split(':');

                if (split[1] == "start")
                {
                    stk.Push(new Log() { id = split[0], time = Convert.ToInt32(split[2]) });

                }
                else
                {

                    var p = stk.Pop();
                    result[Convert.ToInt32(split[0])] = Convert.ToInt32(split[2]) - p.time - p.childtime + 1;
                    int t = result[Convert.ToInt32(split[0])];
                    string preid = p.id;

                    if (stk.Count > 0)
                    {
                        p = stk.Pop();

                        if (p.id != preid)
                        {
                            p.childtime += t;
                        }
                        stk.Push(p);
                    }
                }

            }

            return result;

        }

        // 253. Meeting Rooms II - This is same as minimum number of platforms required for trains

        public static int MinMeetingRooms(int[][] intervals)
        {

            int[] starttimes = new int[intervals.Length];
            int[] endtimes = new int[intervals.Length];


            for (int i = 0; i < intervals.Length; i++)
            {
                starttimes[i] = intervals[i][0];
                endtimes[i] = intervals[i][1];
            }


            System.Array.Sort(starttimes);
            System.Array.Sort(endtimes);


            int strt = 0;
            int end = 0;
            int numrooms = 0;

            while (strt < intervals.Length)
            {
                // Start is Greater or equal to last end, so vacate a room and move to next end
                if (starttimes[strt] >= endtimes[end])
                {
                    numrooms--;
                    end++;
                }

                // Always increase room for each meeting 
                numrooms++;
                strt++;

            }

            return numrooms;
        }


        //Important how to merge sort on List of List 
        public static List<Interval> MergeSort(List<List<Interval>> schedule, int l, int r)
        {
            if (l == r) return schedule[l];
            int mid = (l + r) / 2;
            List<Interval> left = MergeSort(schedule, l, mid);
            List<Interval> right = MergeSort(schedule, mid + 1, r);
            return MergeSortedIntervalList(left, right);
        }

    }
}
