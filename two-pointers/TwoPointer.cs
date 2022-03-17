using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace two_pointers
{
    public class TwoPointer : ITwoPointer
    {
        int countOfPairs = 0;
        public int[] TwoSum(int[] nums, int target)
        {

            int ans = 0;
            int i = 0, j = 0;
            Dictionary<int, int> dt = new Dictionary<int, int>();
            for (i = 0; i < nums.Length; i++)
            {
                var remainder = target - nums[i];
                if (dt.ContainsKey(remainder))
                {
                    return new int[] { i, (int)dt[remainder] };
                }

                if (!dt.ContainsKey(nums[i]))
                {
                    dt.Add(nums[i], i);
                }

            }
            return null;
        }


        public int[] SortedSquares(int[] nums)
        {
            int i = 0, j = nums.Length - 1;
            int[] result = new int[j + 1];

            for (int p = j; p >= 0; p--)
            {
                if(Math.Abs(nums[i]) > Math.Abs(nums[j]))
                {
                    result[p] = nums[i] * nums[i];
                    i++;
                }
                else
                {
                    result[p] = nums[j] * nums[j];
                    j--;
                }
            }
            return result;
        }

        public int NumOfPairs(string[] nums, string target)
        {
            int res = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                findPair(i, nums, target);
            }
            return countOfPairs;
        }

        private void findPair(int num, string[] nums, string target)
        {

            int index = 0;

            while (index <= nums.Length - 1)
            {
                if (index == num)
                {
                    index++;
                    continue;
                }
                string s = nums.ElementAt(num) + nums.ElementAt(index);
                if (s.Length > target.Length || s.Length<target.Length)
                {
                    index++;
                    continue;
                }
                
                if (s.Equals(target))
                {
                    countOfPairs++;
                }
                index++;
            }
        }
    }
}
