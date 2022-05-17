using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace misc
{
    public class prac
    {

        public string breakPalindrone(string s)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }
            char[] ch = s.ToCharArray();
            int i = 0;
            for (; i < s.Length / 2; i++)
            {
                if (s[i] != 'a')
                {
                    ch[i] = 'a';
                    break;
                }
            }
            if (i == s.Length - 1)
            {
                ch[ch.Length - 1] = 'b';
            }
            return new String(ch);
        }
        public void PrintSubArrays()
        {
            int[] nos = { 1, 2, 3 };
            string res = "";
            for (int i = 0; i < nos.Length; i++)
            {
                res = "";
                for (int j = i; j < nos.Length; j++)
                {
                    res = res + " " + nos[j];
                    Console.WriteLine(res);
                }
            }
        }
        public int slowest(int[] releaseTimes, String keysPressed)
        {
            int res = 0;
            int i = 0;
            int maxIndex = 0;
            int maxDuration = -1;
            if (i == 0)
            {
                maxDuration = releaseTimes[i] - 0;
            }
            for (i = 1; i < releaseTimes.Length; i++)
            {
                int currentDuration = releaseTimes[i] - releaseTimes[i - 1];
                if (currentDuration > maxDuration || (currentDuration == maxDuration && keysPressed[maxIndex] < keysPressed[i]))
                {
                    maxDuration = currentDuration;
                    maxIndex = i;
                }
            }
            return keysPressed[maxIndex];
        }

        public int noOfIsLands(char[][] grid)
        {
            //base check checking.
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        count++;
                        dfs(grid, i, j);
                    }
                }

            }
            return count;
        }
        private void dfs(char[][] grid, int i, int j)
        {
            if (grid[i][j] != 1)
            {
                return;
            }
            else
            {
                grid[i][j] = '0';
                dfs(grid, i + 1, j);
                dfs(grid, i - 1, j);
                dfs(grid, i, j + 1);
                dfs(grid, i, j - 1);
            }
        }

        public int filltheTruck(int[][] boxTypes, int truckSize)
        {
            Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
            int i = 0;
            int totalLoad = 0;
            while (truckSize > 0)
            {
                int currload = Math.Min(boxTypes[i][0], truckSize);
                totalLoad = totalLoad + currload * boxTypes[i][1];
                i++;
                truckSize = truckSize - currload;
            }


            return totalLoad;
        }

        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            int maxV = verticalCuts[0];
            int maxH = horizontalCuts[0];
            for (int i = 1; i < horizontalCuts.Length; i++)
            {
                maxH = Math.Max(maxH, horizontalCuts[i] - horizontalCuts[i - 1]);
            }
            maxH = Math.Max(maxH, h - horizontalCuts[horizontalCuts.Length - 1]);


            for (int i = 1; i < verticalCuts.Length; i++)
            {
                maxV = Math.Max(maxV, verticalCuts[i] - verticalCuts[i - 1]);
            }
            maxV = Math.Max(maxV, verticalCuts[verticalCuts.Length - 1]);
            BigInteger x = new BigInteger(maxH);
            BigInteger y = new BigInteger(maxV);
            BigInteger sq = x * y;
            sq = sq % 10000007;
            return (int)sq;
        }

        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            double res = 0.0;
            var set = new SortedSet<(double delta, int index, double pass, double total)>();
            int index = 0;
            foreach (var cl in classes)
            {
                double a = cl[0];
                double b = cl[1];
                res = res + a / b;
                set.Add((getDeltaGain(a, b), index++, a + 1, b + 1));

            }
            while (extraStudents > 0)
            {
                var max = set.Max();
            }

            return res;
        }

        private double getDeltaGain(double a, double b)
        {
            double x = (a + 1) / (b + 1) - (a / b);
            return x;
        }
        public int countBinary(string s)
        {
            if (s == null) return 0;
            //001001
            var grp = new List<int>();
            int count = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    count++;
                }
                else
                {
                    grp.Add(count);
                    count = 1;
                }
            }

            grp.Add(count);
            int res = 0;
            for (int i = 0; i < grp.Count; i++)
            {
                count += Math.Min(grp[i], grp[i - 1]);
            }
            return count;
        }

        public void TransactionLogs()
        {
            int[,] logs = { { 3444, 4444, 45
                },
            { 333, 5445, 13
                },
            { 4444, 333, 45
                }
            };
            List<int> result = new List<int>();
            Dictionary<int, int> dt = new Dictionary<int, int>();
            for (int i = 0; i < logs.GetLength(0); i++)
            {

                var row1 = Enumerable.Range(0, logs.GetLength(1))
               .Select(x => logs[i, x])
               .ToArray();

                int log1 = row1[0]; int log2 = row1[1];
                if (dt.ContainsKey(log1))
                {
                    dt[log1]++;
                }
                else
                {
                    dt.Add(log1, 1);
                }
                if (dt.ContainsKey(log2))
                {
                    dt[log2]++;
                }
                else
                {
                    dt.Add(log2, 1);
                }
            }
            foreach (var key in dt)
            {
                if (key.Value >= 2)
                {
                    result.Add(key.Key);
                }
            }
        }
        public void winnnignSequence()
        {
            List<int> temp = new List<int>();
            List<int> res = new List<int>();
            int lower = 3, upper = 10, n = 5;
            for (int i = lower; i <= upper; i++)
            {
                temp.Add(i);
            }
            for (int i = upper - 1; i >= lower; i--)
            {
                temp.Add(i);
            }
            int startingNumber = temp.IndexOf(upper - 1);
            var x = temp.GetRange(startingNumber, n);
        }

        public int NumPairsDivisibleBy60(int[] time)
        {
            int count = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var ele in time)
            {
                int remainder = ele % 60;  //140
                int target = 60 - remainder;
                if (map.ContainsKey(target))
                {
                    count++;
                }
                if(remainder == 0)
                {
                    remainder = 60;
                }
                if (map.ContainsKey(remainder))
                {
                    map[remainder]++;
                }
                else
                {
                    map.Add(remainder, 1);
                }
            }
            return count;
        }
        public long shipMentImbabalance()
        {
            int[] arr = { 1, 2, 3 };
            long ans = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i], max = arr[i];
                for(int j = i+1; j < arr.Length; j++)
                {
                    min = Math.Min(min, arr[j]);
                    max = Math.Max(max, arr[j]);
                    ans = ans + (max - min);
                }
            }
            return ans; 
            
        }
        public void maxProfit()
        {
            int k = 1;
            int n = 4;
            int maxProfit = 0;
            //so I can chose 2*k chunks ==> 2* 2=4.
            // k=3 ,then I can choose 2*k=>  6 chunks.
            int[] profit = { -6, 3, 6, -3 };
            for(int i = 0; i < n / 2; i++)
            {
                int sum = 0;
                for(int j = 0; j < k; j++)
                {
                    int currIndex = i + j;
                    int oppositeIndex = (currIndex + n / 2) % n;
                     sum=sum+profit[currIndex] +profit[oppositeIndex];
                    maxProfit = Math.Max(sum, maxProfit);
                }
            }
            Console.WriteLine(maxProfit);
        }

        public int[] AssignBikes(int[][] workers, int[][] bikes)
        {
            var distanceMap = new Dictionary<int, List<Tuple<int, int>>>();
           
            for (var i = 0; i < workers.Length; i++)
                for (var j = 0; j < bikes.Length; j++)
                {
                    var distance = ManhattanDistance(workers[i], bikes[j]);
                    if (distanceMap.ContainsKey(distance))
                        distanceMap[distance].Add(new Tuple<int, int>(i, j));


                   
                    
                    else
                        distanceMap.Add(distance, new List<Tuple<int, int>>() { new Tuple<int, int>(i, j) });
                }

            var keys = distanceMap.Keys.OrderBy(key => key);
            var usedBike = new HashSet<int>();
            var result = new int[workers.Length];
            for (int i = 0; i < workers.Length; i++)
                result[i] = -1;

            foreach (var key in keys)
            {
                var pairs = distanceMap[key];
                foreach (var pair in pairs)
                {
                    var workerId = pair.Item1;
                    var bikeId = pair.Item2;
                    if (result[workerId] == -1 && !usedBike.Contains(bikeId))
                    {
                        result[workerId] = bikeId;
                        usedBike.Add(bikeId);
                    }
                }
            }

            return result;
        }

        public int ManhattanDistance(int[] worker, int[] bike)
        {
            return Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
        }
      
      

        public int MinCostConnectPoints(int[][] points)
        {
            int cost = 0;
            int l = points.Length;
            var connections = new List<Tuple<int, int, int>>();
            for(int i = 0; i < points.Length; i++)
            {
                for(int j = 0; j < points.Length; j++)
                {
                    int dis = Math.Abs(points[j][0] - points[i][0]) - Math.Abs(points[j][1] - points[i][1]);
                    connections.Add(new Tuple<int, int, int>(dis, i, j)); //map is ready

                }
            }
            //sort the items by dis.
            connections.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            var uf = new UnionFind(l);
            foreach(var con in connections)
            {
                if (uf.IsUnionPosssible(con.Item2, con.Item3))
                {
                    cost = cost + con.Item1;
                }
            }
            return cost;
        }



        public void findCombinations(int n)
        {
            // array to store the combinations
            // It can contain max n elements
            int[] arr = new int[n];

            // find all combinations
            findCombinationsUtil(arr, 0, n, n);
        }

        public void findCombinationsUtil(int[] arr, int index,
                                 int num, int reducedNum)
        {
            // Base condition
            if (reducedNum < 0)
                return;

            // If combination is
            // found, print it
            if (reducedNum == 0)
            {
                for (int i = 0; i < index; i++)
                    Console.Write(arr[i] + " ");
                Console.WriteLine();
                return;
            }

            // Find the previous number
            // stored in arr[]. It helps
            // in maintaining increasing
            // order
            int prev = (index == 0) ?
                                  1 : arr[index - 1];

            // note loop starts from
            // previous number i.e. at
            // array location index - 1
            for (int k = prev; k <= num; k++)
            {
                // next element of
                // array is k
                arr[index] = k;

                // call recursively with
                // reduced number
                findCombinationsUtil(arr, index + 1, num,
                                         reducedNum - k);
            }
        }


      
    }

    public class UnionFind
    {
        int[] parent;
        int[] rank;
        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];

            for(int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int find(int a)
        {
            if (parent[a] == a)
            {
                return a;
            }
            parent[a] = find(parent[a]);
            return parent[a];
        }

        public bool IsUnionPosssible(int a,int b)
        {
            int aRoot = find(a);
            int bRoot = find(b);
            //if both the roots are equal then return false;
            if (aRoot == bRoot)
            {
                return false;
            }
            if(rank[aRoot] < rank[bRoot])
            {
                parent[aRoot] = bRoot;
            }else if (rank[aRoot] > rank[bRoot])
            {
                parent[bRoot] = aRoot;
            }
            else
            {
                parent[bRoot] = aRoot;
                rank[aRoot]++;
            }

            return true;
        }

       
    }
}
