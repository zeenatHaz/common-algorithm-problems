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
    }
}
