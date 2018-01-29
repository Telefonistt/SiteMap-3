using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteMap
{
    class Strings
    {
        Constants cons;
        public string CreateOPML(string content)
        {
            StringBuilder output = new StringBuilder();
            output.Append(Constants.documentHead);
            output.Append(content);
            output.Append(Constants.documentFooter);
            return output.ToString();
        }

        public Strings(Constants constants)
        {
            cons = constants;
        }
        /// <summary>
        /// Обрезает строки из списка. При первом вхождении символа отсекается первая часть строки.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static string[] CutStringList(string[] lines,string pattern)
        {
            int index;

            string[] lines2 = new string[lines.Length];
            for(int i=0;i<lines.Length;i++)
            {
                 index = lines[i].IndexOf(pattern);
                if (index != -1)
                {
                    index += pattern.Length;
                    lines2[i] = lines[i].Substring(index);
                }
                else
                {
                    lines2[i] = lines[i];
                } 
                
            }
            return lines2;
        }
         
        public static string SplitFirst(string str,char ch,bool b)
        {
            StringBuilder temp = new StringBuilder();
            int i = 0;
            do
            {
                temp.Append(str[i]);
                i++;
            }
            while (str[i] != ch);
            if(b==true)
            {
                temp.Append(str[i]);
            }
            
            return temp.ToString();
        } 
    }
}
