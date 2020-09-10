using System;
using System.Linq;
using System.IO;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] playerStats = GenerateStats();

            DisplayStats(playerStats[0], playerStats[1], playerStats[2]);
        }

        public static void DisplayStats(int heart, int mind, int body)
        {
            Console.WriteLine($"Heart: {heart}");
            Console.WriteLine($"Mind: {mind}");
            Console.WriteLine($"Body: {body}");
        }

        public static int[] GenerateStats()
        {
            int[] playerStats = new int[3];
            Random rnd = new Random();

            while (playerStats[0] + playerStats[1] + playerStats[2] != 5)
            {
                for (int i = 0; i < playerStats.Length; i++)
                {
                    playerStats[i] = rnd.Next(1, 3);
                }
            }

            return playerStats;
        }

    }
}

