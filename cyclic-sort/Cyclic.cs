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
    }
}
