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

        public int ceilingOfANumber(int[] arr, int element);

        public int nextLetter(); //LC 744

        public int[] numberRange(int[] arr);

        public int searchInAInfSortedArr(int[] arr);

        public int minDifference(int[] arr);



    }
}
