using System;
using System.IO;
using System.Text;

namespace SiteMap
{
    class Constants
    {
        public static string documentHead { get; set; }

        public static string outlineHead1 { get; } = "<outline text=\"";
        public static string outlineHead2 { get; } = "\">";
        public static string outlineFooter { get; } = "<sx:sync version=\"1\"/>" + "</outline>";
        public static string documentFooter { get; } = Environment.NewLine + "</body>" + Environment.NewLine + "</opml>" + Environment.NewLine;

        public Constants(string main)
        {
            documentHead = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine +
                                     "<opml version=\"1.0\" xmlns:sx=\"http://www.microsoft.com/schemas/rss/sse\">" + Environment.NewLine +
                                     "<head>" + Environment.NewLine +
                                     "<title>" + main +"</title > " + Environment.NewLine +
                                     "<dateCreated>2018-01-05T07:13:25</dateCreated>" + Environment.NewLine +
                                     "<ownerName>Mindjet</ownerName>" + Environment.NewLine +
                                     "</head>" + Environment.NewLine +
                                     "<body>" + Environment.NewLine;
        }
    }
}