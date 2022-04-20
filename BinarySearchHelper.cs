using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public static class BinarySearchHelper
    {

        //1482. Minimum Number of Days to Make m Bouquets
        //1283. Find the Smallest Divisor Given a Threshold
        //1231. Divide Chocolate
        //1011. Capacity To Ship Packages In N Days
        //875. Koko Eating Bananas
        //774. Minimize Max Distance to Gas Station
        //410. Split Array Largest Sum
        //• 1802 Maximum Value at a Given Index in a Bounded Array
        //1539 Kth Missing Positive Number


        //From<https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/discuss/256729/JavaC%2B%2BPython-Binary-Search> 

        //BEST ONE TO Read

        //https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/discuss/769698/Python-Clear-explanation-Powerful-Ultimate-Binary-Search-Template.-Solved-many-problems.


        //1060. LeetCode Missing Element in Sorted Array, 
        //Input: nums = [4,7,9,10], k = 3
        //Output: 8
        //Explanation: The missing numbers are[5, 6, 8, ...], hence the third missing number is 8.
        // TODO: Binary Search
        // Only works when consecutive numbers
        public static int MissingNumber(int[] nums, int k)
        {
            int n = nums.Length, diff = 0;
            for (int i = 1; i < n; i++)
            {
                // Number of elements between 2 number is difference
                // between numbers -1
                diff = nums[i] - nums[i - 1] - 1;

                if (diff >= k)
                    return nums[i - 1] + k;

                // Reduce K
                k -= diff;
            }

            // Count K from last number
            return nums[n - 1] + k;
        }

        // 1228. Missing Number In Arithmetic Progression
        public static int MissingNumberBinarySearch(int[] arr)
        {
            int n = arr.Length;

            // 1. Get the difference `difference`.
            int difference = (arr[n - 1] - arr[0]) / n;
            int lo = 0;
            int hi = n - 1;

            // Basic binary search template.
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;

                // All numbers upto `mid` have no missing number, so search on the right side.
                if (arr[mid] == arr[0] + mid * difference)
                {
                    lo = mid + 1;
                }

                // A number is missing before `mid` inclusive of `mid` itself.
                else
                {
                    hi = mid;
                }
            }

            // Index `lo` will be the position with the first incorrect number.
            // Return the value that was supposed to be at this index.
            return arr[0] + difference * lo;


        }

        // 1011. Capacity To Ship Packages Within D Days
        public static int ShipWithinDays(int[] weights, int days)
        {
            int minCap = weights.Max();
            int maxCap = weights.Sum();

            while (minCap < maxCap)
            {
                // Guess the capacity required
                int cap = minCap + (maxCap - minCap) / 2;

                int total = 0;

                // Atleast 1 day taken 
                int daystaken = 1;

                foreach (var w in weights)
                {
                    // If total+curr weight > guessed capacity
                    if (total + w > cap)
                    {
                        total = w;
                        daystaken++;
                    }
                    else
                    {
                        total += w;
                    }

                }


                if (daystaken > days)
                {
                    // Increase minCap from guessed capacity as it didn'tw ork out
                    minCap = cap + 1;
                }
                else
                {
                    //Decrease maxCap 
                    maxCap = cap;
                }


            }

            return minCap;

        }

        // Return how many numbers are missing until nums[idx]
        // Important - Only when difference is 1
        private static int MissingNumbersTillIndex(int idx, int[] nums)
        {
            return nums[idx] - nums[0] - idx;
        }

        public static bool IsMajorityElement(int[] nums, int target)
        {

            int firstIndex = FindFirstIndex(nums, target, 0, nums.Length - 1);

            if (firstIndex == -1)
                return false;

            int lastIndex = FindLastIndex(nums, target, 0, nums.Length - 1);

            if (lastIndex - firstIndex + 1 > nums.Length / 2)
                return true;

            return false;
        }

        // Leetcode 34. Find First and Last Position of Element in Sorted Array
        public static int FindFirstIndex(int[] nums, int target, int l, int r)
        {
            if (l == r && nums[l] == target)
                return l;

            int result = -1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;


                if (nums[mid] == target)
                {
                    // Important
                    result = mid;
                    r = mid - 1;
                }
                else if (nums[mid] > target)
                {
                    r = mid - 1;

                }
                else if (nums[mid] < target)
                {
                    l = mid + 1;
                }


            }

            return result;

        }

        public static int FindLastIndex(int[] nums, int target, int l, int r)
        {
            if (l == r && nums[l] == target)
                return l;
            int result = -1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;


                if (nums[mid] == target)
                {
                    result = mid;
                    l = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    r = mid - 1;

                }
                else if (nums[mid] < target)
                {
                    l = mid + 1;
                }


            }

            return result;

        }

        /// <summary>
        ///  How many binary searchable numbers
        ///  Same as how many number greater on left and less than on right 
        ///  https://leetcode.com/discuss/interview-question/352743
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int HowManyBinarySearchable(int[] input)
        {
            int n = input.Length;
            if (n == 0)
            {
                return 0;
            }

            int[] maxLeft = new int[n];
            int[] minRight = new int[n];

            int maxTillNow = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                maxLeft[i] = maxTillNow;
                maxTillNow = Math.Max(input[i], maxTillNow);
            }

            int minTillNow = int.MaxValue;
            for (int i = n - 1; i >= 0; i--)
            {
                minRight[i] = minTillNow;
                minTillNow = Math.Min(input[i], minTillNow);
            }

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (input[i] > maxLeft[i] && input[i] < minRight[i])
                {
                    count++;
                }
            }

            return count;
        }


        //Find First and Last Position of Element in Sorted Array
        public static int[] SearchFirstLastInSortedArray(int[] nums, int target)
        {

            if (nums.Length == 0)
                return new int[] { -1, -1 };

            if (nums.Length == 1 && nums[0] == target)
                return new int[] { 0, 0 };

            int start = 0;
            int end = nums.Length - 1;

            int firstIndex = Search(nums, start, end, target);

            if (firstIndex == int.MaxValue)
                return new int[] { -1, -1 };

            int lastIndex = firstIndex;

            while (firstIndex - 1 >= 0 && nums[firstIndex - 1] == target)
            {
                firstIndex = Math.Min(Search(nums, start, firstIndex - 1, target), firstIndex);
            }


            while (lastIndex + 1 < nums.Length && nums[lastIndex + 1] == target)
            {
                int rigthlastIndex = Search(nums, firstIndex + 1, end, target);
                lastIndex = rigthlastIndex == int.MaxValue ? lastIndex : rigthlastIndex;
            }

            return new int[] { firstIndex, lastIndex };
        }

        public static int Search(int[] num, int start, int end, int target)
        {
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (num[mid] == target)
                {
                    return mid;
                }
                else if (num[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

            }

            return int.MaxValue;
        }

        public static int binarySearch(int[] arr, int l, int r, int x)
        {
            while (l <= r)
            {
                int m = (l + r) / 2;



                // Check if x is present at mid
                if (arr[m] == x)
                    return m;
                // If x greater, ignore left half
                else if (arr[m] > x)
                    r = m - 1;

                // If x is smaller, ignore right half
                else
                    l = m + 1;
            }

            // if we reach here, then element was
            // not present
            return -1;
        }

        public static int NumberOfTimesSortedArrayIsRotate(int[] arr)
        {
            int str = 0;
            int end = arr.Length - 1;
            int pivot = -1;
            int n = arr.Length;

            while (str <= end)
            {
                int mid = str + (end - str) / 2;

                //Important concept
                int prev = (mid - 1 + n) % n, next = (mid + 1) % n;
                //if first element is mid or
                //last element is mid then simply use modulo so it never goes out of bound.

                if (arr[prev] >= arr[mid] && arr[mid] <= arr[next])
                {
                    pivot = mid;
                    break;
                }

                // Important, if we change order of if else it does NOT work
                if (arr[mid] <= arr[end])
                {
                    end = mid - 1;
                }
                else if (arr[mid] >= arr[str])
                {
                    str = mid + 1;
                }

            }

            return arr.Length - pivot;
        }

        //Leetcode 33. Search in Rotated Sorted Array
        public static int SearchInRotatedSortedArray(int[] nums, int target)
        {

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {

                int mid = left + ((right - left) / 2);

                if (nums[mid] == target)
                    return mid;

                /// Means left is sorted array
                if (nums[left] <= nums[mid])
                {
                    //If target lies within sorted arrey, move right
                    if (target >= nums[left] && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (target > nums[mid] && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }


            return -1;

        }

        // 1891. Cutting K Ribbons of possible maximum size
        public static int MaxLength(int[] ribbons, int k)
        {

            int minLength = 1;
            System.Array.Sort(ribbons);
            int maxLength = ribbons[ribbons.Length - 1];

            while (minLength <= maxLength)
            {
                int mid = minLength + (maxLength - minLength) / 2;
                int numberOfRibbons = 0;

                for (int i = 0; i < ribbons.Length; i++)
                {
                    numberOfRibbons += ribbons[i] / mid;

                }

                if (numberOfRibbons < k)
                {
                    maxLength = mid - 1;
                }
                else
                {
                    minLength = mid + 1;
                }
            }

            return minLength - 1;

        }
    }
}
