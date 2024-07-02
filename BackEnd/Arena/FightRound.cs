using BackEnd.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class FightRound
    {

        public FightResult Fight(int round, Fighter attacker, Fighter defender)
        { 

            var fightResult = new FightResult(round, attacker, defender);

            //Ha saját típusát támadja akkor a védekezö hal meg. Nem is kell tovább nézni.
            if (attacker.FighterType == defender.FighterType)
            {
                defender.Die();
                //harc utáni élet levonás
                attacker.AfterFight();           
                fightResult.AfterFight(attacker, defender);
                return fightResult;      
            }
            
            switch (attacker.FighterType)
            {
                case FighterType.Archer:
                    // íjász támadja lovast, lovas 40% eséllyel elpatkol
                    if (defender.FighterType == FighterType.Horseman)
                    {
                        if (AttackRoller.GetInstance().RandomRoll(40))
                        {
                            defender.Die();
                        }
                    }

                    // íjász támadja kardost, Kardos megpusztul
                    else if(defender.FighterType == FighterType.Swordsman)
                    {
                        defender.Die();
                    }
                    break;

                case FighterType.Swordsman:
                    //kardos támadja íjászt, íjásznak csengettek
                    if (defender.FighterType == FighterType.Archer)
                    {
                        defender.Die();
                    }
                    // kardos támadja lovast - mindenki túléli

                    break;
                case FighterType.Horseman:
                    // Lovas támadja kardost - jaj ez nem jó ötlet! Lovas meghal
                    if (defender.FighterType == FighterType.Swordsman)
                    {
                        attacker.Die();
                    }
                    // Lovast támadja íjászt, ìjásznak annyi meg egy bambi
                    else if (defender.FighterType == FighterType.Archer)
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
