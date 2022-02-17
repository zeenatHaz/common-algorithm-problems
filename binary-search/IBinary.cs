using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search
{
    public interface IBinary
    {
        public int Bitonic(int[] arr);

        public int findElement(int[] arr, int element);
    }
}
