using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;

namespace linked_list
{
    public interface ILl
    {    
        public ListNode ReverseList(ListNode head);
        public ListNode ReverseBetween(ListNode head, int left, int right);
        public ListNode ReverseKGroup(ListNode head, int k);
    }
}
