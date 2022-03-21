using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyclic_sort
{
    public class Cyclic :ICyclic
    {
        public int MissingNumber(int[] nums)
        {
            int s1 = nums.Sum();
            int[] temp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                temp[i] = i + 1;
            }
            int s2 = temp.Sum();
            int diff = s2 - s1;
            return diff;
        }
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            //fast solution ,you need not take another array.
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0) nums[index] = -nums[index];
            }
          
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) result.Add(i + 1);
            }
            return result;
            

        }

        public int FindDuplicate1(int[] nums)
        {
            
            HashSet<int> res = new HashSet<int>();
            foreach (var ele in nums)
            {
                if (!res.Contains(ele))
                {
                    res.Add(ele);
                }
                else
                {
                    return ele;
                }
            }

            return 0;
        }

        public int FindDuplicate2(int[] nums) //uses negative marking.
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int j = Math.Abs(nums[i]);
                Console.WriteLine("j:" + j);
                Console.WriteLine("numsj:" + nums[j]);

                if (nums[j] >= 0)
                    nums[j] = -nums[j];
                else
                {
                    res = j;
                    Console.Write(j + " ");
                }

            }
            return res;

        }
    }
}
