namespace bit_operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bit obj = new Bit();
            int[] arr = { 1, 2, 3, 4, 1, 2, 3, };

            Console.WriteLine("The single number is :" + obj.SingleNumber(arr));
            Console.ReadLine();
        }   
    }
}