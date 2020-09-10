using System;
using System.Linq;
using System.IO;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayStats(3, 2, 1);
        }

        public static void DisplayStats(int heart, int mind, int body)
        {
            Console.WriteLine($"Heart: {heart}");
            Console.WriteLine($"Mind: {mind}");
            Console.WriteLine($"Body: {body}");
        }

    }
}

