using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace misc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  int[] time = { 30, 20, 150, 100, 40 };
            //  int[] arr = { 1, 1, 2, 45, 46, 46 };int target = 47;
            //  // NumPairsDivisibleBy60(time);
            //  // twoSumUniq(arr, target);
            //  // CountBinarySubstrings("001101");
            //  string s = "Let's take LeetCode contest";
            //  List<List<int>> l = new List<List<int>>();
            //  List<int> x = new List<int> { 1, 1, 1 };
            //  l.Add(x);
            //   x = new List<int> { 0, 1, 0 };
            //  l.Add(x);
            //  x = new List<int> { 0, 0, 0 };
            //  l.Add(x);
            //  x = new List<int> { 1, 1, 0 };
            //  l.Add(x);
            //  //  gridProblem(l);
            //  //  simpleCipher("vtaog",2);
            //  // simpleCipher1("vtaog", 2);
            //  //  ReverseWords(s);
            //  string mono = "THTHTH";
            //  // MinFlipsMonoIncr(mono);
            //  // int[] team = { 3, 4, 3, 1, 6, 5 };int teamSize = 3;
            //  // countTeams(team,teamSize);
            //  string test = "abcabc";
            //  // findAllKDisctintChars(test, 3);
            //  //   var result= print_all_sum();
            //  test obj = new test();
            //  // obj.printSubArrays();
            //  int[] nums = { 1, 2, 3, 4, 5, 4, 1 };
            //  int maxSize = 4;
            //  // obj.printLRUMisses(nums, maxSize);
            //  int[] arr1= { 100, 100, 80, 70, 60 }; int cutOffrank = 4;
            ////  obj.CutOffRank(arr1, cutOffrank);
            //  int[] abilites = {1,2,3,4 };
            //  int noOfProccess = 15;
            //  int numberOfProcessors = abilites.Length;

            //  // Console.WriteLine(obj.MultiProcessors(numberOfProcessors, abilites, noOfProccess));
            //  int[] coins = { 1, 2, 5 }; int amount = 11;
            //  Console.WriteLine(obj.CoinChange(coins,amount));
            prac obj = new prac();
            obj.maxProfit();
        }

     
        private static List<string> findAllKDisctintChars(string s,int k)
        {
            //lets say s is awaglknagawunagwkwagl and k=4;
           
            List<string> res = new List<string>();
           
                for (int i = 0; i <= s.Length - k; i++)
                {
                string sub = s.Substring(i, k);
                    if (!checkIfContainRepeat(sub))
                    res.Add(s.Substring(i, k));
                }
            
            return res;

        }

      
        private static bool checkIfContainRepeat(string s)
        {
            HashSet<char> set = new HashSet<char>();
            //char[] ch = s.ToCharArray();
            foreach(var ch in s)
            {
                if (!set.Contains(ch))
                {
                    set.Add(ch);
                }
                else
                {
                    //the given substring has a character which is already prsent in the hashSet,hence it doesnot have unique characters
                    //so return false;
                    return true;
                }
            }
            return false;
        }
        private static int countTeams(int[] team,int teamSize)
        {
            int res = 0;
            Array.Sort(team);
            int i = 0, j = teamSize - 1;
            while (j < team.Length)
            {
                if (team[j] - team[i] <= 2)
                {
                    //means we found a team
                    res++;
                    i = j + 1;
                    j = j+ teamSize;
                }
                else
                {
                    i++;j++;
                }
            }

            return res;
        }

        

        public static int NumPairsDivisibleBy60(int[] time)
        {

            int res = 0;
            Dictionary<int, int> dicReminder = new Dictionary<int, int>();
            foreach (var t in time)
            {
                int remainder = t % 60;//
                int target = 60 - remainder;//，
                if (dicReminder.ContainsKey(target))//
                {
                    res += dicReminder[target];
                }
                if (remainder == 0)
                {
                    remainder = 60;
                }

                if (!dicReminder.ContainsKey(remainder))
                {
                    dicReminder.Add(remainder, 1);
                }
                else
                {
                    dicReminder[remainder] = dicReminder[remainder] + 1;
                }

            }
            return res;
        }

        public static int twoSumUniq(int[] nums,int target)
        {

            Array.Sort(nums);
            int i = 0;
            int j = nums.Length - 1;
            int ans = 0;
            while (i < j)
            {
                int sum = nums[i] + nums[j];
                if (sum < target)
                {
                    i++;
                }
                else if (sum > target)
                {
                    j--;
                }
                else
                {
                    ans++;
                    i++;
                    j--;
                    while (i < j && nums[i] == nums[i - 1])
                    {
                        i++;
                    }
                    while (i < j && nums[j] == nums[j + 1])
                    {
                        j--;
                    }
                }
            }
            return ans;
        }
        public static int CountBinarySubstrings(string s)
        {
            int prevRunLength = 0, curRunLength = 1, res = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s.ElementAt(i) == s.ElementAt(i - 1)) curRunLength++;
                else
                {
                    prevRunLength = curRunLength;
                    curRunLength = 1;
                }
                if (prevRunLength >= curRunLength) res++;
            }
            return res;
        }
        public static string ReverseWords(string s)
        {

            var buff = new StringBuilder();
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    while (stack.TryPop(out char v))
                    {
                        buff.Append(v);
                    }
                    buff.Append(' ');
                }
                else
                {
                    stack.Push(c);
                }
            }
            while (stack.TryPop(out char v))
            {
                buff.Append(v);
            }
            return buff.ToString();
        }
        public static String simpleCipher(String encrypted, int k)
        {
            char[] _encrypted = encrypted.ToCharArray();
            for (int i = 0; i < encrypted.Length; i++)
            {
                char x = _encrypted[i];
                // if the previous kth element is greater than 'A'
                if (x - k >= 65)
                {
                    _encrypted[i] = (char)(x - k);
                }
                //if ascii code of kth previous element if less than that of A add 26 to it
                else
                {
                    _encrypted[i] = (char)(x - k + 26);
                }
            }
            Console.Write(new String(_encrypted));
            return new String(_encrypted);
        }

        public static int MinFlipsMonoIncr(string S)
        {
            int H = 0, increasing_seq = 0; //HHTHTT

            for (int i = 0; i < S.Length; i++)
            {
                if ((S[i] - 'H') == 0)
                    H++;
                else
                    increasing_seq++;

                increasing_seq = Math.Max(increasing_seq, H);
            }
            Console.WriteLine(S.Length - increasing_seq);
            return S.Length - increasing_seq;
        }

