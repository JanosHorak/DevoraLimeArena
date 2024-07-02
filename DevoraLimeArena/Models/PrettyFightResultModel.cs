using DevoraLimeArena.DB.Entities;
using System.Text.Json.Serialization;

namespace DevoraLimeArena.Models
{
    public class PrettyFightResultModel
    {
        public PrettyFightResultModel(History history) {

            this.Round = history.RoundNr;
            Attacker = new FightResultStatus
            {
                Name = history.AttackerName,
                Status = GetStatus(history.IsAttackerDead,history.IsAttackerKileld),
                HealthLoss = history.HealthChangeAttacker,
                StarterHealth = history.InitialHealthAttacker,
                EndingHealth = history.FinalHealthAttacker
            };
            Defender = new FightResultStatus
            {
                Name = history.DefenderName,
                Status = GetStatus(history.IsDefenderDead,history.IsDefenderKilled),
                HealthLoss = history.HealthChangedDefender,
                StarterHealth = history.InitialHealthDefender,
                EndingHealth = history.FinalHealthDefender
            };
        }

        [JsonPropertyName("Kör")]
        public int Round { get; set; }

        [JsonPropertyName("Támadó")]
        public FightResultStatus Attacker { get; set; }

        [JsonPropertyName("Védekező")]
        public FightResultStatus Defender { get; set; }


        private static string GetStatus(bool isDead, bool wasKilled) {
            if (!isDead && !wasKilled)
            {
                return "Túlélte";
            }
            if(isDead && !wasKilled) {
                return "Meghalt végkimerültségben";
            }
            return "Megölték";
        }
    }

    public class FightResultStatus {

        [JsonPropertyName("Név")]
        public string Name { get; set; }

        [JsonPropertyName("Kezdő élet")]
        public int StarterHealth { get; set; }

        [JsonPropertyName("Élet veszteség")]
        public int HealthLoss { get; set; }
        [JsonPropertyName("Végső élet")]
        public int EndingHealth { get; set; }

        [JsonPropertyName("Állapot")]
        public string Status { get; set; }
           
    }
}
