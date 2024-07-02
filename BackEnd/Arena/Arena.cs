using BackEnd.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Arena
    {
        private Barracks barracks;

        public Arena(List<Fighter> fighters) { 
            this.barracks = new Barracks(fighters);
        }


        public List<FightResult> DoTheTournament() { 
            var ret = new List<FightResult>();

            var fightRound = new FightRound();

            int roundnr = 1;

            while(this.barracks.HasMoreThanOnePerson())
            {
                var attacker = this.barracks.GetFighterFromBarrack();
                var defender = this.barracks.GetFighterFromBarrack();

                var result = fightRound.Fight(roundnr,attacker, defender);
                ret.Add(result);

                this.barracks.Rest();
                foreach(var survivor in result.Survivors)
                {
                    this.barracks.AddFighterToBarrack(survivor);
                }
                roundnr++;
            }

            return ret;
            
     
        }


    }
}
