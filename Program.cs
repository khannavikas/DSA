using CCIFinal.Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            LRU lru = new LRU(2);

            lru.Add("vk", 1);
            lru.Add("mk", 2);
            lru.Add("ak", 3);


            int[] a = new int[] { 6, 1, 4, 2, 7, 3, 8, 99, 39, 57, 43 }; ;
            int d = 2;
            int n = a.Length;

            ArrayFunc.QuickSort(a, 0, a.Length - 1);
            //  int pi = ArrayFunc.PivotIndex(a, 0, a.Length-1);

         //   ArrayFunc.SortHash(0, 1);

            ArrayFunc.Shuffle(a, 0, n);

            int[,] d2 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            ArrayFunc.leftRotate(a, 3, a.Length);

            ArrayFunc.RotateNew(a, 4);
            //   ArrayFunc.RotateMatrixElementClock(d2);
            // ArrayFunc.RowsTocolums(ref d2);
         //   ArrayFunc.Print2DArray(d2);

            int max = ArrayFunc.MaxCountInSorted(a);

            findMinSum(a, 6);

            //  int p = ArrayFunc.COUN(a, 4);

            ArrayFunc.QucikSort(a, 0, a.Length - 1);

            Random r = new Random();
            int k = r.Next(0);

            ArrayFunc.KsortedArray(a, 3);

            Heap h1 = new Heap(1);
            h1.InsertInHeap(2);
            h1.InsertInHeap(1);
            h1.RemoveFromHeap();
            h1.InsertInHeap(1);
            h1.InsertInHeap(8);
            h1.InsertInHeap(6);
            h1.InsertInHeap(5);
            h1.InsertInHeap(10);
            h1.InsertInHeap(1);

            NewHeap h = new NewHeap(1);
            h.Push(2);
                      h.Push(1);
            h.Pop();
            h.Push(1);
            h.Push(8);
            h.Push(6);
            h.Push(5);
            h.Push(10);
            h.Push(1);

            while (h._size > 0)
            {
                Console.WriteLine(h.Pop());
            }

            int[] swapsR = ArrayFunc.RearrangeEvenGreaterThanOdd(a);
            //
            // int md = ArrayFunc.binarySearch(a, 0, a.Length-1, 3);
            //    int[] xy = RearrangeArray(a);

            //   int t = 3 %5;

            // a =    ArrayFunc.ReverseArray(a);

            var m = ArrayFunc.MovePositiveNegative(a);

            for (int i = 0; i < d; i++)
            {
                int temp = a[0];

                for (int j = 1; j < n; j++)
                {
                    a[j - 1] = a[j];
                }
                a[n - 1] = temp;

            }

            for (int x = 0; x < a.Length; x++)
            {
                Console.WriteLine(a[x]);
            }

            Console.Read();
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

        static void findMinSum(int[] arr, int n)
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



    }
}
