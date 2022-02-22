using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slidingWindow
{
    public interface ISliding
    {
        public IList<int> FindSubstring(string s, string[] words);//LC30
    }
}
