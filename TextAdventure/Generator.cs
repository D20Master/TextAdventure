using System;
namespace TextAdventure
{
    public class Generator
    {
        public Generator()
        {
        }

        public int RandomInt(int lowerBound, int upperBound)
        {
            Random rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }
    }
}
