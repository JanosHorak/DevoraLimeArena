using BackEnd.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    internal class Barracks
    {
        private readonly Random random = new Random();
        private readonly List<Fighter> _fighters = new List<Fighter>();

        public Barracks(List<Fighter> fighters)
        {

            this._fighters = fighters;
        }

        public Fighter GetFighterFromBarrack()
        {
            var index = random.Next(_fighters.Count);
            var ret = this._fighters[index];
            this._fighters.RemoveAt(index);
            return ret;
        }

        public void AddFighterToBarrack(Fighter fighter) { 
            this._fighters.Add(fighter);
        }

        public void Rest() { 
          foreach(var fighter in this._fighters) { fighter.Rest(); }
        }

        public bool HasMoreThanOnePerson() {
            return this._fighters.Count > 1;
        }
    }
}
