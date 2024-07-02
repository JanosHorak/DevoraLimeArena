using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{

    public class AttackRoller
    {
        private static AttackRoller instance;

        private Random random;

        private AttackRoller()
        {
            random = new Random();
        }

        public static AttackRoller GetInstance()
        {
            if (instance == null)
            {
                instance = new AttackRoller();
            }
            return instance;
        }

        public bool RandomRoll(int successChance)
        {
            int roll = random.Next(100);

            return roll < successChance;
        }

        public int RandomRollOf3()
        {
            int roll = random.Next(1, 4); 
            return roll;
        }
    }
}
