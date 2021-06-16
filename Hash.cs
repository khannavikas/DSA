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

            }

            return maxLength;
        }

        // Anot
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
    }
}
