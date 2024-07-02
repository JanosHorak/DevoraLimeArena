using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLimeArena.Services.ServiceImplementations
{
    public class FightRound
    {
        private IRandomRoller randomRoller;
        public FightRound(IRandomRoller randomRoller) { 
        this.randomRoller = randomRoller;
        }

        public FightResult Fight(int round, FighterModel attacker, FighterModel defender)
        { 

            var fightResult = new FightResult(round, attacker, defender);

            //Ha saját típusát támadja akkor a védekezö hal meg. Nem is kell tovább nézni.
            if (attacker.type == defender.type)
            {
                defender.Die();
                //harc utáni élet levonás
                attacker.AfterFight();           
                fightResult.AfterFight(attacker, defender);
                return fightResult;      
            }
            
            switch (attacker.type)
            {
                case FighterType.Archer:
                    // íjász támadja lovast, lovas 40% eséllyel elpatkol
                    if (defender.type == FighterType.Horseman)
                    {
                        if (this.randomRoller.RandomRoll(40))
                        {
                            defender.Die();
                        }
                    }

                    // íjász támadja kardost, Kardos megpusztul
                    else if(defender.type == FighterType.Swordsman)
                    {
                        defender.Die();
                    }
                    break;

                case FighterType.Swordsman:
                    //kardos támadja íjászt, íjásznak csengettek
                    if (defender.type == FighterType.Archer)
                    {
                        defender.Die();
                    }
                    // kardos támadja lovast - mindenki túléli

                    break;
                case FighterType.Horseman:
                    // Lovas támadja kardost - jaj ez nem jó ötlet! Lovas meghal
                    if (defender.type == FighterType.Swordsman)
                    {
                        attacker.Die();
                    }
                    // Lovast támadja íjászt, ìjásznak annyi meg egy bambi
                    else if (defender.type == FighterType.Archer)
                    {
                        defender.Die();
                    }
                    break;
            }

            //Levonjuk az életet
            defender.AfterFight();
            attacker.AfterFight();

            fightResult.AfterFight(attacker, defender);

            return fightResult;
        }
    }
}
