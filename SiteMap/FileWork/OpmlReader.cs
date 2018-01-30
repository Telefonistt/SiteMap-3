using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using System.Text;

namespace SiteMap
{
    static class OpmlReader
    {
        static private string opmlFilePath;
        static public string Source { get; private set; }
        static public string titleTagOpen = "<title>";
        static public string titleTagClose { get; private set; } = "</title>";
        static public string outlineTagOpen { get; private set; } = @"<outline ";
        static public string outlineTagClose { get; private set; } = @"</outline>";
        static public string textOption { get; private set; } = @"text=""";

        static private int currentIndex;
        static private string currentLexem;
        static private string currentOptionValue;

        static public string Title { get; private set; }


        static private void SetTitle()
        {
            int startTitleIndex = Source.IndexOf(titleTagOpen) + titleTagOpen.Length;
            int endTitleIndex = Source.IndexOf(titleTagClose, startTitleIndex);
            Title = Source.Substring(startTitleIndex, endTitleIndex - startTitleIndex);
            currentIndex = endTitleIndex + titleTagClose.Length;
        }

        static public void Load(string opmlFilePath)
        {
            OpmlReader.opmlFilePath = opmlFilePath;
            Source = File.ReadAllText(opmlFilePath);

            SetTitle();
        }

        static public void ReadNext()
        {
            currentIndex = Source.IndexOf("outline", currentIndex);
            if (Source[currentIndex - 1] == '<')
            {
                //XmlReader.Create()
            }

        }



        static public TreeNode ToTreeNode()
        {
            TreeNode treeNode1 = new TreeNode();

            return treeNode1;
        }

    }
}



