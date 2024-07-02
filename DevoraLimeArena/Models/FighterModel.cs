using DevoraLimeArena.DB.Entities;

namespace DevoraLimeArena.Models
{
    public class FighterModel : Fighter
    {
        public FighterModel() {
        }

        public FighterModel(Fighter baseEntity) {
            Id = baseEntity.Id;
            type = baseEntity.type;
            switch (baseEntity.type)
            {
                case FighterType.Horseman:
                    InitialHP = 150;
                    HP = 150;
                    break;
                case FighterType.Swordsman:
                    InitialHP = 120;
                    HP = 120;
                    break;
                case FighterType.Archer:
                    InitialHP = 100;
                    HP = 100;
                    break;
            }
        }

        public int HP { get; set; }

        public int InitialHP { get; set; }

        public bool IsDead { get => HP < InitialHP / 4; }


        public bool WasKilled { get; set; } = false;


        public string DisplayName
        {
            get
            {
                string Name = "";

                switch (type)
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
            WasKilled = true;
            HP = 0;
        }
    }
}
