using System;
namespace TextAdventure
{
    public class Actions 
    {
        public Actions()
        {
        }

        private string combatOptions = "Enter: 1 = Fight / 2 = Bargain: ";
        private string puzzleOptions = "Enter: 1 = Solve / 2 = Brute: ";
        private string challengeOptions = "Enter: 1 = Survive / 2 = Craft: ";

        private void Combat()
        {
            Console.Write(combatOptions);
        }
        private void Puzzle()
        {
            Console.Write(puzzleOptions);
        }
        private void Challenge()
        {
            Console.Write(challengeOptions);
        }


        public int PlayerInput()
        {
            int input = 0;
            
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Try again");
            }
            return input;
        }


        public void PlayerActions(string eventDetails)
        {
            switch (eventDetails)
            { 
                case "Combat1":
                    Combat();
                    break;
                case "Combat2":
                    Combat();
                    break;
                case "Combat3":
                    Combat();
                    break;
                case "Puzzle1":
                    Puzzle();
                    break;
                case "Puzzle2":
                    Puzzle();
                    break;
                case "Puzzle3":
                    Puzzle();
                    break;
                case "Challenge1":
                    Challenge();
                    break;
                case "Challenge2":
                    Challenge();
                    break;
                case "Challenge3":
                    Challenge();
                    break;
                default:
                     break;

            }

        }


    }
}
