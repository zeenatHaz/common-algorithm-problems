namespace cyclic_sort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cyclic obj = new Cyclic();
            int[] arr = { -2 ,-3,4};
            int n = 5, k = 2;
            Console.WriteLine(obj.printKMissing(arr, n, k));
            
        }
    }
}