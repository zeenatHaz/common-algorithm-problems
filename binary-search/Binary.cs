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
            for (int i = 0; i < arr.Length; i++)
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
                if ((r == l + 1) && arr[l] >= arr[r])
                {
                    return arr[l]; // becuase this is the greatest among the two values.
                }
                else if (r == l + 1 && arr[r] > arr[l])
                {
                    return arr[r];
                }
                //if you have found the peak element.
                if (arr[mid] > arr[mid + 1] && arr[mid] > arr[mid - 1]) // 1 2 4 67 5 7
                {
                    return arr[mid];
                }
                //base case checking done .

                // update l and r based on the values.

                //move left if the below condition is satisfied,implies right will be in theleft of calculated mid.
                if (arr[mid] > arr[mid + 1] && arr[mid] < arr[mid - 1]) // 1 2 80 67 5 7 8
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


        public int ceilingOfANumber(int[] arr, int element)
        {
            if (arr.Length == 0)
            {
                return -1;

            }

            int l = 0, h = arr.Length - 1;
            while (l <= h)
            {
                int mid = l + (h - l) / 2;
                if (arr[mid] == element)
                {
                    return mid;
                }
                else if (arr[mid] > element)
                {
                    h = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return l;
        }


        public IList<int> minDifference(int[] arr, int k, int x)
        {
            int len = arr.Length, left = 0, right = len - k - 1, mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (arr[mid + k] < x || Math.Abs(arr[mid] - x) > Math.Abs(arr[mid + k] - x)) left = mid + 1;
                else right = mid - 1;
            }
            return arr.Skip(left).Take(k).ToList();


        }


        public char nextLetter(char[] letters, char target)
        {
            if (target >= letters[letters.Length - 1])
                return letters[0];

            int left = 0, right = letters.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (letters[mid] <= target)
                    left = mid + 1;
                else
                    right = mid;
            }

            return letters[left];
        }

        public void numberRange(int[] arr, int target)
        {
            int[] res = new int[2];
            res[0] = findFirst(arr, target);
            res[1] = findLast(arr, target);
            Console.WriteLine("first index is :" + res[0] + " and second index is:" + res[1]);
        }



        public int searchInAInfSortedArr(int[] arr)
        {
            throw new NotImplementedException();
        }



        // private functions

        private int findFirst(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }

        private int findLast(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] <= target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }
    }
}
