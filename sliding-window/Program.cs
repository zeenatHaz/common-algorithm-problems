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
            obj.FindSubstring(s, words);

        }
    }
}