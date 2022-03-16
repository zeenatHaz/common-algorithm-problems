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
            while (pq.Count > 1)
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

        public int maxDistinctNum(int[] a, int n, int k)
        {
            int res = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for(int i = 0; i < a.Length; i++)
            {
                if (dict.ContainsKey(a[i]))
                {
                    if(k>0)
                    k--;
                }
                else
                {
                    dict.Add(a[i], 1);
                }
            }
            //if k is equal to 0 ,there may be duplicates..
            //so put the 
            //1 1 2 2 3 4 4 5
            //dict : 1 :1
                     // 2:1 
                     //k==0
                     //3:1
                     //4:1
                     //

            res = dict.Count();
        
            return res;
          
        }


        public string MakeGood(string s)
        {

            if (s == null || s.Length < 2)
                return s;

            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (stack.Count > 0 && IsSameCharButDifferentCase(stack.Peek(), c))
                    stack.Pop();
                else
                    stack.Push(c);
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
                sb.Insert(0, stack.Pop());
           
            return sb.ToString();
        }

        public bool IsSameCharButDifferentCase(char c1, char c2)
        {
            return Math.Abs(c1 - c2) == 32;
        }



        public int FindMaximizedCapital( )
        {
            int k = 2, W = 0;
            int[] Profits = { 1,2,3};
            int[] Capital = { 0,1,1};
            // using sorted List for RemoveAt function
            // minHeap for captial
            SortedList<int, int> projectsPq = new SortedList<int, int>(Comparer<int>.Create((x, y) => x != y ? x.CompareTo(y) : 1));

            for (int i = 0; i < Profits.Length; i++)
            {
                projectsPq.Add(Capital[i], Profits[i]);
            }


            // maxHeap for profit
            SortedList<int, int> feasible = new SortedList<int, int>(Comparer<int>.Create((x, y) => x != y ? y.CompareTo(x) : 1));

            while (k > 0)
            {
                while (projectsPq.Count != 0 && projectsPq.First().Key <= W)
                {
                    feasible.Add(projectsPq.First().Value, projectsPq.First().Value);
                    projectsPq.RemoveAt(0);
                }

                if (feasible.Count == 0)
                {
                    return W;
                }
                W += feasible.First().Value;
                feasible.RemoveAt(0);
                k--;
            }

            return W;
        }
    }



    ////LC 895
    ///
    public class FreqStack
    {
        private Dictionary<int, int> freDic;
        private Dictionary<int, Stack<int>> priorityOrder;        
        int maxFrequency = 0;// points to the stack with max freq.
        public FreqStack()
        {
            freDic = new Dictionary<int, int>();
            priorityOrder = new Dictionary<int, Stack<int>>();
        }

        public void Push(int x)
        {

            if (freDic.ContainsKey(x))
            {
                freDic[x]++;
            }
            else
            {
                freDic.Add(x, 1);
            }

            int curValFreq = freDic[x];
            if (maxFrequency < curValFreq)
                maxFrequency = curValFreq;

            if (priorityOrder.ContainsKey(curValFreq))
            {
                priorityOrder[curValFreq].Push(x);
            }
            else
            {
                var stack = new Stack<int>();
                stack.Push(x);
                priorityOrder.Add(curValFreq, stack);
            }
        }

        public int Pop()
        {
            var stack = priorityOrder[maxFrequency];
            int popVal = stack.Pop();
            if (stack.Count == 0)
                maxFrequency--;
            freDic[popVal]--;
            return popVal;
        }
    }

}
