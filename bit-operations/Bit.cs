using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bit_operations
{
    public class Bit : IBit
    {
        public int SingleNumber(int[] arr)
        {
            int res = 0;
           for(int i = 0; i < arr.Length; i++)
            {
                res = res ^ arr[i];
            }

            return res;
        }
    }
}
