using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Fighters
{
    public static class FighterFactory
    {
        private static int lastInteger = 0;

        public static Fighter EnsureArcher(int? id = null) {
            var ret = new Fighter(id ?? lastInteger, FighterType.Archer);
            lastInteger++;
            return ret;
        }

        public static Fighter EnsureSwordsman(int? id = null)
        {
            var ret = new Fighter(id ?? lastInteger, FighterType.Swordsman);
            lastInteger++;
            return ret;
        }

        public static Fighter EnsureHorseman(int? id = null)
        {
            var ret = new Fighter(id ?? lastInteger, FighterType.Horseman);
            lastInteger++;
            return ret;
        }

        public static Fighter EnsureRandom() {

            var roll = AttackRoller.GetInstance().RandomRollOf3();

            switch (roll)
            {
                case 1:
                    return EnsureHorseman();
                case 2:
                    return EnsureArcher();
                default:
                    return EnsureSwordsman();
            }

        }
    }
}
