using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLimeArena.Models
{
    public class FightResult
    {

        public FightResult(int roundNr, FighterModel attacker, FighterModel defender)
        {
            RoundNr = roundNr;
            AttackerName = attacker.DisplayName;
            DefenderName = defender.DisplayName;
            StarterAttackerHP = attacker.HP;
            StarterDefenderHP = defender.HP;
        }

        public void AfterFight(FighterModel attacker, FighterModel defender)
        {
            AttackerLifeRemaining = attacker.HP;
            DefenderLifeRemaining = defender.HP;
            AttackerIsDead = attacker.IsDead;
            DefenderIsDead = defender.IsDead;
            AttackerWasKilled = attacker.WasKilled;
            DefenderWasKilled = defender.WasKilled;

            if (!attacker.IsDead)
            {
                Survivors.Add(attacker);
            }
            if (!defender.IsDead)
            {
                Survivors.Add(defender);
            }
        }

        public readonly int RoundNr;
        public readonly int StarterAttackerHP;
        public readonly int StarterDefenderHP;

        public string AttackerName { get; set; }
        public string DefenderName { get; set; }

        public bool AttackerIsDead { get; set; }
        public bool DefenderIsDead { get; set; }

        public bool DefenderWasKilled { get; set; }
        public bool AttackerWasKilled { get; set; }

        public int AttackerLifeLost
        {
            get
            {
                return (StarterAttackerHP - AttackerLifeRemaining);
            }
        }
        public int DefenderLifeLost
        {
            get
            {
                return (StarterDefenderHP - DefenderLifeRemaining);
            }
        }

        public int AttackerLifeRemaining { get; set; }

        public int DefenderLifeRemaining { get; set; }

        public List<FighterModel> Survivors { get; set; } = new List<FighterModel>();
    }

}
