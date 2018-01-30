using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteMap
{
    class CreatorTreeURL
    {
        public Tree<string> TreeURL { get; private set; }
        private int method;
        private string[] urls;
        private string head;
        private string main;


        private void AddToTree(string url)
        {
            string[] splited = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder tempURL = new StringBuilder();
            if (method==1)tempURL.Append(head);
            tempURL.Append(splited[0]);
            string tempURL_S = tempURL.ToString();

            Tree<string> tempTree = TreeURL;
            if(method==0)
            {
                for (int i = 1; i < splited.Length; i++)
                {

                    tempURL_S = splited[i];
                    if(!tempTree.ContainsInFirstNodes(tempURL_S))
                    {
                        tempTree.AddNode(tempURL_S);
                    }
                    tempTree = tempTree.Nodes[tempURL_S];
                }
            }
            else
            {
                for (int i = 1; i < splited.Length; i++)
                {
                    tempURL.Append('/');
                    tempURL.Append(splited[i]);
                    tempURL_S = tempURL.ToString();
                    if (!tempTree.ContainsInFirstNodes(tempURL_S))
                    {
                        tempTree.AddNode(tempURL_S);
                    }
                    tempTree = tempTree.Nodes[tempURL_S];
                }
            }




        }

        public  CreatorTreeURL(string[] urls,string head,string main,int method)
        {
            this.method = method;
            this.urls = urls;
            this.head = head;
            this.main = main;
            if(method==0)
            {
                TreeURL = new Tree<string>(/*head+*/main);
            }
            else TreeURL = new Tree<string>(head+main);

            for (int i=0;i<urls.Length;i++)
            {
                AddToTree(urls[i]);
            }
            //tree.AddBranch("eurabota.ua/job1");
            //tree.Branches[tree.Search("eurabota.ua/job1")].AddBranch("eurabota.ua/job1/1");
            //tree.Branches[0].AddBranch("eurabota.ua/job1/2");
            //tree.AddBranch("eurabota.ua/job2");
            //tree.Branches[1].AddBranch("eurabota.ua/job2/1");
            //tree.Branches[1].AddBranch("eurabota.ua/job2/2");
        }


        //public string ToOPML()
        //{
        //    Tree.ToOPML();
        //}


    }
}
