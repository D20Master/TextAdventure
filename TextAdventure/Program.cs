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
            while (dungeoner.Heart != 0)
            {
                Console.Clear(); //start fresh

                dungeoner.DisplayStats(); //display stats



                room.DisplayEvents(); // events of room


                dungeoner.PlayerActions(room.EventType + room.EventLvl); // player chooses actions

                if (room.EventType == "Loot" || room.EventType == "Rest")
                {
                    Console.WriteLine("Click Enter To Continue");
                }
                else
                {
                    Console.WriteLine(room.EventOutcome(dungeoner.StatArray, dungeoner.PlayerInput()));
                    Console.WriteLine("Click Enter To Continue");
                }

                dungeoner.HeartIncrement(-1);

                Console.ReadLine();

            }

        }


        public static void Instructions()
        {
            Console.WriteLine(" You are about to embark on a quest to reach the lowest floor of the dungeon\n" +
                "and find the riches it holds. Your player is given 4 stats that determine your chances of\n" +
                "survival. For each failed attempt during your quest you will lose 1 HEART. Don't worry if\n" +
                "fortune favors you then you will find places to recover along the way. Speaking of fortune\n" +
                "LOOT can also be gained along the way giving you a bonus to your chances of survival.\n" +
                "BODY and MIND each give a bonus to your chance of success depending on the situation. Not\n" +
                "all situations have the same level of success so use you loot sparingly. The rest you\n" +
                "will have to figure out as you go. GOOD LUCK!");
            Console.ReadLine();
            Console.Clear();
        }

    }
}       


