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

            int[] playerStats = GenerateStats();
            string[] eventDetails = null;

            while (playerStats[1] != 0)
            {

                //Display player stats and generates first event.
                DisplayStats(playerStats[0], playerStats[1], playerStats[2], playerStats[3], playerStats[4]);
                eventDetails = GenerateEvent(playerStats);

                Console.WriteLine(eventDetails[2]); //event description

                PlayerActions(eventDetails); //Display player choices and outcome

                if (LevelUpEvent(eventDetails))
                {
                    string successEvent = eventDetails[3];
                    string failEvent = eventDetails[4];
                    string altEvent = eventDetails[5];

                    int playerInput = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (PlayerOutcome(playerStats, eventDetails, playerInput))
                    {

                        if (playerInput == 1)  //sucessful event
                        {
                            Console.WriteLine(successEvent);
                            Console.WriteLine("Click Enter to continue.");
                        }
                        else if (LootCheck(playerStats)) //succeful event alt
                        { 
                            Console.WriteLine(altEvent);
                            Console.WriteLine("You used up 1 loot.");
                            Console.WriteLine("Click Enter to continue.");
                            playerStats[4]--;
                        }
                        else
                        {
                            Console.WriteLine("You fumbled through your empty pockets");
                            Console.WriteLine(successEvent); // if no loot revert to other
                        }

                    }
                    else
                    {
                        Console.WriteLine(failEvent);
                        Console.WriteLine("You lost 1 heart.");
                        Console.WriteLine("Click Enter to continue."); 
                        playerStats[1]--;
                    }

                    playerStats[0]++;
                }

                Console.ReadLine();
                Console.Clear();

            }

            Console.WriteLine($"Game Over you made it to the {playerStats[0]} floor of the dugeon.");
        }

        public static void DisplayStats(int level, int heart, int mind, int body, int loot)
        {
            Console.WriteLine($"Floor Lvl: {level}");
            Console.WriteLine($"Heart: {heart}");
            Console.WriteLine($"Mind: {mind}");
            Console.WriteLine($"Body: {body}");
            Console.WriteLine($"Loot: {loot}");
            Console.WriteLine();
            
        }

        public static bool LootCheck(int[] playerStats)
        {
            return playerStats[4] > 0;
        }

        public static int[] GenerateStats()
        {
            int[] playerStats = new int[5];

            while (playerStats[2] + playerStats[3] + playerStats[4] != 5)
            {
                for (int i = 2; i < playerStats.Length; i++)
                {
                    playerStats[i] = GenerateRandomInt(1, 4);
                }
            }

            playerStats[0] = 1;
            playerStats[1] = 3;

            return playerStats;
        }

        public static int GenerateRandomInt(int lowerBound, int upperBound)
        {
            Random rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }

        public static string[] GenerateEvent(int[] playerStats)
        {
            string[] eventDetails = new string[8];

            int rnd = GenerateRandomInt(1, 101);

            string eventType = null;
            string eventLvl = GenerateRandomInt(1, 4).ToString();
            string eventDescription = null;
            string eventSuccess = null;
            string eventFail = null;
            string eventAlt = null;



            if (rnd <= 40)
            {
                eventType = "Combat";
            }
            else if (rnd <= 60)
            {
                eventType = "Puzzle";
            }
            else if (rnd <= 80)
            {
                eventType = "Challenge";
            }
            else if (rnd <= 90)
            {
                eventType = "Loot";
            }
            else
            {
                eventType = "Rest";
            }

            switch (eventType + eventLvl)
            {
                case "Combat1":
                    eventDescription = "A slow flying bug flutters around your head trying to get through your armour.";
                    eventSuccess = "You swat the fly and move on with you adventure.";
                    eventFail = "You hear a buzzing sound in your ear and a sharp pain.";
                    eventAlt = "The fly takes a tiny piece copper and lazly flys away.";
                    break;
                case "Combat2":
                    eventDescription = "A bandit dashes out from a rocky outcropping sword in hand.";
                    eventSuccess = "You parry the bandits blade and swiftly disbatch them.";
                    eventFail = "You fumble for you sword as the bandit strikes you across the chest.";
                    eventAlt = "Reaching in your pouch you pull out some of you treasure and toss it in another direction.\n" +
                        "The bandit is distracted long enough for you to get awawy.";
                    break;
                case "Combat3":
                    eventDescription = "You enter a large cavern. A deep rumble shakes the ground around you.\n" +
                        "In the darkness a large yellow eye opens.";
                    eventSuccess = "Looking around in panick you notice a pillar leaning slightly.\n" +
                        "You dash toward it striking it with you shoulder.\n" +
                        "The pillar creaks and falls onto the beast.";
                    eventFail = "Before you can register what it is the monster strikes fligging you across the room.";
                    eventAlt = "From your pouch you produce a large gem and plead with the beast.\n" +
                        "A claw emerges from the shadows and picks up the gem.\n" +
                        "You are allowed to continue on.";
                    break;
                case "Puzzle1":
                    eventDescription = "A old wooden door with a rusty lock bars you path into the next room.";
                    eventSuccess = "You pull out a pick from your pack swiftly dismantle the lock.";
                    eventFail = "Your fingers slip while trying to pick the lock cutting you hand on the rusty edge.";
                    eventAlt = "It's an old wooden door... you knock it down.";
                    break;
                case "Puzzle2":
                    eventDescription = "Three doors stand in your path each appearing to be identical.";
                    eventSuccess = "From under the left door you feel a feight breeze.\n" +
                        "You open the door an proceeed onwards.";
                    eventFail = "You open the closest door. Walking through your notice there is no floor beneath your feet.";
                    eventAlt = "No need for thinking you open the first door and a spear comes shooting out.\n" +
                        "However, you react quicly dodge it.";
                    break;
                case "Puzzle3":
                    eventDescription = "As you enter the next room the door slams shut behind you and the room goes dark.\n" +
                        "A mirror lights up on the other side of the room.";
                    eventSuccess = "Shifting your reflection you notice another door only in the reflection.\n" +
                        "You move to open the door from the mirror perspective. The door opens and continue onwards.";
                    eventFail = "In frustration you shatter the mirror. Shards of glass cut you into you. ";
                    eventAlt = "You smash into the wall until you make your own door.";
                    break;
                case "Challenge1":
                    eventDescription = "Walking along a rift in the ground opens up before you.";
                    eventSuccess = "You react quickly before the rift expands and jump across to the other side.";
                    eventFail = "You stumble trying to jump across and fall into the rift.";
                    eventAlt = "From your pouch you grab a grappling hook and throw it across to the other side.";
                    break;
                case "Challenge2":
                    eventDescription = "From behind you comes a rumbling sound as you see a large bolder rolling your way.";
                    eventSuccess = "You run as fast as your legs will carry you. Down the fall you see a split in the path.\n" +
                        "You go right just as the bolder rolls by on your left.";
                    eventFail = "You are far to slow and the bolder overtakes and you are curshed.";
                    eventAlt = "Grabing random items from your pouch you create a chock and brace yourself.\n" +
                        "Miraculously the boulder is stopped.";
                    break;
                case "Challenge3":
                    eventDescription = "With your next step you hear a click and a whoosh as arrows fly out of the wall.";
                    eventSuccess = "Your deftly manuver through the hall dogding the arrows.";
                    eventFail = "Try as you might you are bombarded by arrows.";
                    eventAlt = "You take your sheild and pouch holder one in each arm allowing the arrow to strike into them.";
                    break;
                case "Loot1":
                    eventDescription = "You find a bag of discarded trinkets. \n" +
                        "You gain 1 Loot";
                    playerStats[4] += 1;
                    break;
                case "Loot2":
                    eventDescription = "The body of a previous adventurer lies in you path. You decide to take their goods.\n" +
                        "Might help you survive longer then them.\n" +
                        "You gain 2 Loot";
                    playerStats[4] += 2;
                    break;
                case "Loot3":
                    eventDescription = "Gleaming light can be seen down the hall. You walk into a room with piles of gold.\n" +
                        "You pocket a few handfuls.\n" +
                        "You gain 3 Loot";
                    playerStats[4] += 3;
                    break;
                case "Rest1":
                    eventDescription = "You stumble upon a knook in the dungeon and settle down to rest.\n" +
                        "You can hear ominous footsteps in the distance. \n" +
                        "You gain 1 Heart";
                    playerStats[1] += 1;
                    break;
                case "Rest2":
                    eventDescription = "You open the door into an empty room. You decide to bar the door and take a short rest.\n" +
                        "You gain 2 Heart";
                    playerStats[1] += 2;
                    break;
                case "Rest3":
                    eventDescription = "You stumble upon a open cavern a glowing pool of water at its center.\n" +
                        "You take a sip and feel rejuvinated. \n" +
                        "You gain 3 Heart";
                    playerStats[1] += 3;
                    break;
                default:
                    eventDescription = "ERROR";
                    break;

            }

            eventDetails[0] = eventType;
            eventDetails[1] = eventLvl;
            eventDetails[2] = eventDescription;
            eventDetails[3] = eventSuccess;
            eventDetails[4] = eventFail;
            eventDetails[5] = eventAlt; 

            return eventDetails;


        }

        public static void PlayerActions(string[] eventDetails)
        {

            string eventType = eventDetails[0];
            string eventLvl = eventDetails[1];

            switch (eventType + eventLvl)
            {
                case "Combat1":
                    Console.WriteLine("Enter: 1 = Fight / 2 = Bargain");
                    break;
                case "Combat2":
                    Console.WriteLine("Enter: 1 = Fight / 2 = Bargain");
                    break;
                case "Combat3":
                    Console.WriteLine("Enter: 1 = Fight / 2 = Bargain");
                    break;
                case "Puzzle1":
                    Console.WriteLine("Enter: 1 = Solve / 2 = Brute");
                    break;
                case "Puzzle2":
                    Console.WriteLine("Enter: 1 = Solve / 2 = Brute");
                    break;
                case "Puzzle3":
                    Console.WriteLine("Enter: 1 = Solve / 2 = Brute");
                    break;
                case "Challenge1":
                    Console.WriteLine("Enter: 1 = Survive / 2 = Craft");
                    break;
                case "Challenge2":
                    Console.WriteLine("Enter: 1 = Survive / 2 = Craft");
                    break;
                case "Challenge3":
                    Console.WriteLine("Enter: 1 = Survive / 2 = Craft");
                    break;
                default:
                    break;

            }

        }

        public static bool LevelUpEvent(string[] eventDetails)
        {
            string eventType = eventDetails[0];
            switch (eventType)
            {
                case "Combat":
                    return true;

                case "Puzzle":
                    return true;

                case "Challenge":
                    return true;

                default:
                    return false;
            }
        }

        public static bool PlayerOutcome(int[] playerStats, string[] eventDetails, int playerInput)
        {
            int lvl = playerStats[0];
            int heart = playerStats[1];
            int mind = playerStats[2];
            int body = playerStats[3];
            int loot = playerStats[4];
            int playerChance = 0;

            int eventChance = GenerateRandomInt(1, 100);

            string eventType = eventDetails[0];
            int eventLvl = int.Parse(eventDetails[1]);

            if (eventType =="Combat")
            {
                switch (eventLvl)
                {

                    case 1:

                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 75 + (body + mind / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 75 + (body + mind / 100) + 10 - lvl;
                                    ;
                                break;
                        }
                        break;
                    case 2:

                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 50 + (body + mind / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 50 + (body + mind / 100) + 10 - lvl;
                                break;
                        }

                        break;
                    case 3:

                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 25 + (body + mind / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 25 + (body + mind / 100) +10 - lvl;
                                break;
                        }
                        break;
                }


            }

            if (eventType == "Puzzle")
            {
                switch (eventLvl)
                {

                    case 1:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 75 + (mind / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 75 + ((body - mind) / 100) - lvl; 
                                break;
                        }
                        break;
                    case 2:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 50 + (mind / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 50 + ((body - mind) / 100) - lvl;
                                break;
                        }
                        break;
                    case 3:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 25 + (mind / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 25 + ((body - mind) / 100) - lvl;
                                break;
                        }
                        break;
                }
            }

            if (eventType == "Challenge")
            {
                switch (eventLvl)
                {

                    case 1:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 75 + (body / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 75 + (body / 100) + 10 - lvl;
                                break;
                        }
                        break;
                    case 2:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 50 + (body / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 50 + (body / 100) + 10 - lvl;
                                break;
                        }
                        break;
                    case 3:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 25 + (body / 100) - lvl;
                                break;
                            case 2:
                                playerChance = 25 + (body / 100) + 10 - lvl;
                                break;
                        }
                        break;
                }
            }

            return playerChance > eventChance;

        }

        public static void Instructions()
        {
            Console.WriteLine("You are about to embark on a quest to reach the lowest floor of the dungeon\n" +
                "and find the riches it holds. Your player is given 4 stats that determine your chances of\n" +
                "survival. For each failed attempt during your quest you will lose 1 HEART. Don't worry if\n" +
                "fortune favors you then you will find places to recover along the way. Speaking of fortune\n" +
                "LOOT can also be gained along the way giving you a bonus to your chances of survival.\n" +
                "BODY and MIND each give a bonus to your chance of success depending on the situation. Not\n" +
                "all situations have the same level of success so use you loot sparingly. The rest you\n" +
                "will have to figure out as you go. GOOD LUCK!" );
            Console.ReadLine();
            Console.Clear();
        }

    }
}       


