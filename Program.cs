using CCIFinal.Array;
using CCIFinalLL;
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
            //LinkListFunctions();

            //LRUFunction();

            //HeapFunctions();

            ArrayFunctions();

        }

        private static void ArrayFunctions()
        {
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

            int max = ArrayFunc.MaxCountInSorted(new int[] {1,1,2,3,3,3,4 });

            ArrayFunc.findMinSum(a, 6);

            //  int p = ArrayFunc.COUN(a, 4);

            ArrayFunc.QucikSort(a, 0, a.Length - 1);

            Random r = new Random();
            int k = r.Next(0);

            ArrayFunc.KsortedArray(a, 3);



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

        private static void HeapFunctions()
        {
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
        }

        private static void LRUFunction()
        {
            LRUCache lru = new LRUCache(2);

            lru.set(1, 1);
            lru.set(2, 2);
            lru.set(3, 3);
        }


        private static void LinkListFunctions()
        {
            LinkList ll = new LinkList();
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(5);
            ll.AddNode(5);
            ll.AddNode(2);
          //  ll.Print();
            ll.RemoveDuplicateNonewList();
            ll.Print();
            ll.ReverseList();
            ll.Print();
        }

    }
}
