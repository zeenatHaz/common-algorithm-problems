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
               
                var row1= Enumerable.Range(0, logs.GetLength(1))
               .Select(x => logs[i, x])
               .ToArray();

                int log1 = row1[0]; int log2 = row1[1];
                if (dt.ContainsKey(log1)){
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
            foreach(var key in dt)
            {
                if(key.Value >= 2)
                {
                    result.Add(key.Key);
                }
            }
        }
    }
}
