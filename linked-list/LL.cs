using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list
{
    public class LL : ILl
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode prev = null, current = head, temp = null;

            while(current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;

            }
            head = prev;
            return head;
        }

        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null)
            {
                return head;
            }
            ListNode l1 = this.getNodeByPos(head,left);
            ListNode l2 = this.getNodeByPos(head,right);
            //swap now
            int temp = l1.val;
            l1.val = l2.val;
            l2.val = temp;
            right--;
            left++;
            return head;

        }

        private ListNode getNodeByPos(ListNode head, int pos)
        {
            int counter = 1;
            while (head != null)
            {
                if (counter == pos)
                {
                    break;
                }
                counter++;
                head = head.next;
            }
            return head;
        }
        int position = 0;

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;
            while (curr != null && count != k)
            {
                curr = curr.next;
                count++;
            }
            if (count == k)
            {
                curr = ReverseKGroup(curr, k);
                while (count-- > 0)
                {
                    ListNode tmp = head.next;
                    head.next = curr;
                    curr = head;
                    head = tmp;
                }
                head = curr;
            }
            return head;

        }

     
        // Recursive function to print all
        // possible subarrays for given array
        public void printSubArrays(int[] arr,
                            int start, int end)
        {
            
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
                for (int j = i+1; j < arr.Length; j++)
                {
                    Console.WriteLine(arr[j]);
                }
                Console.WriteLine("====================Next================");
            }
        }

        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {

            if (boxTypes == null || boxTypes.Length == 0)
                return 0;

            Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
            int res = 0, i = 0;
            while (truckSize > 0 && i < boxTypes.Length)
            {
                int cnt = Math.Min(truckSize, boxTypes[i][0]);
                res += cnt * boxTypes[i][1];
                truckSize -= cnt;
                i++;
            }

            return res;
        }

        IList<IList<int>> Permutes = new List<IList<int>>();

        public IList<IList<int>> Permute(int[] nums)
        {
            GetPermute(new List<int>(), nums);

            return Permutes;
        }

        private void GetPermute(List<int> list, int[] nums)
        {
            List<int> tempList = null;

            if (list.Count != nums.Length)
            {
                for (int i = 0; i <= nums.Length - 1; i++)
                {
                    if (!list.Contains(nums[i]))
                    {
                        tempList = new List<int>(list);
                        tempList.Add(nums[i]);
                        GetPermute(tempList, nums);
                    }
                }
            }
            else
             
                Permutes.Add(list);
        }
        public int CountElements(int[] nums)
        {
            Array.Sort(nums);
            //2 7 11 15    //-3 3 3 90
            int c = 0;
            HashSet<int> set = new HashSet<int>(nums);
            foreach(var ele in set)
            {
                bool x = set.Any(p => p < ele);
                bool y = set.Any(p => p > ele);
                if(x&& y)
                {
                    c++;
                }
            }
            return c;
        }
        public IList<string> LetterCasePermutation(string s)
        {
            IList<string> res = new List<string>();
            res.Add(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    int n = res.Count;
                    for (int j = 0; j < n; j++)
                    
                    {
                        char[] str = res[j].ToCharArray();
                        if (char.IsUpper(s[i]))
                        {
                            str[i] = char.ToLower(s[i]);
                        }
                        else
                        {
                            str[i] = char.ToUpper(s[i]);
                        }
                        res.Add(new string(str));
                    }
                }
            }
            return res;


        }
        public IList<IList<int>> Subsets(int[] nums)
        {

            List<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
                return res;

            backtracking(nums, 0, new List<int>(), res);
            return res;
        }

        private void backtracking(int[] nums, int start, List<int> list, List<IList<int>> res)
        {
            res.Add(new List<int>(list));
            for (int i = start; i < nums.Length; i++)
            {
                list.Add(nums[i]);
                backtracking(nums, i + 1, list, res);
                list.RemoveAt(list.Count - 1);
            }
        }

        public  int findKthSmallestNumber(int[] nums, int k)
        {
            //let the input be   1, 5, 12, 2, 11, 5 }, 4 =>1,2,5,5,11,12
            List<int> minHeap = new List<int>();
            for(int i = 0; i < k; i++)
            {
                minHeap.Add(nums[i]);
            }
            for(int i=k;i<nums.Length; i++)
            {
                minHeap.Sort();
                if(minHeap.FirstOrDefault() < nums[i])
                {
                    minHeap.RemoveAt(0);
                    minHeap.Insert(0,nums[i]);
                }
            }
            return minHeap[0];
        }

    }

   

}
