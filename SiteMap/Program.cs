using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteMap
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //int test= @"https://www.eurabota.ua/job-permissions-austria".IndexOf(@"wewew") + 1;
            //Console.Write()
            Application.Run(new Form1());



            //string[] lines = FileWork.ReadFromFile(Constants.pathURLS);
            //string[] lines2 = Strings.Cut(lines);
            //string head = Strings.SplitFirst(lines[0], '.', true);

            //string main = Strings.SplitFirst(lines2[0], '/', false);
            //Constants con = new Constants(main);


            //CreatorTreeURL creator = new CreatorTreeURL(lines2, main, head);

            //Strings strs = new Strings(con);

            //string content = strs.CreateString(creator.tree.ToString(true));


            //FileWork.WriteToFile(Constants.pathOPML, content);


        }
    }
}
