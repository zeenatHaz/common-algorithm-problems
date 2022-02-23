using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_k_elements
{
    public class TopKElements : ITopKElements
    {
        //using two methods.
        //first sort and reverse method and then return the first k elements,
        //time Complexity:O(nLogn)   //space:O(n)
        public List<int> topKElements(List<int> elements, int k)
        {
            //using two methods.
            //first sort and reverse method and then return the first k elements,
            //time Complexity:O(nLogn)   //space:O(n)

            var result = elements.OrderByDescending(p => p).Take(k).ToList();
            return result;

        }

        public void topKElements_minHeap(List<int> elements, int k)
        {

            //time Complexity:O(nLogn)   //space:O(n)
            //create a minHeap with firs k elements.

            //Time Complexity: O(k * log(k) + (n - k) * log(k)) without sorted output.
            //If sorted output is needed then O(k * log(k) + (n - k) * log(k) + k * log(k))
            //so overall it is O(k * log(k) + (n - k) * log(k))
            List<int> minHeap = new List<int>();
            minHeap = elements.Take(k).ToList();

            for(int i = k; i < elements.Count; i++)
            {
                minHeap = minHeap.OrderBy(p => p).ToList();

                if(minHeap[0]> elements[i])
                {
                    continue;
                }
                else
                {
                    minHeap.RemoveAt(0);
                    minHeap.Add(elements[i]);
                }
            }

            foreach (int i in minHeap)
            {
                Console.Write(i + " ");
            }
        }


        public void topKElements_minHeap_smallest(List<int> elements, int k)
        {
            List<int> minHeap = new List<int>();

            minHeap = elements.Take(k).ToList();

            for(int i = k; i < elements.Count; i++)
            {
                minHeap= minHeap.OrderByDescending(p => p).ToList();

                //compare the root of the minHeap with the ith element.
                if (elements[i]< minHeap[0] )
                {
                    minHeap.RemoveAt(0);
                    minHeap.Add(elements[i]);
                }
                else
                {
                    continue;
                }
            }


            foreach (int i in minHeap)
            {
                Console.Write(i + " ");
            }

        }

        public int FindKthLargest(List<int> elements, int k)
        {
            //time Complexity:O(nLogn)   //space:O(n)
            //create a minHeap with firs k elements.

            //Time Complexity: O(k * log(k) + (n - k) * log(k)) without sorted output.
            //If sorted output is needed then O(k * log(k) + (n - k) * log(k) + k * log(k))
            //so overall it is O(k * log(k) + (n - k) * log(k))
            List<int> minHeap = new List<int>();
            minHeap = elements.Take(k).ToList();

            for (int i = k; i < elements.Count; i++)
            {
                minHeap = minHeap.OrderBy(p => p).ToList();

                if (minHeap[0] > elements[i])
                {
                    continue;
                }
                else
                {
                    minHeap.RemoveAt(0);
                    minHeap.Add(elements[i]);
                }
            }

            foreach (int i in minHeap)
            {
                Console.WriteLine(i + " ");
            }

            return minHeap[0];
        }

        public int[][] KClosest(int[][] points, int k)
        {
            return points.OrderBy(x => x[0] * x[0] + x[1] * x[1]).Take(k).ToArray();

            //sorted dictionary solution.

        }
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!map.ContainsKey(word))
                {
                    map[word] = 0;
                }
                map[word] += 1;
            }

            return map.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).Take(k).ToList();
        }

        public int ConnectSticks(int[] sticks)
        {
            var pq = new SortedList<int, int>();
            foreach (var stick in sticks)
            {
                if (pq.ContainsKey(stick))
                    pq[stick]++;
                else
                    pq[stick] = 1;
            }

            var result = 0;
            while (pq.Count > 1 || (pq.Count == 1 && pq.Values.First() > 1))
            {
                var x = pq.Keys.First();
                if (pq[x] == 1)
                    pq.Remove(x);
                else
                    pq[x]--;

                var y = pq.Keys.First();
                if (pq[y] == 1)
                    pq.Remove(y);
                else
                    pq[y]--;

                var cost = x + y;
                result += cost;

                if (pq.ContainsKey(cost))
                    pq[cost]++;
                else
                    pq[cost] = 1;
            }

            return result; ;
        }
    }
}
