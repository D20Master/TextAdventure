﻿using System;
using System.Linq;
using System.IO;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] playerStats = GenerateStats();
            DisplayStats(playerStats[0], playerStats[1], playerStats[2], playerStats[3]);

        }

        public static void DisplayStats(int level, int heart, int mind, int body)
        {
            Console.WriteLine($"Player Lvl: {level}");
            Console.WriteLine($"Heart: {heart}");
            Console.WriteLine($"Mind: {mind}");
            Console.WriteLine($"Body: {body}");
        }

        public static int[] GenerateStats()
        {
            int[] playerStats = new int[4];
            playerStats[0] = 1;

            while (playerStats[1] + playerStats[2] + playerStats[3] != 5)
            {
                for (int i = 1; i < playerStats.Length; i++)
                {
                    playerStats[i] = GenerateRandomInt(1, 3);
                }
            }

            return playerStats;
        }

        public static int GenerateRandomInt(int lowerBound, int upperBound)
        {
            Random rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }

        public static string GenerateEvent()
        {
            int rnd = GenerateRandomInt(1, 100);

            if (rnd <= 30)
            {
                return "Combat";
            }
            else if (rnd <=50)
            {
                return "Investigation";
            }
            else if (rnd<=70)
            {
                return "Challenge";
            }
            else if (rnd<=85)
            {
                return "Treasure";
            }
            else
            {
                return "Rest";
            }

        }

    }
}

