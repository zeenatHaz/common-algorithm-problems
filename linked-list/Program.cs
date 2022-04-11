namespace linked_list
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LL obj = new LL();
            int[] arr = { 1,2,3 };
            int n = 5, k =3;
            obj.printSubArrays(arr, 0, 0);
            int[] nums = { 5, 12, 11, -1, 12 };
            obj.Permute(nums);
            //  obj.LetterCasePermutation("a1b2");
            //obj.Subsets(nums);
            obj.findKthSmallestNumber(nums, k);
        }
    }
}