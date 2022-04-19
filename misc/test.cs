using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misc
{
    public class test
    {
        //1/ Palindrome break/
        public string breakPalidrone(string s)
        {
            if (s.Length == 0 || s.Length <= 1) return "";
            char[] ch = s.ToCharArray();
            int i = 0;
            for (; i < ch.Length / 2; i++)
            {
                if (ch[i] != 'a')
                {
                    ch[i] = 'a';
                    break; // break out as we have successfully replaced it with the smallest character.
                }
            }
            if (i == s.Length / 2)
            {
                //means it could not replace chars with 'a'
                //then make the last chacrater b.
                ch[s.Length - 1] = 'b';
            }
            return new string(ch);
        }
        public int noOfSwapsToSort(int[] arr)
        {
            int count = 0;
            int[] temp = new int[arr.Length];
            Array.Copy(temp, arr, arr.Length);
            Array.Sort(temp);
            //now check if the elements are not in the correct position,if not just swap with the correct position.
            for (int i = 0; i < arr.Length; i++)
            {
                if (temp[i] != arr[i])
                {
                    //means position is not right.
                    count++;
                    int correctIndex = getIndexOfElement(arr, temp[i]);
                    swap(arr, i, correctIndex);
                }
            }


            return count;
        }
        private int getIndexOfElement(int[] arr, int ele)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ele)
                {
                    return i;
                    break;
                }
            }
            return -1;
        }
        private void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public void printSubArrays()
        {
            int[] arr = { 1, 2, 3 };
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res = "";
                for (int j = i; j < arr.Length; j++)
                {
                    res = res + "  " + arr[j];
                    Console.WriteLine(res);
                }
            }
        }
        public void printLRUMisses(int[] arr, int maxSize)
        {
            if (arr == null) return;
            int count = 0;
            List<int> lst = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (lst.Contains(arr[i]))
                {
                    lst.Remove(arr[i]);
                }
                else
                {
                    //it is a miss.so increment the count
                    count++;
                    //if the size of the array is more than the cache size.,then remove the first element from the lst 
                    if (lst.Count == maxSize)
                    {
                        lst.RemoveAt(0);
                    }


                }
                lst.Add(arr[i]);
            }
            Console.WriteLine($"the no of misses is :{count}");
        }
        public class Debt
        {
            public String borrower = "";
            public String lender = "";
            public int amount = 0;

            Debt(String b, String l, int a)
            {
                borrower = b;
                lender = l;
                amount = a;
            }
        }
        //debt  -->
        //Borrower    Lender   Amt  
        //Alex        blake     2
        //Blake       Alex      2

        public List<string> negativeDebt(List<Debt> records)
        {
            List<string> res = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Debt record in records)
            {

                if (dict.ContainsKey(record.lender))
                {
                    dict[record.lender] = dict[record.lender] + record.amount;
                }
                else
                {
                    dict.Add(record.lender, 0);
                }
                if (dict.ContainsKey(record.borrower))
                {
                    dict[record.borrower] = dict[record.borrower] - record.amount;
                }
                else
                {
                    dict.Add(record.borrower, 0);
                }
            }

            var list = dict.OrderBy(p => p.Value).ToList();
            int min = list.FirstOrDefault().Value;
            if (min >= 0)
            {
                //means there is no negative balace.
                return res;
            }

            foreach (var ele in dict)
            {
                res.Add(ele.Key);
            }
            res.Sort();
            return res;

        }
        public int CutOffRank(int[] arr, int cutOffrank)
        {
            int res = 0;
            Array.Sort(arr);
            List<Student> students = new List<Student>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var ele in arr)
            {
                if (dict.ContainsKey(ele))
                {
                    dict[ele]++;
                }
                else
                {
                    dict.Add(ele, 1);
                }
            }
            int index = 1;
            var response = dict.OrderByDescending(p => p.Key).ToList();
            foreach (var ele in response)
            {
                int noOfStudents = ele.Value;
                Student objS = new Student();
                for (int i = 0; i < noOfStudents; i++)
                {
                    objS.Id = ele.Key;
                    objS.Rank = index;
                    students.Add(objS);
                }
                index = index + noOfStudents; //next rank.

            }


            foreach (var ele in students)
            {
                Console.WriteLine("Student with ID " + ele.Id + " has a  rank of  = :" + ele.Rank);

            }
            var result = students.Where(p => p.Rank <= cutOffrank).ToList();

            Console.WriteLine("======================");
            foreach (var ele in result)
            {
                Console.WriteLine(ele.Id + "rank is :" + ele.Rank);
            }

            return result.Count;
        }

        public class Student
        {
            public int Id { get; set; }
            public int Rank { get; set; }
        }

        /////////////////////////////////////////////////
        ///MultiProcessor Problem-->Class Priority Queue.
        ///
        private static bool isElement(int i)
        {
            return true;
        }
        public int MultiProcessors(int num, int[] ability, int noOfProcesses)
        {
            List<int> pq = new List<int>();
            ability = ability.OrderByDescending(p => p).ToArray();
            int countPerSecond = 0;
            foreach (var ele in ability)
            {
                pq.Add(ele);


            }

            while (noOfProcesses > 0)
            {
                int abi = pq.ElementAt(0);
                pq.Remove(abi);
                noOfProcesses = noOfProcesses - abi;
                pq.Add(abi / 2);
                countPerSecond++;
                pq = pq.OrderByDescending(p => p).ToList();
            }
            return countPerSecond;
        }
        public class customComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == y)
                {
                    return 0;
                }
                if (y >= x)
                {
                    return 1;
                }
                return -1;
            }
        }

        public int CoinChange(int[] coins, int amount)
        {
            if (amount < 1) return 0;
            int[] visit = new int[amount];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(amount);
             int idx = 1;
            int count = 0;
            while (queue.Count!=0)
            {
                count++;
                int size = idx; idx = 0;
                for (int i = 0; i < size; i++)
                {
                    int cur = queue.Dequeue();
                    foreach(var item in coins)
                    {
                        int rem = cur - item;
                        if (rem == 0) return count;
                        if (rem > 0 && visit[rem] == 0)
                        {
                            queue.Enqueue(rem);
                            visit[rem] = 1;
                            idx++;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
