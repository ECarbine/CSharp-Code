using System;
using System.IO;

namespace LabFile
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPoem("Poem.txt");
        }


        public static void PrintPoem(String fileName)
        {
            try
            {
                var sr = new StreamReader("Poem.txt");
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (IOException)
            {
                Console.WriteLine("The file could not be read");
            }
        }
    }
}
