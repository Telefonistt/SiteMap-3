using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SiteMap
{
   static class OpmlReader
    {
        static private string opmlFilePath;
        static public string Source { get; private set; }
        static private StringBuilder tempSource=new StringBuilder();
        static private string titleTagOpen = "<title>";
        static private string titleTagClose = "</title>";

        static private string outlineTagOpen = @"<outline";
        static private string outlineTagClose = @"</outline";

        static private string closeTag = @"</";
        static private string textOption = @"text=""";

        static private int currentIndex;

        static public string Title { get; private set; }


        static private void SetTitle()
        {
            int startTitleIndex= Source.IndexOf(titleTagOpen)+titleTagOpen.Length;
            int endTitleIndex= Source.IndexOf(titleTagClose,startTitleIndex);
            Title = Source.Substring(startTitleIndex, endTitleIndex - startTitleIndex);
        }

        static public void Load(string opmlFilePath)
        {
            OpmlReader.opmlFilePath = opmlFilePath;
            Source= File.ReadAllText(opmlFilePath);
            tempSource.Append(Source);
            SetTitle();
        }

        
        static public Tree<string> Read()
        {
            Source.IndexOf(titleTagOpen);
            return true;
        }

    }
}
