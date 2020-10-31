using System;
namespace TextAdventure
{
    public class Stats : Actions
    {
        protected int _level;
        protected int _heart;
        protected int _mind;
        protected int _body;
        protected int _loot;
        protected int[] _statArray = new int[5];

        public int Level { get { return _level; } set { _level = value; } }
        public int Heart { get { return _heart; } set { _heart = value; } }
        public int Mind { get { return _mind; } set { _mind = value; } }
        public int Body { get { return _body; } set { _body = value; } }
        public int Loot { get { return _loot; } set { _loot = value; } }

        public int[] StatArray
        {
            get
            {
                return _statArray;
            }
            set
            {
                _statArray[0] = _level;
                _statArray[1] = _heart;
                _statArray[2] = _mind;
                _statArray[3] = _body;
                _statArray[4] = _loot;

            }
        }

        Generator roll = new Generator();

        public Stats()
        {
            GenerateStats();
        }

        protected void GenerateStats()
        {
            _level = 1;
            _heart = 6;
            _mind = roll.RandomInt(1, 4);
            _body = roll.RandomInt(1, 4);
            _loot = roll.RandomInt(1, 3);
        }

        public void DisplayStats()
        {
            
            Console.WriteLine($"Floor Lvl: {_level}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Heart: {_heart}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Mind: {_mind}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Body: {_body}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Loot: {_loot}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public void PlayerStatIncrease(string eventType)
        {
            switch (eventType)
            {
                case "Combat":
                    Body++;
                    Mind++;
                    break;
                case "Puzzle":
                    Mind++;
                    break;
                case "Challenge":
                    Body++;
                    break;
                default:
                    break;
            }
        }


        public int PlayerInput(string eventType)
        {
            int input = 0;

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Enter a 1 or 2: ");
            }

            if (eventType == "Puzzle" && input == 2)
            {
                Mind--;
                Console.WriteLine();
                return input;
            }
            
            if (Loot == 0 && input == 2) // if 2 is enter and player has no loot
            {
                Console.WriteLine("You fumble through your pockets and empty pouch.\n" +
                    "Click Enter to Continue");
                Console.ReadLine();
                return 1;
            }

            if (input == 2)
            {
                Loot--;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Minus 1 to Loot");
                Console.ForegroundColor = ConsoleColor.White;
                return input;
            }
            else
            {
                Console.WriteLine();
                return input;
            }


            

            
        }

    }
}

