using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLimeArena.Services.ServiceImplementations
{

    public class RandomRoller : IRandomRoller
    {

        private Random random;

        public RandomRoller()
        {
            random = new Random();
        }


        public bool RandomRoll(int successChance)
        {
            int roll = random.Next(100);

            return roll < successChance;
        }

        public FighterType RandomClass()
        {
            int roll = random.Next(1, 4);

            switch (roll)
            {
                case 1: return FighterType.Archer;
                case 2: return FighterType.Swordsman;
                case 3: return FighterType.Horseman;
                default: throw new Exception("roll failed");
            }
        }
    }
}
