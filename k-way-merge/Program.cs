namespace k_way_merge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            kway obj = new kway();
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            obj.MedianSlidingWindow(nums, k);
        }
    }
}