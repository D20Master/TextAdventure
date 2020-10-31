namespace TextAdventure
{
    public class FloorEvent
    {
        public FloorEvent()
        {

        }

        private string _eventType;
        private int _eventLvl;
        private string _eventDescription;
        private string _eventSuccess;
        private string _eventFail;
        private string _eventAlt;
        private string _eventOutcome;
        private bool _outcome;

        public string EventType { get { return _eventType; } }
        public int EventLvl { get { return _eventLvl; } }
        public string EventDescription { get { return _eventDescription; } }
        public string EventSucess { get { return _eventSuccess; } }
        public string EventFail { get { return _eventFail; } }
        public string EventAlt { get { return _eventAlt; } }
        public bool Outcome { get { return _outcome; } }

        Generator roll = new Generator();

        private void GenerateType()
        {
            int num = roll.RandomInt(1, 101);

            if (num <= 35)
            {
                _eventType = "Combat";
            }
            else if (num <= 55)
            {
                _eventType = "Puzzle";
            }
            else if (num <= 75)
            {
                _eventType = "Challenge";
            }
            else if (num <= 90)
            {
                _eventType = "Loot";
            }
            else
            {
                _eventType = "Rest";
            }
        }

        private void GenerateLevel()
        {
            _eventLvl = roll.RandomInt(1, 4);
        }

        private void GenerateEvent()
        {
            GenerateType();
            GenerateLevel();
            switch (_eventType + _eventLvl)
            {
                case "Combat1":
                    _eventDescription = "A slow flying bug flutters around your head trying to get through your armour.";
                    _eventSuccess = "You swat the fly and move on with you adventure.";
                    _eventFail = "You hear a buzzing sound in your ear and a sharp pain.";
                    _eventAlt = "The fly takes a tiny piece copper and lazly flys away.";
                    break;
                case "Combat2":
                    _eventDescription = "A bandit dashes out from a rocky outcropping sword in hand.";
                    _eventSuccess = "You parry the bandits blade and swiftly disbatch them.";
                    _eventFail = "You fumble for you sword as the bandit strikes you across the chest.";
                    _eventAlt = "Reaching in your pouch you pull out some of you treasure and toss it in another direction.\n" +
                        "The bandit is distracted long enough for you to get away.";
                    break;
                case "Combat3":
                    _eventDescription = "You enter a large cavern. A deep rumble shakes the ground around you.\n" +
                        "In the darkness a large yellow eye opens.";
                    _eventSuccess = "Looking around in panick you notice a pillar leaning slightly.\n" +
                        "You dash toward it striking it with you shoulder.\n" +
                        "The pillar creaks and falls onto the beast.";
                    _eventFail = "Before you can register what it is the monster strikes fligging you across the room.";
                    _eventAlt = "From your pouch you produce a large gem and plead with the beast.\n" +
                        "A claw emerges from the shadows and picks up the gem.\n" +
                        "You are allowed to continue on.";
                    break;
                case "Puzzle1":
                    _eventDescription = "A old wooden door with a rusty lock bars you path into the next room.";
                    _eventSuccess = "You pull out a pick from your pack swiftly dismantle the lock.";
                    _eventFail = "Your fingers slip while trying to pick the lock cutting you hand on the rusty edge.";
                    _eventAlt = "It's an old wooden door... you knock it down.";
                    break;
                case "Puzzle2":
                    _eventDescription = "Three doors stand in your path each appearing to be identical.";
                    _eventSuccess = "From under the left door you feel a feight breeze.\n" +
                        "You open the door an proceeed onwards.";
                    _eventFail = "You open the closest door. Walking through your notice there is no floor beneath your feet.";
                    _eventAlt = "No need for thinking you open the first door and a spear comes shooting out.\n" +
                        "However, you react quicly dodge it.";
                    break;
                case "Puzzle3":
                    _eventDescription = "As you enter the next room the door slams shut behind you and the room goes dark.\n" +
                        "A mirror lights up on the other side of the room.";
                    _eventSuccess = "Shifting your reflection you notice another door only in the reflection.\n" +
                        "You move to open the door from the mirror perspective. The door opens and continue onwards.";
                    _eventFail = "In frustration you shatter the mirror. Shards of glass cut you into you. ";
                    _eventAlt = "You smash into the wall until you make your own door.";
                    break;
                case "Challenge1":
                    _eventDescription = "Walking along a rift in the ground opens up before you.";
                    _eventSuccess = "You react quickly before the rift expands and jump across to the other side.";
                    _eventFail = "You stumble trying to jump across and fall into the rift.";
                    _eventAlt = "From your pouch you grab a grappling hook and throw it across to the other side.";
                    break;
                case "Challenge2":
                    _eventDescription = "From behind you comes a rumbling sound as you see a large boulder rolling your way.";
                    _eventSuccess = "You run as fast as your legs will carry you. Down the fall you see a split in the path.\n" +
                        "You go right just as the bolder rolls by on your left.";
                    _eventFail = "You are far to slow and the boulder overtakes and you are curshed.";
                    _eventAlt = "Grabbing random items from your pouch you create a chock and brace yourself.\n" +
                        "Miraculously the boulder is stopped.";
                    break;
                case "Challenge3":
                    _eventDescription = "With your next step you hear a click and a whoosh as arrows fly out of the wall.";
                    _eventSuccess = "Your deftly manuver through the hall dogding the arrows.";
                    _eventFail = "Try as you might you are bombarded by arrows.";
                    _eventAlt = "You take your shield and pouch in each arm and run, allowing the arrows to strike into them.";
                    break;
                case "Loot1":
                    _eventDescription = "You find a bag of discarded trinkets. \n" +
                        "You gain 1 Loot";
                    break;
                case "Loot2":
                    _eventDescription = "The body of a previous adventurer lies in you path. You decide to take their goods.\n" +
                        "Might help you survive longer then them.\n" +
                        "You gain 2 Loot";
                    break;
                case "Loot3":
                    _eventDescription = "Gleaming light can be seen down the hall. You walk into a room with piles of gold.\n" +
                        "You pocket a few handfuls.\n" +
                        "You gain 3 Loot";
                    break;
                case "Rest1":
                    _eventDescription = "You stumble upon a knook in the dungeon and settle down to rest.\n" +
                        "You can hear ominous footsteps in the distance. \n" +
                        "You gain 1 Heart";
                    break;
                case "Rest2":
                    _eventDescription = "You open the door into an empty room. You decide to bar the door and take a short rest.\n" +
                        "You gain 2 Heart";
                    break;
                case "Rest3":
                    _eventDescription = "You stumble upon a open cavern a glowing pool of water at its center.\n" +
                        "You take a sip and feel rejuvinated. \n" +
                        "You gain 3 Heart";
                    break;
                default:
                    _eventDescription = "ERROR";
                    break;


            }
        }

        private bool CombatOutcome(int body, int mind, int lvl, int playerInput)
        {
            int eventChance = roll.RandomInt(1, 100);
            int bonus = 0;

            if (playerInput == 2)
            {
                bonus = 10;
            }

            switch (_eventLvl)
            {
                case 1:
                    return _outcome = (eventChance <= 75 + body + mind - (lvl*2) + bonus);
                case 2:
                    return _outcome = (eventChance <= 50 + body + mind- (lvl*2) + bonus);
                case 3:
                    return _outcome = (eventChance <= 25 + body + mind - (lvl*2) + bonus);
                default:
                    return false;
            }
        }

        private bool PuzzleOutcome(int body, int mind, int lvl, int playerInput)
        {
            int eventChance = roll.RandomInt(1, 100);
            int bonus = 0;

            if (playerInput == 2)
            {
                bonus = body;

            }

            switch (_eventLvl)
            {
                case 1:
                    return _outcome = (eventChance <= 75 + mind- lvl + bonus);
                case 2:
                    return _outcome = (eventChance <= 50 + mind - lvl + bonus);
                case 3:
                    return _outcome = (eventChance <= 25 + mind - lvl + bonus);
                default:
                    return false;
            }
        }

        private bool ChallengeOutcome(int body, int lvl, int playerInput)
        {
            int eventChance = roll.RandomInt(1, 100);
            int bonus = 0;

            if (playerInput == 2)
            {
                bonus = 10;
            }

            switch (_eventLvl)
            {
                case 1:
                    return _outcome = (eventChance <= 75 + body - lvl + bonus);
                case 2:
                    return _outcome = (eventChance <= 50 + body - lvl + bonus);
                case 3:
                    return _outcome = (eventChance <= 25 + body - lvl + bonus);
                default:
                    return false;
            }
        }

        public string EventOutcome(int lvl, int heart, int mind, int body, int loot, int playerInput)
        {
            if (playerInput == 1)
            {
                if (_eventType == "Combat")
                {
                    _eventOutcome = CombatOutcome(body, mind, lvl, playerInput) ? _eventSuccess : _eventFail;
                }
                if (_eventType == "Puzzle")
                {
                    _eventOutcome = PuzzleOutcome(body, mind, lvl, playerInput) ? _eventSuccess : _eventFail;
                }
                if (_eventType == "Challenge")
                {
                    _eventOutcome = ChallengeOutcome(body, lvl, playerInput) ? _eventSuccess : _eventFail;
                }
            }
            else 
            {
                if (_eventType == "Combat")
                {
                    _eventOutcome = CombatOutcome(body, mind, lvl, playerInput) ? _eventAlt : _eventFail;
                }
                if (_eventType == "Puzzle")
                {
                    _eventOutcome = PuzzleOutcome(body, mind, lvl, playerInput) ? _eventAlt : _eventFail;
                }
                if (_eventType == "Challenge")
                {
                    _eventOutcome = ChallengeOutcome(body, lvl, playerInput) ? _eventAlt : _eventFail;
                }
            }

            return _eventOutcome;
        }

        

        public void DisplayEvents()
        {
            GenerateEvent();
            System.Console.WriteLine(_eventDescription);
        }
        
        }
    }

