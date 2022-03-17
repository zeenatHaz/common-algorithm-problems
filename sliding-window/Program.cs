using slidingWindow;
namespace slidingWindow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sliding obj = new Sliding();
            string s = "barfoothefoobarman";
            string[] words = { "foo", "bar" };
            //obj.FindSubstring(s, words);
            int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
           // obj.lengthOfLongestSubstringKDistinct("WORLD", 4);
            Console.WriteLine("max is:"+ obj.maxSumSubArray(arr, 4));

            obj.characterReplacement("AABABBA", 1);
            Console.ReadLine();
        }
    }
}