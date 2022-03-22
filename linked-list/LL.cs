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
    }
}
