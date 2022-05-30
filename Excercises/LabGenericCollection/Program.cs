using System;
using System.Collections.Generic;

namespace LabGenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<char> letters = new List<char> { 'a', 'b', 'x', 'd'};

            letters.Add('e');

            Console.Write("Letters: ");
            foreach(char x in letters)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();

            if(letters.Contains('m'))
            {
                Console.WriteLine("M is part of the list");
            }
            else
            {
                Console.WriteLine("M is not part of the list");
            }

            letters.RemoveAt(2);

            Console.WriteLine("Element on index 2:" + letters[2]);

            letters.Insert(2, 'c');


            Console.WriteLine("Letters: " + String.Join(',', letters));

        }
    }
}
