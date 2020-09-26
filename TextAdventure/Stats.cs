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

        public int Level { get { return _level; } }
        public int Heart { get { return _heart; } }
        public int Mind { get { return _mind; } }
        public int Body { get { return _body; } }
        public int Loot { get { return _loot; } }

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
            _heart = 10;
            _mind = roll.RandomInt(1, 4);
            _body = roll.RandomInt(1, 4);
            _loot = roll.RandomInt(1, 3);
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Floor Lvl: {_level}");
            Console.WriteLine($"Heart: {_heart}");
            Console.WriteLine($"Mind: {_mind}");
            Console.WriteLine($"Body: {_body}");
            Console.WriteLine($"Loot: {_loot}");
            Console.WriteLine();
        }

        public int LevelIncrement (int num)
        {
            return _level += num;
        }

        public int HeartIncrement(int num)
        {
            return _heart += num;
        }

        public int MindIncrement(int num)
        {
            return _mind += num;
        }

        public int BodyIncrement(int num)
        {
            return _body += num;
        }

        public int LootIncrement(int num)
        {
            return _loot += num;
        }


    }
}

