using System;
using System.Collections;
using System.Collections.Generic;

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

        public static int binarySearch2(int[] a, int low, int high, int key)
        {
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (a[mid] < key)
                {
                    low = mid + 1;
                }
                else if (a[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;                //key not found
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


    }


}



