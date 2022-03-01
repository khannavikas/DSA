using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace CCIFinal.Array
{
    public class ArrayFunc
    {

        //TO DO: Minimun swap required for sorting 

        public static int[] ReverseArray(int[] a)
        {
            int start = 0;
            int end = a.Length - 1;

            while (start < end)
            {
                int temp = a[start];
                a[start] = a[end];
                a[end] = temp;
                start++;
                end--;
            }

            return a;
        }

        public static int SearchSortedRotatedArray(int[] a, int search)
        {
            int start = 0;
            int end = a.Length - 1;

            // 5671234

            while (start < end)
            {
                int mid = start + end / 2;
                if (a[mid] == search)
                {
                    return mid;
                }

                if (a[mid] > search && a[start] < a[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }


            }

            return -1;
        }

        public static int[] Rotate(int[] s, int d)
        {
            int x = 0;

            for (int i = 0; i < d; i++)
            {

                x = s[0];

                for (int m = 0; m < s.Length - 1; m++)
                {
                    s[m] = s[m + 1];

                }

                s[s.Length - 1] = x;

            }

            return s;
        }

       

        public static int[] MovePositiveNegative(int[] a)
        {

            int str = 0;
            int end = a.Length - 1;

            while (str < end)

            {
                if (a[str] < 0 && a[end] > 0)
                {
                    int tem = a[str];
                    a[str] = a[end];
                    a[end] = tem;
                    str++;
                    end--;

                }
                else
                if (a[str] < 0 && a[end] < 0)
                {
                    end--;
                }
                else
                {
                    str++;
                }
            }

            return a;
        }

        public static int SwapRequiredAllLessThanKTogether(int[] a, int k)
        {

            int strt = 0;
            int end = a.Length - 1;
            int swaps = 0;

            while (strt < end)

            {
                if (a[strt] <= k)
                {
                    strt++;
                }
                if (a[end] > k)
                {
                    end--;
                }

                else if (a[strt] > k && a[end] <= k)
                {
                    int temp = a[strt];
                    a[strt] = a[end];
                    a[end] = temp;
                    swaps++;
                    strt++;
                    end--;
                }
            }

            return swaps;
        }

        public static int[] RearrangeEvenGreaterThanOdd(int[] a)
        {

            if (a.Length <= 1)
            {
                return a;
            }

            int strt = 1;
            int end = a.Length - 1;

            while (strt <= end)
            {

                if (a[strt] < a[strt - 1])
                {
                    int temp = a[strt];
                    a[strt] = a[strt - 1];
                    a[strt - 1] = temp;

                }

                strt = strt + 2; ;

            }

            return a;

        }

        public static void KsortedArray(int[] a, int k)
        {
            List<int> t = new List<int>();

            Heap h = new Heap(k + 1);

            for (int i = 0; i <= k; i++)
            {
                h.InsertInHeap(a[i]);
            }

            for (int i = k + 1; i < a.Length; i++)
            {
                h.InsertInHeap(a[i]);
                if (h.Size > k)
                {
                    t.Add(h.RemoveFromHeap());
                }
            }

            while (h.Size > 0)
            {
                t.Add(h.RemoveFromHeap());
                // k++;
            }

        }

        public static void Print2Smallest(int[] a)
        {

            int sm1 = int.MaxValue;
            int sm2 = int.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {

                if (sm1 > a[i])
                {
                    sm2 = sm1;
                    sm1 = a[i];
                }
                else if (sm2 > a[i] && a[i] != sm1)
                {
                    sm2 = a[i];

                }
            }

            Console.WriteLine(sm1);
            Console.WriteLine(sm2);
        }

        #region Quick Sort

        public static void QucikSort(int[] a, int i, int j)

        {

            if (i < j)
            {
                int m = partition(a, i, j);
                QucikSort(a, i, m - 1);
                QucikSort(a, m + 1, j);

            }
        }

        private static int partition(int[] a, int l, int h)
        {

            int p = a[l];
            int low = l;
            int high = h;

            while (low < high)

            {

                while (a[low] <= p && low < high)
                {
                    low++;
                }


                while (a[high] > p)
                {
                    high--;


                }

                if (low < high)
                    swap(a, low, high);
            }

            swap(a, high, l);

            return high;


        }

        #endregion

        private static void swap(int[] a, int l, int j)

        {
            int p = a[l];
            a[l] = a[j];
            a[j] = p;
        }

        public static int DistinctDiffCountPair(int[] a, int k)

        {

            int count = 0;
            Dictionary<int, bool> dic = new Dictionary<int, bool>();


            for (int i = 0; i < a.Length; i++)
            {


                if (!dic.ContainsKey(a[i]))
                {
                    dic[a[i]] = true;
                }

            }



            for (int j = 0; j < a.Length; j++)
            {

                if (dic.ContainsKey(Math.Abs(k + a[j])) && dic[Math.Abs(k + a[j])])

                {
                    dic[a[j]] = false;
                    count++;


                }


            }


            return count;



        }

        public static int MaxCountInSorted(int[] a)

        {
            int count = 1;
            int maxSofar = 1;
            int maxelem = a[0];

            for (int i = 1; i < a.Length; i++)
            {

                if (a[i] == a[i - 1])
                {
                    count++;

                }

                if (count > maxSofar)
                {
                    maxSofar = count;
                    maxelem = a[i];
                }

                //Restart count if next element is different
                if (a[i] != a[i - 1])

                {

                    count = 1;
                }


            }

            return maxelem;

        }

        public static void Print2DArray(int[,] a)
        {
            // 2 rows od 2 by 3 array 
            int[,,] arr3d3 = new int[2, 2, 3]{
                { { 1, 2, 3}, {4, 5, 6} },
                { { 7, 8, 9}, {10, 11, 12} }
            };

            // int[,] a = new int[3, 3]{ { 1,2, 3}, { 4,5,6 }, { 7,8,9} };


            for (int i = 0; i < a.GetLength(0); i++)
            {

                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "   ");
                }

                Console.WriteLine();

            }

        }

        public static void ReverseRows(int[,] a)
        {
            int n = a.GetLength(0);

            for (int j = 0; j < a.GetLength(0); j++)
            {
                for (int i = 0; i < a.GetLength(0) / 2; i++)
                {
                    var temp = a[i, j];
                    a[i, j] = a[n - 1 - i, j];
                    a[n - 1 - i, j] = temp;
                }
            }
        }

        public static void ReverseColumns(int[,] a)
        {
            int n = a.GetLength(0);

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0) / 2; j++)
                {
                    var temp = a[i, j];
                    a[i, j] = a[i, n - j - 1];
                    a[i, n - j - 1] = temp;
                }
            }
        }

        // Transpose
        public static void RowsTocolums(ref int[,] a)
        {
            int n = a.GetLength(0);
            int[,] b = new int[n, n];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[j, i] = a[i, j];
                }
            }

            a = b;
        }

        public static void RotateMatrixElementClock(int[,] a, int i, int j)
        {
            int rows = a.GetLength(0);
            int columns = a.GetLength(1);

            int rowLastColVal = a[i, j - 1];

            // Move first row all columns
            for (int c = j - 1; c > 0; c--)
            {
                a[0, c] = a[0, c - 1];
            }

            // First column all rows
            for (int r = 0; r < rows - 1; r++)
            {
                a[r, 0] = a[r + 1, 0];
            }

            // Last row all columns
            for (int c = 0; c < columns - 1; c++)
            {
                a[rows - 1, c] = a[rows - 1, c + 1];
            }

            // Last column all rows
            for (int r = rows - 1; r > 1; r--)
            {
                a[r, columns - 1] = a[r - 1, columns - 1];
            }

            a[1, columns - 1] = rowLastColVal;

        }

        public static void RotateNew(int[] a, int k)
        {
            for (int i = 0; i < k; i++)
            {

                int temp = a[0];

                for (int j = 1; j < a.Length; j++)
                {
                    a[j - 1] = a[j];
                }

                a[a.Length - 1] = temp;

            }
        }


        public static void Shuffle(int[] a, int str, int end)
        {

            while (str < end - 1)
            {
                Random r = new Random();
                int k = r.Next(str, end);

                int temp = a[str];
                a[str] = a[k];
                a[k] = temp;
                str++;
            }


        }


        public static void leftRotate(int[] arr, int d,
                          int n)
        {

            Random r = new Random();

            int i, j, k, temp;
            /* To handle if d >= n */
            d = d % n;
            int g_c_d = gcd(d, n);
            for (i = 0; i < g_c_d; i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= n)
                        k = k - n;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
        }

        /*UTILITY FUNCTIONS*/
        /* Function to print an array */
        static void printArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");
        }

        /* Fuction to get gcd of a and b*/
        static int gcd(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return gcd(b, a % b);
        }

        public static void sortInWave(int[] arr, int n)
        {
            // Traverse all even elements
            for (int i = 0; i < n; i += 2)
            {

                // If current even element is smaller
                // than previous
                if (i > 0 && arr[i - 1] > arr[i])
                    swap(arr, i - 1, i);

                // If current even element is smaller
                // than next
                if (i < n - 1 && arr[i] < arr[i + 1])
                    swap(arr, i, i + 1);
            }
        }

        public class NumberFreq
        {
            public int number { get; set; }
            public int freqCount { get; set; }
            public int firstIndex { get; set; }

        }


        public class EmpComparer : IComparer<NumberFreq>
        {
            public int Compare(NumberFreq x, NumberFreq y)
            {
                if (x.freqCount > y.freqCount)
                    return 1;

                if (x.freqCount < y.freqCount)
                    return -1;

                if (x.firstIndex > y.firstIndex)
                    return 1;

                if (x.firstIndex < y.firstIndex)
                    return -1;

                return 0;

            }

        }
        public static void SortHash(int l, int h)
        {
            int mid = l + (h - l) / 2;

            List<NumberFreq> emp = new List<NumberFreq>();
            int[] a = { 1, 2, 3 };
            Hashtable s = new Hashtable();

            List<NumberFreq> ls = new System.Collections.Generic.List<NumberFreq>();
            ls.Add(new NumberFreq() { firstIndex = 0, freqCount = 1 });
            ls.Add(new NumberFreq() { firstIndex = 2, freqCount = 2 });
            ls.Add(new NumberFreq() { firstIndex = 1, freqCount = 2 });

            ls.Sort(new EmpComparer());

            foreach (var item in ls)
            {
                Console.WriteLine(a[item.firstIndex] + "  " + item.freqCount);
            }


            Dictionary<int, int[,]> dic = new Dictionary<int, int[,]>();

            var x = dic.Values;

            dic.Add(1, new int[1, 2] { { 0, 1 } });
            dic.Add(2, new int[1, 2] { { 1, 2 } });
            dic.Add(5, new int[1, 2] { { 2, 2 } });

            //  dic.Sort()



        }

        public static int PivotIndex(int[] a, int l, int h)
        {


            if (l >= h)
                return -1;

            int mid = l + (h - l) / 2;

            int next = mid + 1;


            if (a[mid] > a[next])
                return next;

            if (a[l] < a[mid])

                return PivotIndex(a, mid + 1, h);


            return PivotIndex(a, l, mid + 1);

        }

        public static int findRotationPoint(int[] A)
        {
            int start = 0, end = A.Length - 1, mid;
            mid = start + (end - start) / 2;
            int last = A[A.Length - 1];
            while (start <= end)
            {
                if (A[mid] > last)
                {
                    start = mid + 1;
                }
                else if (A[mid] < last)
                {
                    end = mid - 1;
                }
                else
                    break;
                mid = start + (end - start) / 2;
            }
            return mid;
        }

        public static void QuickSort(int[] a, int l, int h)
        {
            //  { 6, 1, 4, 2,7,3,8}
            if (l >= h)
                return;

            int temp = a[l];
            int i = l + 1;
            int j = h;

            while (i < j)
            {
                if (a[i] < temp)
                { i++; }

                if (a[j] > temp)
                    j--;

                if (a[i] > temp && a[j] < temp && i < j)
                {
                    Swap(a, i, j);
                    i++;
                    j--;
                }

            }

            if (a[l] > a[j])
                Swap(a, l, j);

            QuickSort(a, l, j - 1);
            QuickSort(a, j + 1, h);


        }

        private static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }


        public static int[] RearrangeArray(int[] a)

        {
            //  HashSet<int> hs = new HashSet<int>();

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!dic.ContainsKey(a[i]))
                {
                    dic.Add(a[i], a[i]);
                }
            }

            for (int x = 0; x < a.Length; x++)
            {
                if (dic.ContainsKey(x))
                {
                    a[x] = dic[x];
                }
                else
                {
                    a[x] = -1;
                }
            }

            return a;
        }

        public static void findMinSum(int[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (!(Math.Abs(arr[i - 1]) <
                      Math.Abs(arr[i])))
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                }
            }

        }


        // C# Program for finding out majority element in an array

        #region Majority Element
        /* Function to print Majority Element */
        public static void printMajority(int[] a, int size)
        {
            /* Find the candidate for Majority*/
            int cand = findCandidate(a, size);

            /* Print the candidate if it is Majority*/
            if (isMajority(a, size, cand))
                Console.Write(" " + cand + " ");
            else
                Console.Write("No Majority Element");
        }

        /* Function to find the candidate for Majority */
        private static int findCandidate(int[] a, int size)
        {
            int maj_index = 0, count = 1;
            int i;
            for (i = 1; i < size; i++)
            {
                if (a[maj_index] == a[i])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    maj_index = i;
                    count = 1;
                }
            }
            return a[maj_index];
        }

        // Function to check if the candidate
        // occurs more than n/2 times
        private static bool isMajority(int[] a, int size, int cand)
        {
            int i, count = 0;
            for (i = 0; i < size; i++)
            {
                if (a[i] == cand)
                    count++;
            }
            if (count > size / 2)
                return true;
            else
                return false;
        }

        #endregion  


        public static int MaxContinousSumKandane(int[] a)
        {
            int currSum = a[0];
            int maxSum = a[0];

            for (int i = 1; i < a.Length; i++)
            {

                // No debt sum so far, so add
                if (currSum > 0)
                {
                    currSum += a[i];
                }
                else
                {
                    // Current sub was -ve so total will go down, so better start from here
                    currSum = a[i];
                }

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }

            return maxSum;
        }

        public static int MaxContinousSumPract(int[] arr)
        {
            int maxSum = int.MinValue;

            if (arr.Length == 0)
                return maxSum;


            int currSum = arr[0];
            maxSum = arr[0];

            int i = 1;

            while (i < arr.Length)

            {

                currSum = currSum + arr[i];



                if (currSum < arr[i])
                {
                    currSum = arr[i];



                }

                i++;

                maxSum = Math.Max(currSum, maxSum);



            }

            return maxSum;

        }


        public static int CircleOfDeath(List<int> a, int k, int start)
        {
            List<int> ls = a.ToList();

            if (ls.Count == 1)
                return ls.First();

            start = (start + k) % ls.Count;
            ls.RemoveAt(start);

            return CircleOfDeath(ls, k, start);
        }

        public static int CircleOfDeath(int k, int n)
        {
            if (n == 1)
                return 0;

            //Index is x in n-1
            int x = CircleOfDeath(k, n - 1);
            int y = (x + k) % n;
            return y;
        }


        // This is Swap sort approach works in O(N) with O(1) space
        public static void MissningDuplicateInN(int[] a)
        {
            int i = 0;

            while (i <= a.Length - 1)
            {
                // Find number at index where the current element should be
                // e.g. a[0] = 3; the comp is what number is at a[3-1], it should be 3 
                // if a[2] is not 3 then swap; so that it is at correct position 
                // Else move to next position, a[0] may be replaced later when we get 1 at a[i];

                int comp = a[a[i] - 1];

                if (a[i] != comp)
                {
                    Swap(a, i, a[i] - 1);

                }
                else
                {
                    i++;
                }
            }

            for (int j = 0; j <= a.Length - 1; j++)
            {
                if (a[j] != j + 1)
                {
                    Console.WriteLine("Duplicate number " + a[j]);
                    Console.WriteLine("Missing number " + (j + 1));

                }
            }

        }

        static List<List<int>> result = new List<List<int>>();

        public static List<List<int>> SubSetSumK(int[] a, int k)
        {
            SubSetSumK(a, 0, k, 0, new List<int>());

            return result;
        }

        public static void SubSetSumK(int[] a, int start, int k, int sumSofar, List<int> final)
        {
            if (start > a.Length - 1)
                return;

            if (sumSofar + a[start] == k)
            {

                var x = new List<int>(final);
                x.Add(a[start]);
                result.Add(x);
                return;
            }

            if (a[start] + sumSofar < k)
            {
                var x = new List<int>(final);
                x.Add(a[start]);
                SubSetSumK(a, start + 1, k, sumSofar + a[start], x);

                SubSetSumK(a, start + 1, k, sumSofar, final);
            }
            else
            {
                SubSetSumK(a, start + 1, k, sumSofar, final);
            }




        }



        public static void MovePositiveAndNegative(int[] arr)
        {

            int i = 0;
            int j = arr.Length - 1;

            while (i < j)
            {
                while (arr[i] >= 0)
                {
                    i++;

                }

                while (arr[j] < 0)
                {
                    j--;
                }

                if (i < j)
                {
                    int tem = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tem;


                }

            }

        }

        public static int FindKthLargest(int[] nums, int k)
        {

            if (nums.Length == 0 || k > nums.Length)
            {
                return -1;
            }


            int partitionindex = Partition(nums, 0, nums.Length - 1);

            while (true)
            {
                if (partitionindex == nums.Length - k)
                    return nums[partitionindex];

                if (partitionindex > nums.Length - k)
                {
                    partitionindex = Partition(nums, 0, partitionindex);
                }
                else
                {
                    partitionindex = Partition(nums, partitionindex + 1, nums.Length - 1);
                }

            }


        }

        private static int Partition(int[] nums, int l, int r)
        {
            int el = nums[l];

            while (true)
            {
                if (nums[l] < el)
                {
                    l++;
                }

                if (nums[r] > el)
                {
                    r--;
                }


                if (l < r)
                {

                    int temp = nums[l];
                    nums[l] = nums[r];
                    nums[r] = temp;

                }
                else
                {
                    return r;
                }
            }

        }


        private static Dictionary<int, int> dic = new Dictionary<int, int>();

        public static int[] TopKFrequent(int[] nums, int k)
        {


            foreach (int a in nums)
            {
                if (dic.Keys.Contains(a))
                {
                    dic[a]++;
                }
                else
                {
                    dic.Add(a, 1);
                }
            }

            int[] freq = dic.Keys.ToArray();

            int len = freq.Length;

            int l = 0;
            int r = len - 1;


            int partition = 0;

            while (true)
            {
                int pivot = l;
                partition = PartitionFre(freq, l, r);

                if (partition == len - k)
                {
                    break;
                }

                if (partition > len - k)
                {
                    r = partition - 1;
                    partition = PartitionFre(freq, l, partition - 1);
                }


                else if (partition < len - k)
                {
                    l = partition + 1;
                    partition = PartitionFre(freq, l, r);
                }

            }

            List<int> result = new List<int>();

            for (int i = partition; i < len; i++)
            {
                result.Add(freq[i]);
            }

            return result.ToArray<int>();
        }

        public static int PartitionFre(int[] nums, int l, int r)
        {
            int pivot = l;

            while (l <= r)
            {
                while (l <= r && dic[nums[l]] <= dic[nums[pivot]]) l++;
                while (l <= r && dic[nums[r]] > dic[nums[pivot]]) r--;

                if (l > r) break;

                int temp = nums[r];
                nums[r] = nums[l];
                nums[l] = temp;
            }

            int tem = nums[pivot];
            nums[pivot] = nums[r];
            nums[r] = tem;

            return r;
        }
        
        public static void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;

            if (m == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    nums1[i] = nums2[i];

                }

                return;
            }

            int j = 0;
            int k = 0;
            int sizem = m;


            while (m > 0)
            {
                if (nums1[j] <= nums2[k])
                {
                    m--;
                    j++;
                }
                else
                {
                    int tem = nums1[j];
                    nums1[j] = nums2[k];
                    nums2[k] = tem;

                    int loop = k;


                    if (loop + 1 < n && nums2[loop] > nums2[loop + 1])
                    {
                        int tem1 = nums2[loop];
                        nums2[loop] = nums2[loop + 1];
                        nums2[loop + 1] = tem1;
                    }
                    m--;
                    j++;
                }

            }


            while (n > 0)
            {
                nums1[sizem - 1] = nums2[k];
                k++;
                n--;
                sizem++;
            }
        }

        ///Merge 3 arrays
        ///
        //    vector<int> merge3Arrays(vector<int>& a, vector<int>& b, vector<int>& c)
        //    {
        //        vector<int> res;
        //        for (int ai = 0, bi = 0, ci = 0; ai < a.size() || bi < b.size() || ci < c.size();)
        //        {
        //            int m = min({ ai < a.size() ? a[ai] : INT_MAX, bi < b.size() ? b[bi] : INT_MAX, ci < c.size() ? c[ci] : INT_MAX});
        //        if (res.empty() || res.back() != m) res.push_back(m);
        //        if (a[ai] == m) ++ai;
        //        if (b[bi] == m) ++bi;
        //        if (c[ci] == m) ++ci;
        //    }
        //    return res;
        //}


        //Interview Tip: Whenever you're trying to solve an array problem in-place, 
        //always consider the possibility of iterating backwards instead of forwards through the array. 
        //It can completely change the problem, and make it a lot easier.

        //88. Merge Sorted Array
        public static void Merge2SortedArraysInPlace(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1, p2 = n - 1, p = nums1.Length - 1;
            while (p > -1)
            {
                int cand1 = p1 > -1 ? nums1[p1] : int.MinValue;
                int cand2 = p2 > -1 ? nums2[p2] : int.MinValue;
                if (cand1 > cand2)
                {
                    nums1[p] = cand1;
                    p1--;
                }
                else
                {
                    nums1[p] = cand2;
                    p2--;
                }
                p--;
            }
        }



        public static bool CheckSubarraySumDivisibleByK(int[] nums, int k)
        {

            int[] sum = new int[nums.Length];

            if (nums.Length < 1)
                return false;

            sum[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                sum[i] = nums[i] + sum[i - 1];

                if (sum[i] % k == 0)
                    return true;

                if (sum[i] > k)
                {
                    int remainder = sum[i] % k;

                    int m = i - 1;
                    while (m > 0)
                    {
                        if (sum[m] == remainder)
                            return true;

                        m--;
                    }
                }

            }

            return false;

        }

        //227. Basic Calculator II - Leetcode
        //Otherway to do is stack
        public static int BasicCalculator(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int length = s.Length;

            int currentNumber = 0, lastNumber = 0, result = 0;
            char operation = '+';
            for (int i = 0; i < length; i++)
            {
                char currentChar = s[i];
                if (IsDigit(currentChar))
                {
                    currentNumber = (currentNumber * 10) + (currentChar - '0');
                }
                if (!IsDigit(currentChar) && currentChar != ' ' || i == length - 1)
                {
                    if (operation == '+' || operation == '-')
                    {
                        result += lastNumber;
                        lastNumber = (operation == '+') ? currentNumber : -currentNumber;
                    }
                    else if (operation == '*')
                    {
                        lastNumber = lastNumber * currentNumber;
                    }
                    else if (operation == '/')
                    {
                        lastNumber = lastNumber / currentNumber;
                    }
                    operation = currentChar;
                    currentNumber = 0;
                }
            }
            result += lastNumber;
            return result;
        }

        private static bool IsDigit(char c)
        {
            if (c - '0' >= 0 && c - '0' <= 9)
                return true;

            return false;
        }

        private class Emp
        {
            public string Name;
            public int Id;
            public int managerId;
        }

        public static void PrintOrgChart()
        {
            List<Emp> emps = new List<Emp>();
            emps.Add(new Emp() { Name = "Name1", Id = 1, managerId = -1 });
            emps.Add(new Emp() { Name = "Name2", Id = 2, managerId = 1 });
            emps.Add(new Emp() { Name = "Name3", Id = 3, managerId = 2 });
            emps.Add(new Emp() { Name = "Name4", Id = 4, managerId = 1 });

            Dictionary<int, List<Emp>> reportees = new Dictionary<int, List<Emp>>();


            foreach (var item in emps)
            {

                if (!reportees.Keys.Contains(item.Id))
                {
                    reportees.Add(item.Id, new List<Emp>());
                }

                if (!reportees.Keys.Contains(item.managerId))
                {
                    reportees.Add(item.managerId, new List<Emp>());
                }

                reportees[item.managerId].Add(item);
            }

            foreach (var item in emps.Where(x => x.managerId == -1))
            {
                PrintEmp(item.Id, 0, reportees, emps);
            }

        }

        private static void PrintEmp(int empid, int level, Dictionary<int, List<Emp>> reportees, List<Emp> emps)
        {


            Console.WriteLine();
            for (int i = 0; i < level; i++)
            {
                Console.Write("-");
            }
            Console.Write(emps.First(x => x.Id == empid).Name);

            foreach (var item in reportees[empid])
            {
                PrintEmp(item.Id, level + 1, reportees, emps);
            }

        }


        public static int[] Merge3Arrays(int[] a1, int[] a2, int[] a3)
        {
            int[] merge = new int[a1.Length + a2.Length + a3.Length];


            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int index = 0;

            while (p1 < a1.Length || p2 < a2.Length || p3 < a3.Length)
            {
                int a = p1 < a1.Length ? a1[p1] : int.MaxValue;
                int b = p2 < a2.Length ? a2[p2] : int.MaxValue;
                int c = p3 < a3.Length ? a3[p3] : int.MaxValue;

                int min = Math.Min(a, b);
                min = Math.Min(min, c);

                if (a == min)
                {
                    merge[index] = a1[p1];
                    index++;
                    p1++;
                }

                if (b == min)
                {
                    merge[index] = a2[p2];
                    index++;
                    p2++;
                }

                if (c == min)
                {
                    merge[index] = a3[p3];
                    index++;
                    p3++;
                }


            }

            return merge;


        }

        public static int[] MergeKArrays(List<int[]> arrays, int left, int right)
        {
            List<int> merge = new List<int>();


            if (left == right)
                return arrays[left];

            int mid = left + (right - left) / 2;

            int[] leftmerge = MergeKArrays(arrays, 0, mid);

            int[] rightmerge = MergeKArrays(arrays, mid + 1, right);

            return SortHelper.MergeSortedArray(leftmerge, rightmerge);
           
        }


       

       
    }
}





