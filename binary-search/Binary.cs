using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search
{
    //Linear Search: O(n) becuase we are travering each array element.
    //Binary-search-iterative :O(LogN).and space o(1) //works for distinct and non distinct array elements.

    public class Binary : IBinary
    { 
        //linear-search
        public int Bitonic(int[] arr)
        {
            if (arr.Length == 0)
                return 0;
            int max = int.MinValue;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        //Binary-search-iterative
        public int Bitonic_Binary_Search(int[] arr)
        {
            if (arr.Length == 0)
                return 0;
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                //check the base conditions
                
                //1) if there is only two elements in the array.
                if((r==l+1) && arr[l] >= arr[r])
                {
                    return arr[l]; // becuase this is the greatest among the two values.
                }else if(r==l+1 && arr[r] > arr[l])
                {
                    return arr[r];
                }
                //if you have found the peak element.
                if(arr[mid]>arr[mid+1] && arr[mid] > arr[mid - 1]) // 1 2 4 67 5 7
                {
                    return arr[mid];
                }
                //base case checking done .

                // update l and r based on the values.

                //move left if the below condition is satisfied,implies right will be in theleft of calculated mid.
                if(arr[mid]>arr[mid+1] && arr[mid] < arr[mid - 1]) // 1 2 80 67 5 7 8
                {
                    r = mid - 1; // 
                }
                else
                {
                    l = mid + 1;// answer will be in the right of the calculated mid.
                }
            }

            return -1; // if the element is not found.
        }

        public int findElement(int[] arr, int element)
        {   
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == element)
                    // if we found the element we will return it.
                    return mid;
                else if (mid == arr.Length - 1 || arr[mid] < arr[mid + 1])
                {
                    // we are in the increasing part of the array
                    // we will apply elementinarySearch as we do in a
                    // simple sorted increasing array
                    if (arr[mid] < element)
                    {
                        low = mid + 1;
                    }
                    else
                        high = mid - 1;
                }
                else
                {
                    // the array is decreasing 
                    if (arr[mid] < element)
                    {
                        high = mid - 1;
                    }
                    else
                        low = mid + 1;
                }
            }
            return -1;

         
        }
    }
}
