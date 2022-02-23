namespace top_k_elements
{
    public class Program
    {
        public static void Main(String[] args)
        {
            TopKElements obj = new TopKElements();
            List<int> list = new List<int> { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            //obj.topKElements_minHeap(list,k);

            //Console.WriteLine("Top minimum k elements =============");
            //obj.topKElements_minHeap_smallest(list, k);

            Console.WriteLine("kth largest element ============="+ obj.FindKthLargest(list, k));
            
            Console.ReadLine();

        }
    }
}