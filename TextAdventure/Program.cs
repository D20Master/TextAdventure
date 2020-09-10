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
            string[] eventDetails = null;

            while (playerStats[0] <= 10)
            {

                DisplayStats(playerStats[0], playerStats[1], playerStats[2], playerStats[3]);
                eventDetails = GenerateEvent();
                Console.WriteLine(eventDetails[0] + " " + eventDetails[1]);
                playerStats[0]++;
                Console.WriteLine();

            }

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
                    playerStats[i] = GenerateRandomInt(1, 4);
                }
            }

            return playerStats;
        }

        public static int GenerateRandomInt(int lowerBound, int upperBound)
        {
            Random rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }

        public static string[] GenerateEvent()
        {
            string[] eventDetails = new string[2];
            int eventType = GenerateRandomInt(1, 101);
            string eventLvl= GenerateRandomInt(1, 4).ToString();

            if (eventType <= 30)
            {
                eventDetails[0] = "Combat";
                eventDetails[1] = eventLvl;
            }
            else if (eventType <= 50)
            {
                eventDetails[0] = "Investigation";
                eventDetails[1] = eventLvl;
            }
            else if (eventType <= 70)
            {
                eventDetails[0] = "Challenge";
                eventDetails[1] = eventLvl;
            }
            else if (eventType <= 85)
            {
                eventDetails[0] = "Treasure";
                eventDetails[1] = eventLvl;
            }
            else
            {
                eventDetails[0] = "Rest";
                eventDetails[1] = eventLvl;
            }

            return eventDetails;
        }


    }
}       


