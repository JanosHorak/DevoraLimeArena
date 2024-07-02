using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Fighters
{
    public class Fighter
    {
        public Fighter(int id, FighterType fighterType)
        {
            Id = id;
            FighterType = fighterType;
            int initialHP = 0;
            switch (fighterType)
            {
                case FighterType.Archer:
                    initialHP = 100;
                    break;
                case FighterType.Swordsman:
                    initialHP = 120;
                    break;
                case FighterType.Horseman:
                    initialHP = 150;
                    break;
            }

            InitialHP = initialHP;
            HP = initialHP;
        }

        public int Id { get; set; }

        public int HP { get; set; }

        public int InitialHP { get; set; }

        public bool IsDead { get => HP < InitialHP / 4; }


        public void Rest()
        {
            HP = Math.Min(HP + 10, InitialHP);
        }



        public void AfterFight()
        {
            if (IsDead) return;

            HP /= 2;
        }

        public void Die()
        {
            this.HP = 0;
        }

        public FighterType FighterType { get; set; }

        public string DisplayName
        {
            get
            {
                string Name = "";

                switch (this.FighterType)
                {
                    case FighterType.Archer:
                        Name = "Íjász";
                        break;
                    case FighterType.Swordsman:
                        Name = "Kardos";
                        break;
                    case FighterType.Horseman:
                        Name = "Lovas";
                        break;
                }

                return Name + " " + Id.ToString();

            }
        }

    }

    public enum FighterType
    {
        Archer,
        Swordsman,
        Horseman
    }
}
