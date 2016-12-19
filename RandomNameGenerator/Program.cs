using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.WindowWidth, 40);

            Console.WriteLine("Names:\n");

            List<string> prefixes = new List<string>();
            List<string> suffixes = new List<string>();

            StreamReader prefixFile = new StreamReader("prefixes.txt");
            StreamReader suffixFile = new StreamReader("suffixes.txt");
            string line;

            while ((line = prefixFile.ReadLine()) != null)
            {
                prefixes.Add(line);
            }

            prefixFile.Close();

            while ((line = suffixFile.ReadLine()) != null)
            {
                suffixes.Add(line);
            }

            suffixFile.Close();

            do
            {
                Random r = new Random();

                for (int i = 0; i < 20; i++)
                {
                    int prefix = r.Next(prefixes.Count);
                    int suffix = r.Next(suffixes.Count);
                    string name = prefixes.ElementAt(prefix) + suffixes.ElementAt(suffix);
                    Console.WriteLine(name);
                }

                Console.WriteLine("\nPress Enter for more names, any other key to exit...\n");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}
