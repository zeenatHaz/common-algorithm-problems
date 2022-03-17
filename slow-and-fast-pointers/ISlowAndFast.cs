using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slow_and_fast_pointers
{
    public interface ISlowAndFast
    {
        public bool HasCycle(ListNode head);
        public bool IsHappy(int n);
    }
}
