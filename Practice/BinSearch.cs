using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Practice
{
    public class BinSearch
    {

        public static int BinarySearch(int val, int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] > val)
                {
                    right = mid - 1;
                }

                if (arr[mid] < val)
                {
                    left = mid + 1;
                }

                if (arr[mid] == val)
                    return mid;

            }


            return -1;
        }



    }
}


  