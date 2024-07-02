using BackEnd.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class FightResult
    {

        public FightResult(int roundNr, Fighter attacker, Fighter defender)
        {
            this.RoundNr = roundNr;
            this.AttackerName = attacker.DisplayName;
            this.DefenderName = defender.DisplayName;
            this.StarterAttackerHP = attacker.HP;
            this.StarterDefenderHP = defender.HP;
        }

        public void AfterFight(Fighter attacker, Fighter defender)
        {
            this.AttackerIsDead = attacker.IsDead;
            this.DefenderIsDead = defender.IsDead;
            this.AttackerLifeRemaining = attacker.HP;
            this.DefenderLifeRemaining = defender.HP;
            if(!attacker.IsDead) {
            this.Survivors.Add(attacker);
            }
            if(!defender.IsDead)
            {
                this.Survivors.Add(defender);
            }
        }

        public readonly int RoundNr;
        private readonly int StarterAttackerHP;
        private readonly int StarterDefenderHP;

        public string AttackerName { get; set; }
        public string DefenderName { get; set; }

        public bool AttackerIsDead { get; set; }
        public bool DefenderIsDead { get; set; }

        public int AttackerLifeLost
        {
            get
            {
                if (AttackerIsDead) return StarterAttackerHP;
                return (StarterAttackerHP - AttackerLifeRemaining)*-1;
            }
        }
        public int DefenderLifeLost
        {
            get
            {
                if (AttackerIsDead) return StarterDefenderHP;
                return (StarterDefenderHP - DefenderLifeRemaining)*-1;
            }
        }

        public int AttackerLifeRemaining { get; set; }
    
        public int DefenderLifeRemaining { get; set; }

        public List<Fighter> Survivors { get; set; } = new List<Fighter>();
    }

}
