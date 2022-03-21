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
        public int[] FindErrorNums2(int[] nums)
        {
            List<int> res = new List<int>();
            int n = nums.Length;
            int dup = -1;
            Array.Sort(nums);
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (i < nums.Length - 1)
                {
                    if (nums[i] == nums[i + 1])
                    {
                        dup = nums[i];
                    }
                }

                res.Add(i + 1);
            }

            int[] ans = new int[2];
            ans[0] = dup;
            ans[1] = Convert.ToInt32(res.Except(nums).First());
            return ans;
        }

        public IList<int> FindDuplicates1(int[] nums)
        {

            List<int> res = new List<int>();
            HashSet<int> hs = new HashSet<int>();
            foreach (var ele in nums)
            {
                if (!hs.Contains(ele))
                {
                    hs.Add(ele);
                }
                else
                {
                    res.Add(ele);
                }
            }

            return res;
        }
        public IList<int> FindDuplicates2(int[] nums)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                    res.Add(Math.Abs(index + 1));
                nums[index] = -nums[index];
            }
            return res;
        }

        public int FirstMissingPositive(int[] nums)
        {
            int possibleSmallestPos = 1;
            HashSet<int> hs = new HashSet<int>(nums);
            while (true)
            {
                if (!hs.Contains(possibleSmallestPos))
                {
                    return possibleSmallestPos;
                }
                else
                {
                    possibleSmallestPos++;
                    continue;
                }
            }

            return -1;
        }
        public List<int> printKMissing(int[] arr, int n, int k)
        {
            //lets say arr[2,3,4]

            int missingNumber = 1;
            List<int> res = new List<int>();
            HashSet<int> hs = new HashSet<int>(arr);
            for(int i = 0; i < n; i++)
            {
                if (res.Count != k)
                {
                    if (!hs.Contains(missingNumber))
                    {
                        res.Add(missingNumber);
                        missingNumber++;
                    }
                    else
                    {
                        missingNumber++;
                    }
                }
                else
                {
                    break;
                }
              
            }
            return res;
        }

        public int minSwapsCouples(int[] row)
        {

            var map = new Dictionary<int, int>();

            for (var j = 0; j < row.Length; j++)
            {
                map.Add(row[j], j);
            }
            var i = 0;

            var count = 0;
            var nextNumber = 0;
            while (i < row.Length)
            {
                if (row[i] / 2 != row[i + 1] / 2)
                {
                    if (row[i] % 2 == 0)
                    {
                        nextNumber = row[i] + 1;
                    }
                    else
                    {
                        nextNumber = row[i] - 1;
                    }

                    var temp = row[i + 1];
                    var idx = map[nextNumber];

                    row[i + 1] = row[idx];
                    row[idx] = temp;
                    map[row[i + 1]] = i + 1;
                    map[temp] = idx;
                    count++;
                }
                i = i + 2;
            }

            return count;
        }
    }
}
