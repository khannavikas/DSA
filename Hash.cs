using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class Hash
    {
        public int LongestSubarrayDivisibleByK(int[] a, int k)
        {

            // idea here is store are remainder for sum/k in hash with first index
            // If we again get same remainder then difference between the indexes will be length
            // Beacuse s1 =kn+x and s2 = km+x then s1-s2 = k(n-m), so array between same 
            // remainder is divsible by k
            int maxLength = 0;

            int sum = 0;

            Dictionary<int, int> remainderIndex = new Dictionary<int, int>();

            // Reminder 0 is at -1 index
            remainderIndex.Add(0, -1);

            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];

                int rem = sum % k;

                if (rem < k)
                    rem = rem + k;

                if (remainderIndex.ContainsKey(rem))
                {
                    // Don't update index just the result
                    int len = i - remainderIndex[rem];
                    maxLength = Math.Max(len, maxLength);
                }
                else
                {
                    // Save first index and remainder
                    remainderIndex.Add(rem, i);
                }

            }

            return maxLength;
        }

        public int LongestSubarrayWithSumZero(int[] a)
        {

            //  int ans = 0;
            int sum = 0;
            int maxLength = 0;
            Dictionary<int, int> sumIndex = new Dictionary<int, int>();
            sumIndex.Add(0, -1);
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];

                if (!sumIndex.ContainsKey(sum))
                {
                    sumIndex.Add(sum, i);
                }
                else
                {
                    int index = sumIndex[sum];
                    maxLength = Math.Max(maxLength, i - index);
                }

               // When sum is not 0 then find currentSum - sum has occured previously ornot


                // a) Current element is 0
                // b) sum of elements from 0 to i is 0
                // c) sum is already present in hash set
                //if (arr[i] == 0
                //    || sum == 0
                //    || hs.Contains(sum))
                //    return true;

                //// Add sum to hash set
                //hs.Add(sum);

            }

            return maxLength;
        }

        public int LongestIncreasingConsecutiveSubsequence(int[] a)
        {
            Dictionary<int, int> hashSequenceSoFar = new Dictionary<int, int>();

            int max = 0;
            //  hashSequenceSoFar.Add(0, -1);

            for (int i = 0; i < a.Length; i++)
            {
                if (hashSequenceSoFar.ContainsKey(a[i] - 1))
                {
                    hashSequenceSoFar.Add(a[i], hashSequenceSoFar[a[i] - 1] + 1);
                }
                else
                {
                    hashSequenceSoFar.Remove(a[i]);
                    hashSequenceSoFar.Add(a[i], 1);
                }
            }

            foreach (int value in hashSequenceSoFar.Values)
            {
                max = Math.Max(max, value);
            }

            return max;
        }

        public int LongestConsecutiveSequenceNoOrder(int[] a)
        {
            int mx = 0;

            Dictionary<int, bool> hs = new Dictionary<int, bool>();

            for (int i = 0; i < a.Length; i++)
            {
                hs.Add(a[i], true);
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (hs.ContainsKey(a[i] - 1))
                    hs[a[i]] = false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                int j = a[i];
                int count = 0;

                if (hs[j])
                {
                    while (hs.ContainsKey(j))
                    {
                        j++;
                        count++;
                    }

                    mx = Math.Max(count, mx);
                }

            }

            return mx;
        }

        // Another way sum zero 
        public int MaxLen(int[] arr)
        {
            // Creates an empty hashMap hM
            Dictionary<int, int> hM = new Dictionary<int, int>();

            int sum = 0; // Initialize sum of elements
            int max_len = 0; // Initialize result

            // Traverse through the given array
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                // Add current element to sum
                sum += arr[i];

                if (arr[i] == 0 && max_len == 0)
                    max_len = 1;

                if (sum == 0)
                    max_len = i + 1;

                // Look this sum in hash table
                int prev_i = 0;
                if (hM.ContainsKey(sum))
                {
                    prev_i = hM[sum];
                }

                // If this sum is seen before, then update max_len
                // if required
                if (hM.ContainsKey(sum))
                    max_len = Math.Max(max_len, i - prev_i);
                else
                {
                    // Else put this sum in hash table
                    if (hM.ContainsKey(sum))
                        hM.Remove(sum);

                    hM.Add(sum, i);
                }
            }

            return max_len;
        }


        //Check If An Array Can Be Divided Into Pairs Whose Sum Is Divisible By K
        public bool CanAllArrayPairsDivisibleByK(int[] a, int k)
        {
            Dictionary<int, int> remainderFreq = new Dictionary<int, int>();
            //  bool isPossible = false;

            foreach (var item in a)
            {
                int rem = item % k;

                if (remainderFreq.ContainsKey(rem))
                {
                    remainderFreq[rem]++;
                }
                else
                {
                    remainderFreq.Add(rem, 1);
                }
            }

            foreach (var item in a)
            {
                int rem = item % k;

                if (rem == 0)
                {
                    // Freqency with 0 remainder should be even
                    if (remainderFreq[rem] % 2 != 0)
                        return false;
                }
                else if (2 * rem == k)
                {
                    // Frequency with k/2 should be even e.g. 5 and 5 - 2 times
                    if (remainderFreq[rem] % 2 != 0)
                        return false;
                }
                else
                {
                    // Freq of remainder x and K-x remainder should be same to make a pair.
                    int freRem = remainderFreq[rem];
                    int freRemK = remainderFreq[k - rem];

                    if (freRem != freRemK)
                        return false;

                }

            }


            return true;

        }


        #region Hasstring Unique char

       public static string GetKey(String str)
        {
            bool[] visited = new bool[26];

            // Store all unique characters of current
            // word in key
            for (int j = 0; j < str.Length; j++)
                visited[str[j] - 'a'] = true;

            string key = "";

            // this sorts them
            for (int j = 0; j < 26; j++)
                if (visited[j])
                    key = key + (char)('a' + j);

            return key;
        }

        #endregion

        public int MintargetSubArrayLen(int target, int[] nums)
        {

            Dictionary<int, int> sum = new Dictionary<int, int>();

            int len = int.MaxValue;

            int currSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] == target)
                    return 1;

                currSum += nums[i];

                // If currensum - target is there then in between sum equals target
                if (sum.ContainsKey(currSum - target))
                {
                    int index = sum[currSum - target];

                    int newIndex = i - index;

                    len = Math.Min(newIndex, len);
                }

                // is sum = taget then it is starting from 0
                if (currSum == target)
                {
                    len = Math.Min(len, i + 1);
                }

                // Add sum till index i in dictionary
                sum.Add(currSum, i);

            }

            return (len == int.MaxValue) ? 0 : len;
        }
    }
}
