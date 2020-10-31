using System;
using System.Linq;
using System.IO;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Instructions();
            Stats dungeoner = new Stats();
            FloorEvent room = new FloorEvent();

            while (dungeoner.Heart > 0)
            {
                var x = dungeoner.Heart;
                var y = dungeoner.Level;
                Console.Clear(); //start fresh
                dungeoner.DisplayStats(); //display stats
                room.DisplayEvents(); // events of room

                if (room.EventType == "Loot")
                {
                    dungeoner.Loot += room.EventLvl;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Click Enter To Continue");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (room.EventType == "Rest")
                {
                    dungeoner.Heart += room.EventLvl;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Click Enter To Continue");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    dungeoner.PlayerActions(room.EventType + room.EventLvl); // player chooses actions

                    Console.WriteLine(room.EventOutcome(dungeoner.Level,dungeoner.Heart,dungeoner.Mind,dungeoner.Body,dungeoner.Loot, dungeoner.PlayerInput(room.EventType)));

                    if (room.Outcome)
                    {
                        dungeoner.PlayerStatIncrease(room.EventType);
                    }
                    else
                    {
                        dungeoner.Heart--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You lose 1 Heart");
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Click Enter To Continue");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                dungeoner.Level++;
                Console.ReadLine();

                if (dungeoner.Level > 50)
                {
                    GameOver(dungeoner.Level);
                }
            }

            GameOver(dungeoner.Level);
        }


        public static void Instructions()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" You are about to embark on a quest to reach the lowest floor of the dungeon" +
                " and find the riches it holds. Your player is given 4 stats that determine your chances of" +
                " survival. For each failed attempt during your quest you will lose 1 HEART. Don't worry if" +
                " fortune favors you then you will find places to recover along the way. Speaking of fortune" +
                " LOOT can also be gained along the way giving you a bonus to your chances of survival." +
                " BODY and MIND each give a bonus to your chance of success depending on the situation. Not" +
                " all situations have the same level of success so use you LOOT sparingly. The rest you" +
                " will have to figure out as you go. GOOD LUCK!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void GameOver(int lvl)
        {
            if (lvl < 50)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                Console.WriteLine($"You have fought long and hard but only made it to floor level {lvl}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have reach the lowest floor of the dungeon I currently have programmed."+
                    "I honesly thought it'd be near impossible to make it this far, but you did it. All that is left" +
                    "to do is make this game harder. Oh... almost forgot... the riches... ummmmmm... yea.... you learned" +
                    "the valuable lesson of hardwork!");
                Environment.Exit(0);

            }

        }

    }
}       


