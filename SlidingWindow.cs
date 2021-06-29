using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{

    /// <summary>
    ///  Problem related to these will ask for subarray or substring as these are continous
    ///  Will ask for largest/smallest
    ///  A window size will be given 
    ///  Type of questions:-
    ///  1) Fixed size window - 
    ///  2) Varaible window size - Largest windows or smallest window subjected to condition 
    /// </summary>

    public class SlidingWindow
    {
        // i = 0; j = 0;
        //Sliding widow generic code with fixed widow size
        // while(j<size)
        //{
        //    //Do calc - like creating sum or pushing into list
        //  sum+=a[j];

        //if(j-i+1<k)
        //{
        //  j++;// only increase j
        //}
        //else if( j-i+1==k}
        //{
        //    calculate ans 

        //     recalcualte or remove from ans
        //Sum -=a[i];

        //}
        //    i++;
        //    j++;
        //}

        // Max target Sum array is done with hash, here we do not have target but window
        public static void MaxSumSubArrayInKWindow(int[] a, int k)
        {
            if (a.Length < k)
                return;

            int maxSum = 0;
            int currentSum = 0;
            int i = 0;
            while (i < k)
            {
                currentSum += a[i];
                i++;
            }

            maxSum = currentSum;

            while (i <= a.Length - 1)
            {
                currentSum += a[i] - a[i - k];

                maxSum = Math.Max(currentSum, maxSum);
                i++;
            }

            Console.WriteLine($"Max subarray sum {maxSum}");
        }


        // Approach does not work with queue but need double en queue
        public static void MaxInAllSubArrayInWindow(int[] a, int k)
        {
            int i = 0;
            int j = 0;
            Queue<int> q = new Queue<int>();

            while (j < a.Length)
            {
                // { 3,1,2, 4, 20, 12 }
                // Anything less than a[j] should be poped out
                while (q.Count > 0 && q.Peek() < a[j])
                {
                    q.Dequeue();
                }

                q.Enqueue(a[j]);

                // We are less than widow size
                if (j + 1 - i < k)
                {
                    j++;
                }
                else if (j + 1 - i == k) // We are hitting window size
                {
                    if (q.Count > 0)
                    {
                        Console.WriteLine(q.Peek());
                    }

                    // Maintain Calculation 
                    if (a[i] == q.Peek())
                    {
                        q.Dequeue();
                    }

                    //  Move window
                    i++;
                    j++;

                }


            }
        }


        // Sliding window with variable window
        // This does not handle -ve need to use hashmap, see in hash class  
        public static void MaxTargetSumArray(int[] a, int targetsum)
        {
            int i = 0;
            int j = 0;
            int sum = 0;
            int len = 0;

            while (j < a.Length)
            {
                sum += a[j];

                if (sum < targetsum)
                {
                    j++;
                }

                else if (sum == targetsum)
                {
                    len = Math.Max(len, j - i + 1);
                    j++;
                }
                // this case never occurs in sliding window with fixed len
                else if (sum > targetsum)
                {
                    while (sum > targetsum)
                    {
                        sum -= a[i];
                        i++;
                    }
                    j++;
                }


            }

            Console.WriteLine(len);

        }


        public static void LongestSubstringWithoutRepeatingChar(string s)

        {
            int maxLen = int.MinValue;

            int i = 0;
            int j = 0;
            string newstring = string.Empty;
            string lcs = null;

            while (j < s.Length)
            {
                char c = s[j];

                if (newstring.IndexOf(c) != -1)
                {
                    maxLen = Math.Max(newstring.Length, maxLen);

                    int index = newstring.IndexOf(c);
                    newstring = newstring.Remove(0, index + 1);

                    i = i + index;

                    newstring += c;
                }
                else
                {
                    newstring += c;
                    maxLen = Math.Max(newstring.Length, maxLen);
                    if (maxLen == newstring.Length)
                    {
                        lcs = newstring;

                    }
                }



                j++;
            }

            Console.WriteLine($"Longest Unique char substring {lcs } has length " + maxLen);
        }

        public static void LongestSubstringWithKUniqueChar(string s, int k)

        {
            int maxLen = int.MinValue;

            int i = 0;
            int j = 0;
            string ans = null;
            Dictionary<char, int> dc = new Dictionary<char, int>();

            while (j < s.Length)
            {

                if (dc.ContainsKey(s[j]))
                {
                    dc[s[j]]++;
                }
                else
                {
                    dc.Add(s[j], 1);
                }

                if (dc.Keys.Count == k)
                {
                    int total = 0;
                  
                    maxLen = Math.Max(maxLen, j-i+1);

                    if (maxLen == j-i+1)
                    {
                        ans = s.Substring(i, j + 1);
                    }
                }

                if (dc.Keys.Count > k)
                {
                    while (dc.Keys.Count > k)
                    {
                        dc[s[i]]--;

                        if (dc[s[i]] == 0)
                            dc.Remove(s[i]);

                        i++;
                    }
                }

                j++;

            }

            Console.WriteLine(ans);
        }
    }


}

