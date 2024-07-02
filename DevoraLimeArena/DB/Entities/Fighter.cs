using System.Runtime.Serialization;

namespace DevoraLimeArena.DB.Entities
{
    public enum FighterType
    {
        Archer,
        Swordsman,
        Horseman
    }

    public class Fighter
    {
        public int? Id { get; set; }
        public FighterType type { get; set; }
        public int ArenaId {get;set;}

        public virtual Arena? Arena { get; set; }
    }
}
