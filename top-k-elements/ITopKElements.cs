using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_k_elements
{
    public  interface ITopKElements
    {

        public List<int> topKElements(List<int> elements, int k);

        public void topKElements_minHeap(List<int> elements, int k);

        public void topKElements_minHeap_smallest(List<int> elements, int k);

        public int FindKthLargest(List<int> elements, int k);

        public int[][] KClosest(int[][] points, int k);

        public IList<string> TopKFrequent(string[] words, int k); //LC 692

        public int ConnectSticks(int[] arr);

        public int maxDistinctNum(int[] a, int n, int k); //GOG



    


    }
}
