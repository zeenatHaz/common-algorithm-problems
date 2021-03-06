
using common;
namespace slow_and_fast_pointers
{
    public class SlowAndFast : ISlowAndFast
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            ListNode slow = head, fast = head;
            while(fast!=null && fast.next != null)
            {
                slow = fast.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    //means there is a loop becuase they met each other.
                    //It is a typical hare and rabbit prb.
                    return true;
                }
            }

            return false;
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            if (head == null)
                return null;
            while (fast != null && fast.next != null)
            {
                slow = fast;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return slow;
                }
            }

            return null;
        }

        public bool IsHappy(int n)
        {

            HashSet<int> set = new HashSet<int>();
            while (n != 1 && !set.Contains(n))
            {
                set.Add(n);
                int result = 0;
                while (n > 0)
                {
                    int d = n % 10;
                    result = result + (d * d);
                    n = n / 10;
                }
                n = result;
            }
            if (n == 1)
            {
                return true;
            }
            return false;
        }

        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;

            while (fast != null && fast.next != null)
            {

                slow = slow.next;
                fast = fast.next.next;

            }

            return slow;
        }

        public bool IsPalindrome(ListNode head)
        {
            //1 -> 2 -> 2 -> 1 -> NULL

            //1
            //2
            //2
            //1
            if (head == null)
                return true;

            Stack<int> stack = new Stack<int>();
            ListNode curr = head;
            while (curr != null)
            {
                stack.Push(curr.val);
                curr = curr.next;
            }

            curr = head;
            while (curr != null)
            {
                if (stack.Count == 0 || stack.Peek() != curr.val)
                    return false;

                stack.Pop();
                curr = curr.next;
            }

            return stack.Count == 0;
        }
    }
}
