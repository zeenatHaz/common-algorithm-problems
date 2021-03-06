using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace two_pointers
{
    public  interface ITwoPointer
    {
        public int[] TwoSum(int[] nums, int target);
        public int[] SortedSquares(int[] nums);
        public int NumOfPairs(string[] nums, string target);//LC 2023//
        public int NumSubarrayProductLessThanK(int[] nums, int k);
        public void SortColors(int[] nums);
        public bool BackspaceCompare(string s, string t);
    }
}
