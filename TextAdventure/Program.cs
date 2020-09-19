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

            while (playerStats[0] <= 10 || playerStats[1] != 0)
            {

                //Display player stats and generates first event.
                DisplayStats(playerStats[0], playerStats[1], playerStats[2], playerStats[3]);
                eventDetails = GenerateEvent();
                Console.WriteLine(eventDetails[2]);

                //Display player choices and outcome
                PlayerActions(eventDetails);

                if (LevelUpEvent(eventDetails))
                {
                    string successEvent = eventDetails[3];
                    string failEvent = eventDetails[4];
                    string altEvent = eventDetails[5];

                    int playerInput = int.Parse(Console.ReadLine());

                    if (PlayerOutcome(playerStats, eventDetails, playerInput))
                    {
                        if (playerInput==1)
                        {
                            Console.WriteLine(successEvent);
                        }
                        else
                        {
                            Console.WriteLine(altEvent);
                        }
                    }
                    else
                    {
                        Console.WriteLine(failEvent);
                        playerStats[1]--;
                        Console.ReadLine();
                    }

                    playerStats[0]++;
                }
                else
                {
                    Console.ReadLine();
                }

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
            string[] eventDetails = new string[8];

            int rnd = GenerateRandomInt(1, 101);

            string eventType = null;
            string eventLvl = GenerateRandomInt(1, 4).ToString();
            string eventDescription = null;
            string eventSuccess = null;
            string eventFail = null;
            string eventAlt = null;



            if (rnd <= 30)
            {
                eventType = "Combat";
            }
            else if (rnd <= 50)
            {
                eventType = "Puzzle";
            }
            else if (rnd <= 70)
            {
                eventType = "Challenge";
            }
            else if (rnd <= 85)
            {
                eventType = "Treasure";
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
                    eventAlt = "Reaching in your puch you pull out some of you treasure and toss it in another direction. The bandit is distracted long enough for you to get awawy.";
                    break;
                case "Combat3":
                    eventDescription = "You enter a large cavern. A deep rumble shakes the ground around you. In the darkness a large yellow eye opens.";
                    eventSuccess = "Looking around in panick you notice a pillar leaning slightly. You dash toward it striking it with you shoulder. The pillar creaks and falls onto the beast.";
                    eventFail = "Before you can register what it is the monster strikes fligging you across the room.";
                    eventAlt = "From your pouch you produce a large gem and plead with the beast. A claw emerges from the shadows and picks up the gem. You are allowed to continue on.";
                    break;
                case "Puzzle1":
                    eventDescription = "A old wooden door with a rusty lock bars you path into the next room.";
                    eventSuccess = "You pull out a pick from your pack swiftly dismantle the lock.";
                    eventFail = "Your fingers slip while trying to pick the lock cutting you hand on the rusty edge.";
                    eventAlt = "It's an old wooden door... you knock it down.";
                    break;
                case "Puzzle2":
                    eventDescription = "Three doors stand in your path each appearing to be identical.";
                    eventSuccess = "From under the left door you feel a feight breeze. You open the door an proceeed onwards.";
                    eventFail = "You open the closet door and walk through and notice there is no floor beneath your feet.";
                    eventAlt = "No need for thinking you open the first door and a spear comes shooting out. However, you react quicly dodge it.";
                    break;
                case "Puzzle3":
                    eventDescription = "As you enter the next room the door slams shut behind you and the room goes dark. A mirror lights up on the other side of the room.";
                    eventSuccess = "Shifting your reflection you notice another door only in the reflection. You move to open the door from the mirror perspective. The door opens and continue onwards.";
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
                    eventSuccess = "You run as fast as your legs will carry you. Down the fall you see a split in the path. You go right just as the bolder rolls by on your left.";
                    eventFail = "You are far to slow and the bolder overtakes and you are curshed.";
                    eventAlt = "Grabing random items from your pouch you create a chock and brace yourself. Miraculously the boulder is stopped.";
                    break;
                case "Challenge3":
                    eventDescription = "With your next step you hear a click and a whoosh of air as arrows fly out of the wall.";
                    eventSuccess = "Your deftly manuver through the hall dogding the arrows.";
                    eventFail = "Try as you might you are bombarded by arrows.";
                    eventAlt = "You take your sheild and pouch holder one in each arm allowing the arrow to strike into them.";
                    break;
                case "Treasure1":
                    eventDescription = "You find a bag of discarded trinkets.";
                    break;
                case "Treasure2":
                    eventDescription = "The body of a previous adventurer lies in you path. You decide to take their goods. Might help you survive longer then them.";
                    break;
                case "Treasure3":
                    eventDescription = "Gleaming light can be seen down the hall. You walk into a room with piles of gold. You pocket a few handfuls.";
                    break;
                case "Rest1":
                    eventDescription = "You stumble upon a knook in the dungeon and settle down to rest. You can hear ominous footsteps in the distance.";
                    break;
                case "Rest2":
                    eventDescription = "You open the door into an empty room. You decide to bar the door and take a short rest.";
                    break;
                case "Rest3":
                    eventDescription = "You stumble upon a open cavern a glowing pool of water at its center. You take a sip and feel rejuvinated.";
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
                    Console.WriteLine("Fight = 1 / Bargain = 2");
                    break;
                case "Combat2":
                    Console.WriteLine("Fight = 1 / Bargain = 2");
                    break;
                case "Combat3":
                    Console.WriteLine("Fight = 1 / Bargain = 2");
                    break;
                case "Puzzle1":
                    Console.WriteLine("Solve = 1 / Brute = 2");
                    break;
                case "Puzzle2":
                    Console.WriteLine("Solve = 1 / Brute = 2");
                    break;
                case "Puzzle3":
                    Console.WriteLine("Solve = 1 / Brute = 2");
                    break;
                case "Challenge1":
                    Console.WriteLine("Survive = 1 / Craft = 2");
                    break;
                case "Challenge2":
                    Console.WriteLine("Survive = 1 / Craft = 2");
                    break;
                case "Challenge3":
                    Console.WriteLine("Survive = 1 / Craft = 2");
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
                                playerChance = 75 + (body + mind / 100);
                                break;
                            case 2:
                                playerChance = 75 + (body + mind / 100); // +treasure later ;
                                break;
                        }
                        break;
                    case 2:

                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 50 + (body + mind / 100);
                                break;
                            case 2:
                                playerChance = 50 + (body + mind / 100); // +treasure later ;
                                break;
                        }

                        break;
                    case 3:

                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 25 + (body + mind / 100);
                                break;
                            case 2:
                                playerChance = 25 + (body + mind / 100); // +treasure later ;
                                break;
                        }
                        break;

                    default:
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
                                playerChance = 75 + (mind / 100);
                                break;
                            case 2:
                                playerChance = 75 + (mind / 100); // +treasure later ;
                                break;
                        }
                        break;
                    case 2:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 50 + (mind / 100);
                                break;
                            case 2:
                                playerChance = 50 + (mind / 100); // +treasure later ;
                                break;
                        }
                        break;
                    case 3:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 25 + (mind / 100);
                                break;
                            case 2:
                                playerChance = 25 + (mind / 100); // +treasure later ;
                                break;
                        }
                        break;

                    default:
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
                                playerChance = 75 + (body / 100);
                                break;
                            case 2:
                                playerChance = 75 + (body / 100); // +treasure later ;
                                break;
                        }
                        break;
                    case 2:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 50 + (body / 100);
                                break;
                            case 2:
                                playerChance = 50 + (body / 100); // +treasure later ;
                                break;
                        }
                        break;
                    case 3:
                        switch (playerInput)
                        {
                            case 1:
                                playerChance = 25 + (body / 100);
                                break;
                            case 2:
                                playerChance = 25 + (body / 100); // +treasure later ;
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }

            return playerChance > eventChance;

        }

    }
}       


