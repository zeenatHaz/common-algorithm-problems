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

        public char nextLetter(char[] letters, char target); //LC 744

        public void numberRange(int[] arr,int target);

        public int searchInAInfSortedArr(int[] arr);

        public IList<int> minDifference(int[] arr, int k, int x);//LC658



    }
}
