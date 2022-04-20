using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public static class SortHelper
    {

        public static int[] MergeList(int[] a, int[] b)
        {
            int[] mergedList = new int[a.Length + b.Length];


            int i = 0;
            int j = 0;
            int c = 0;

            while (i < a.Length && j < b.Length)

            {

                if (a[i] <= b[j])
                {
                    mergedList[c] = a[i];
                    c++;
                    i++;

                }

                else if (a[i] > b[j])
                {
                    mergedList[c] = b[j];
                    c++;
                    j++;
                }

            }

            while (i < a.Length)
            {
                mergedList[c] = a[i];
                c++;
                i++;
            }

            while (j < b.Length)
            {
                mergedList[c] = b[j];
                c++;
                j++;
            }

            return mergedList;

        }

        public static int[] MergeSortedArray(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];

            int i = 0, j = 0, k = 0;


            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j])
                {
                    c[k] = a[i];
                    i++;
                    k++;
                }
                else if (a[i] > b[j])
                {
                    c[k] = b[j];
                    j++;
                    k++;
                }
            }

            while (i < a.Length)
            {

                c[k] = a[i];
                i++;
                k++;
            }

            while (j < b.Length)
            {

                c[k] = b[j];
                j++;
                k++;
            }

            return c;

        }

        public static int[] MergeSort(int[] x, int l, int r)
        {
            if (l == r)
                return x;// new int[] { x[l] };

            int mid = (l + r) / 2;
            int[] a1 = MergeSort(x, l, mid);
            int[] a2 = MergeSort(x, mid + 1, r);

            return MergeSortedArray(a1, a2);

        }

        public static int[] QuickSort(int[] a, int l, int r)
        {
            if (l < r)
            {

                int pivot = PartitionDuplicates(a, l, r);

                if (pivot > 1)
                {
                    QuickSort(a, l, pivot - 1);
                }
                if (pivot + 1 < r)
                {
                    QuickSort(a, pivot + 1, r);
                }
            }

            return a;

        }

        public static int PartitionElement(int[] a, int l, int r)

        {

            int pivot = a[l];

            while (true)
            {

                while (a[l] < pivot)
                    l++;

                while (a[r] > pivot)
                    r--;

                if (l < r)
                {
                    int tem = a[l];
                    a[l] = a[r];
                    a[r] = tem;
                }
                else
                {
                    return r;
                }

            }

            //if (a[r] < a[k])
            //{
            //	int tem = a[k];
            //	a[k] = a[r];
            //	a[r] = tem;

            //}

            //return r;

        }

        static public int Partition(int[] numbers, int left, int right)

        {

            int pivot = numbers[left];

            while (true)

            {

                while (numbers[left] < pivot)

                    left++;



                while (numbers[right] > pivot)

                    right--;



                if (left < right)

                {

                    int temp = numbers[right];

                    numbers[right] = numbers[left];

                    numbers[left] = temp;

                }

                else

                {

                    return right;

                }

            }
        }

        //Important 
        private static int PartitionDuplicates(int[] nums, int start, int end)
        {
            int pivot = start, temp;
            while (start <= end)
            {
                //Important we used equal for start and Pivot comparision
                while (start <= end && nums[start] <= nums[pivot]) start++;
                while (start <= end && nums[end] > nums[pivot]) end--;
                if (start > end) break;
                temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
            }

            // End means number is less than or equal to pivot
            temp = nums[end];
            nums[end] = nums[pivot];
            nums[pivot] = temp;
            return end;
        }
        public static int[][] KClosest(int[][] points, int k)
        {
            int len = points.Length;
            int l = 0;
            int r = len - 1;

            int pivot = GetPivotIndex(points, l, r);

            while (pivot +1 != k)
            {
                if (pivot + 1 > k)
                {
                    pivot = GetPivotIndex(points, l, pivot - 1);
                }
                else
                {
                    pivot = GetPivotIndex(points, pivot + 1, r);
                }

            }

            int[][] ans = new int[k][];

            while (k > 0)
            {
                ans[k - 1] = points[k-1];
                k--;
            }

            return ans;
        }
        private static int GetPivotIndex(int[][] points, int l, int r)
        {
            var pivot = l;

            while (l <= r)
            {

                while (l <= r && compare(points, l, pivot) <= 0) l++;

                while (l <= r && compare(points, r, pivot) > 0) r--;
                if (l > r) break;

                    var tem = points[r];
                    points[r] = points[l];
                    points[l] = tem;
                
            }

            var t = points[r];
            points[r] = points[pivot];

            points[pivot] = t;

            return r;
        }

        public static int compare(int[][] points, int l, int r)
        {
            var t = (points[l][0] * points[l][0] + points[l][1] * points[l][1]) - (points[r][0] * points[r][0] + points[r][1] * points[r][1]);

            return t;
        }


    }
}