//        Ts = flips = 0
//for c in s:
//    if c == 'T':
//        Ts += 1
//    else:
//        flips = min(flips+1, Ts)
//return flips
        public static int gridProblem(List<List<int>> grid)
        {

            int ans = 0;
            int sum=0, prev = 0;
          foreach(var ele in grid)
            {
                sum = 0;
                var row = ele;
                foreach(var number in row)
                {
                    sum = sum + number;
                }
                if (sum > 0)
                {
                    ans = ans + prev * sum;
                    prev = sum;
                }
            }

            return ans;
        }


        static void print_all_sum_rec( int target, int current_sum,   int start, List<List<int>> output,  List<int> result)
        {

            if (target == current_sum)
            {
               result.RemoveAt(0);
                output.Add(result);
            }

            for (int i = start; i < target; ++i)
            {
                int temp_sum = current_sum + i;
                if (temp_sum <= target)
                {

                    result.Add(i);
                    print_all_sum_rec(target, temp_sum, i, output, result);
                    result.Remove(result.Count() - 1);
                }
                else
                {
                    return;
                }
            }
        }
        static List<List<int>>  print_all_sum()
        {
            int target = 4;
            List<List<int>> output = new List<List<int>>();
            List<int> result = new List<int>();
            print_all_sum_rec(target, 0, 1, output, result);
          
            return output;
        }
    }
}