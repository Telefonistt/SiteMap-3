
using System;
using System.IO;

namespace SiteMap
{
    class FileWork
    {
        public static string[] ReadFromFile(string path)
        {
            //// This text is added only once to the file.
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    string[] createText = { "Hello", "And", "Welcome" };
            //    File.WriteAllLines(path, createText);
            //}

            //// This text is always added, making the file longer over time
            //// if it is not deleted.
            //string appendText = "This is extra text" + Environment.NewLine;
            //File.AppendAllText(path, appendText);

            // Open the file to read from.
            try
            {
                string[] readText = File.ReadAllLines(path);
                return (readText);
            }
            catch
            {
                Console.WriteLine("File " + path + " not found!");
                Console.ReadKey();
                Environment.Exit(0);
                return  new string[]{ ""};
                
            }
            

           
            // using (FileStream fs = File.Create(path))
            //{
            //    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
            //    // Add some information to the file.
            //    fs.Write(info, 0, info.Length);

            //}

            
            //foreach (string s in readText)
            //{
            //    Console.WriteLine(s);
            //}


            //Console.ReadKey();

            
        }
        public static void WriteToFile(string path, string content)
        {
                FileStream fs= File.Create(path);
                fs.Close();
                //FileStream fs= File.Create(path);
                // fs.Close();
                // string appendText="";//= "This is extra text" + Environment.NewLine;
                // foreach (string line in readText)
                // {
                //     appendText += line + Environment.NewLine;
                // }
                 File.AppendAllText(path, content);
        }

    }
}

