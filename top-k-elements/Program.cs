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
            int[] arr = {1,8,3,5,10};
            int[] a = { 5, 7, 5, 5, 1, 2, 2 };
            int k1 = 3;
            Console.WriteLine("Min cost to connect sticks =============" + obj.ConnectSticks(arr));
            Console.WriteLine("Max Distinct Nos =============" + obj.maxDistinctNum(a,a.Length,k1));

            FreqStack fq = new FreqStack();
            fq.Push(9);
            fq.Push(4);
            fq.Push(4);
            fq.Push(4);
            fq.Push(4);
            fq.Push(9);
            fq.Push(9);
            fq.Push(9);
            fq.Push(9);
            fq.Push(9);
            fq.Push(9);
            fq.Push(9);
            fq.Pop();
            fq.Pop();
            fq.Pop();


            string makeGood = "leEeetcode";
            string s = obj.MakeGood(makeGood);
            Console.ReadLine();

        }
    }
}