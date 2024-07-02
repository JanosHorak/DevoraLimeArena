using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLimeArena.Services.ServiceImplementations
{
    public class BarracksService : IBarracksService
    {
        private readonly Random random = new Random();
        private readonly List<FighterModel> _fighters = new List<FighterModel>();

        public void InitBarracks(List<FighterModel> fighters)
        { 
            this._fighters.Clear();
            this._fighters.AddRange(fighters);
        }

        public FighterModel GetFighterFromBarrack()
        {
            var index = random.Next(_fighters.Count);
            var ret = this._fighters[index];
            this._fighters.RemoveAt(index);
            return ret;
        }

        public void AddFighterToBarrack(FighterModel fighter) { 
            this._fighters.Add(fighter);
        }

        public void Rest() { 
          foreach(var fighter in this._fighters) { fighter.Rest(); }
        }

        public bool HasMoreThanOnePerson() {
            return this._fighters.Count > 1;
        }

        public List<FighterModel> CheckFighters()
        {
            return this._fighters;
        }
    }
}
