using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteMap
{
    static class Class1
    {
        static public void Main()
        {
            string s = "https://www.eurabota.ua/news";
            s = s.TrimStart(new char[] { '.' });
        }
    }
}
