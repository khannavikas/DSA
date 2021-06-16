using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
   public  class Heap
    {

  
        int _capacity = 0;
        int size = 0;
        int[] a;
        public Heap(int capacity)
        {
            _capacity = capacity;
            a = new int[capacity];
        }


        public int getLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }


        public int getRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        public int getParentIndex(int index)
        {
            return (index -1) / 2;
        }



        public int getLeftChildValue(int index)
        {
            return a[getLeftChildIndex(index)];
        }


        public int getRightChildValue(int index)
        {
            return a[getRightChildIndex(index)];
        }

        public int getParentValue(int index)
        {
            return a[getParentIndex(index)];
        }


        public bool hasParent(int index)
        {
            return getParentIndex(index) >=0;
        }


        public bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        public bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }


        private void Swap(int index1, int index2)
        {
            int temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }

        private void EnsureCapacityOfHeap()
        {
           if(size == _capacity)
            {
                int[] x = new int[size * 2];
                _capacity = size * 2;
                a.CopyTo(x, 0);

               
                a = x;
            }
        }

        public void InsertInHeap(int x)
        {
            EnsureCapacityOfHeap();
            a[size] = x;
            size++;
            HeapifyUp();
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public int RemoveFromHeap()
        {
            int temp = a[0];
            a[0] = a[size - 1];
            size--;
            HeapifyDown();
            return temp;
           
        }

        private void HeapifyDown()
        {
           
            int index = 0;

            while( hasLeftChild(index))
            {
                int smallestIndex = getLeftChildIndex(index);

                int rightIndex = getRightChildIndex(index);

                if(hasRightChild(index) && getLeftChildValue(index) > getRightChildValue(index))
                {
                    smallestIndex = rightIndex;
                }

                if (a[index] > a[smallestIndex])
                {
                    Swap(index, smallestIndex);
                    index = smallestIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyUp()
        {
            int index = size - 1;

            while(hasParent(index) && a[index] < getParentValue(index))
            {
                Swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree 
                Heapify(arr, n, largest);
            }
        }

        // Function to build a Max-Heap from the Array 
        static void BuildHeap(int[] arr, int n)
        {
            // Index of last non-leaf node 
            int startIdx = (n / 2) - 1;

            // Perform reverse level order traversal 
            // from last non-leaf node and heapify 
            // each node 
            for (int i = startIdx; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
        }
      
    }
}
