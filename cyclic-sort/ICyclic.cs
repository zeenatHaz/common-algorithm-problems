using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyclic_sort
{
    public interface ICyclic
    {
        public int MissingNumber(int[] nums);
        public IList<int> FindDisappearedNumbers(int[] nums);
        public int FindDuplicate1(int[] nums);
        public int FindDuplicate2(int[] nums); //without using extra constant space.

       
        public int[] FindErrorNums2(int[] nums);

        public IList<int> FindDuplicates1(int[] nums); //find all lC 442
        public IList<int> FindDuplicates2(int[] nums); //find all lC 442 //w/o using extra space.

        public int FirstMissingPositive(int[] nums);// LC41//hard.
        public List<int> printKMissing(int[] arr, int n, int k);
    }
}
