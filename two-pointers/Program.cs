

namespace two_pointers
{

    public class Program
    {
        public static void Main(String[] args)
        {
            TwoPointer obj = new TwoPointer();
            string[] nums = { "777", "7", "77", "77" };
            string target = "7777";
         //   obj.NumOfPairs(nums, target);
            int[] num = { 10, 5, 2, 6 };
            int k = 100;
            obj.NumSubarrayProductLessThanK(num, k);
        }
    }
    
}