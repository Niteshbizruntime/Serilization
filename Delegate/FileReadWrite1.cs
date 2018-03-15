using System;
using System.IO;
using System.Text;

namespace NewProject
{
    class FileReadWrite1
    {
      
        static FileStream writer = File.Open("Chat.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        static int i = 0,j=0;
        public static void WriteFromObject()
        {
             Console.WriteLine("\nWrite in file(for Close write stop )");
             string s = Console.ReadLine();
             byte[] vs = Encoding.Default.GetBytes(s);
             writer.Write(vs, 0, vs.Length);
             j = i;
             i = i + s.Length;
             writer.Position =i;
             if (s.ToLower().Equals("stop"))
             return;
             ReadToObject();
        }

  
        public static void ReadToObject()
        {
            FileStream fs = File.Open("Chat.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fs);
            string s =(string) reader.ReadLine();
            Console.WriteLine("\nRead from file");
            string sss = s.Substring(j);
           Console.WriteLine(sss);
            WriteFromObject();
        }

        static void Main(string[] args)
        {
            
                WriteFromObject();
        }
    }
}
