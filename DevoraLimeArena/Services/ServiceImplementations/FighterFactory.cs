using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevoraLimeArena.Services.ServiceImplementations
{
    public class FighterFactory : IFighterFactory
    {
        private int lastInteger = 0;
        private IRandomRoller randomRoller;

        public FighterFactory(IRandomRoller randomRoller)
        {
            this.randomRoller = randomRoller;
        }

        public FighterModel EnsureArcher(int? id = null)
        {
            var ret = new FighterModel
            {
                Id = id ?? lastInteger,
                type = FighterType.Archer,
                InitialHP = 100,
                HP = 100
            };
            lastInteger++;
            return ret;
        }

        public FighterModel EnsureSwordsman(int? id = null)
        {
            var ret = new FighterModel
            {
                Id = id ?? lastInteger,
                type = FighterType.Swordsman,
                InitialHP = 120,
                HP =120
            };
            lastInteger++;
            return ret;
        }

        public FighterModel EnsureHorseman(int? id = null)
        {
            var ret = new FighterModel
            {
                Id = id ?? lastInteger,
                type = FighterType.Horseman,
                InitialHP = 150,
                HP = 150
            };
            lastInteger++;
            return ret;
        }

        public FighterModel EnsureRandom()
        {

            var roll = this.randomRoller.RandomClass();

            switch (roll)
            {
                case FighterType.Horseman:
                    return EnsureHorseman();
                case FighterType.Archer:
                    return EnsureArcher();
                case FighterType.Swordsman:
                    return EnsureSwordsman();
                default: throw new Exception("INVALID CLASS");
            }

        }
    }
}
