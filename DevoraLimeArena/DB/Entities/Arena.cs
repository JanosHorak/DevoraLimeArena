namespace DevoraLimeArena.DB.Entities
{
    public class Arena
    {
        public int Id { get; set; }

        public ICollection<Fighter> Fighters { get; set; }

        public ICollection<History> History { get; set; }
    }
}
