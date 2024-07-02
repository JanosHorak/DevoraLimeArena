using System.Text.Json.Serialization;

namespace DevoraLimeArena.DB.Entities
{
    public class History
    {
        [JsonIgnore]
        public int Id {  get; set; }

        [JsonIgnore]
        public int ArenaId { get; set; }

        public int RoundNr { get; set; }

        public string AttackerName { get; set; }
        public string DefenderName { get; set; }

        public int HealthChangeAttacker { get; set; }
        public int HealthChangedDefender { get; set; }

        public int FinalHealthAttacker { get; set; }
        public int FinalHealthDefender { get; set; }

        public bool IsAttackerDead { get; set; }
        public bool IsDefenderDead { get; set; }

        public bool IsAttackerKileld { get; set; }
        public bool IsDefenderKilled { get; set; }

        public int InitialHealthAttacker { get; set; }
        public int InitialHealthDefender { get; set; }

        [JsonIgnore]
        public virtual Arena Arena { get; set; }
    }
}
