﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_way_merge
{
    public class kway
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {

            if (nums == null || nums.Length < k)
                return new double[0];

            List<double> res = new List<double>();
            List<int> window = new List<int>();
           
            for (int i = 0; i < nums.Length; i++)
            {
                int idx = window.BinarySearch(nums[i]);
                 if (idx < 0)
                    idx = ~idx;
                window.Insert(idx, nums[i]);

                // keep sliding window size fixed
                if (i >= k)
                    window.Remove(nums[i - k]);

                if (i >= k - 1)
                {
                    if (k % 2 == 0)
                        res.Add(((long)window[k / 2] + window[(k - 1) / 2]) / 2.0);
                    else
                        res.Add(window[k / 2]);
                }
            }

            return res.ToArray();
        }

        public long GetId(int i, int[] nums)
        {
            return Convert.ToInt64(nums[i]) * nums.Length + i;
        }
    }
}
