using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class NewHeap
    {
      public  int _size;
        int _capacity;
        int[] a;
        public NewHeap(int capactiy)
        {
            _capacity = capactiy;
            _size = 0;
            a = new int[capactiy];
        }

        public int ParentIndex(int i) { return (i - 1) / 2; }

        public int LeftIndex(int i) { return 2 * i + 1; }

        public int RightIndex(int i) { return 2 * i + 2; }


        public bool HasLeftChild(int i)
        { return LeftIndex(i) <= _size; }

        public bool HasRightChild(int i)
        { return RightIndex(i) <= _size; }

        public void Push(int i)
        {
            if (_size == _capacity)
            {
                _capacity = _capacity * 2;
                int[] b = new int[_capacity];
                a.CopyTo(b, 0);
                a = b;
            }

            a[_size] = i;
            _size++;

            HeapifyUp(_size -1);
        }


        public int Pop()
        {
            int top = a[0];
            a[0] = a[_size - 1];
            _size--;
           // Console.WriteLine(top);
            HeapifyDown(0);
         return top;
        }


        private void HeapifyUp(int i)
        {
            // Also check if it has parent only then do
            if( a[i] < a[ParentIndex(i)])
            {
                int temp = a[ParentIndex(i)];
                a[ParentIndex(i)] = a[i];
                a[i] = temp;
                HeapifyUp(ParentIndex(i));
            }

        }

        private void HeapifyDown(int i)
        {
            // First find if r is small or l is small and then swap accordingly 

            if (HasLeftChild(i) && a[LeftIndex(i)] < a[i])
            {
                int temp = a[i];
                a[i] = a[LeftIndex(i)];
                a[LeftIndex(i)] = temp;
                HeapifyDown(LeftIndex(i));
                return;
            }

            if (HasRightChild(i) && a[RightIndex(i)] < a[i])
            {
                int temp = a[i];
                a[i] = a[RightIndex(i)];
                a[RightIndex(i)] = temp;
                HeapifyDown(RightIndex(i));
                return;
            }

        }
    }

}
