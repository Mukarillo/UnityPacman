using System;
using System.Collections.Generic;

namespace PacEngine.utils
{
    public class RandomGenerator
    {
        private static RandomGenerator instance;
        public static RandomGenerator Instance => instance ?? (instance = new RandomGenerator());

        private Random random = new Random();


        public int GetRandom()
        {
            return random.Next();
        }

        public int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }

        public T GetRandom<T>(IList<T> list)
        {
            return list[GetRandom(0, list.Count)];
        }
    }
}
