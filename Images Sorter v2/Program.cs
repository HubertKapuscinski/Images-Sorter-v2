using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Images_Sorter_v2
{
    class Program
    {
        static void Sorting(string source)
        {
            
        }
        static void Main(string[] args)
        {
            //Variables
            string username, CFG_Dir, photoDIR;
            username = Environment.UserName;
            CFG_Dir = @"C:\Users\" + username + @"\Documents\ImagesSorter.cfg";

            if (Directory.Exists(CFG_Dir))
            {
                File.ReadAllBytes(CFG_Dir);
            }
            else
            {
                Console.WriteLine("No .cfg file was found. Creating one.\n   Write your source directory for photos:\n");
                photoDIR = Console.ReadLine();
                File.WriteAllText(CFG_Dir, photoDIR + "\n");
                Sorting(photoDIR);
            }
        }
    }
}