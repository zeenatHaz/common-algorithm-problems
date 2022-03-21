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


        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            //lets say the array is [10,5,2,6] and k=100

            if (k <= 1 || nums == null || nums.Length == 0) //base case
            {
                return 0;
            }
            int ans = 0;
            int product = 1, left = 0;
            int count = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                product = product * nums[right]; // 1* 10

                while (product >= k)
                {

                    product = product / nums[left];
                    left++;
                }
                ans = ans + (right - left + 1);
            }

            return ans;
        }

        public void SortColors(int[] nums)
        {
            // Input: nums = [2, 0, 2, 1, 1, 0]
            //Output:[0,0,1,1,2,2]

            List<int> red = new List<int>();
            List<int> white = new List<int>();
            List<int> blue = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    red.Add(nums[i]);
                }
                if (nums[i] == 1)
                {
                    white.Add(nums[i]);
                }
                if (nums[i] == 2)
                {
                    blue.Add(nums[i]);
                }
            }
            var all = red.Concat(white)
                                    .Concat(blue)
                                    .ToList();

            for (int k = 0; k < all.Count(); k++)
            {
                nums[k] = all[k];
            }

        }

        public bool BackspaceCompare(string s, string t)
        {

            if (s.Length == 0 || t.Length == 0)
            {
                return false;
            }

            string s1 = this.checkString(s);
            string s2 = this.checkString(t);


            return s1.Equals(s2);
        }



        private string checkString(string s)
        {


            Stack<char> st = new Stack<char>();
            foreach (var ele in s)
            {
                if (ele == '#')
                {
                    if (st.Count > 0)
                    {
                        char x = st.Pop();
                        Console.WriteLine(x);
                    }


                }
                else
                {

                    st.Push(ele);

                }
            }
            return new string(st.ToArray());
        }
    }
}
