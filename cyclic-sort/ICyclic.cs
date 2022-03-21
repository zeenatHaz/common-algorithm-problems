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
    }
}
