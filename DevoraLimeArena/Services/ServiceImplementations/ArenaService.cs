using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevoraLimeArena.Services.ServiceImplementations
{
    public class ArenaService : IArenaservice
    {
        private readonly IArenaRepository arenaRepository;
        private readonly IFighterFactory fighterFactory;
        private readonly IBarracksService barracksService;
        private readonly IFighterRepository fighterRepository;
        private readonly IRandomRoller randomRoller;

        public ArenaService(
            IArenaRepository arenaRepository,
            IFighterFactory fighterFactory,
            IBarracksService barracksService,
            IFighterRepository fighterRepository,
            IRandomRoller randomRoller)
        {
            this.fighterFactory = fighterFactory;
            this.arenaRepository = arenaRepository;
            this.barracksService = barracksService;
            this.fighterRepository = fighterRepository;
            this.randomRoller = randomRoller;
        }

        public int BuildNewArena(int heroesAmount)
        {

            
            var fighters = new List<Fighter>();
            for (int i = 0; i < heroesAmount; i++)
            {
                var newGenerated = this.fighterFactory.EnsureRandom();
                newGenerated.Id = null;
                var newItem = newGenerated as Fighter; 
                fighters.Add(newItem);
            }

            var arena = arenaRepository.CreateArenaEntity(fighters);



            return arena.Id;



        }

        public List<History> StartArenaFight(int id)
        {


            var arena = this.arenaRepository.GetArenaById(id);

            if (arena.History.Any())
            { 
                return arena.History.ToList();
            }

            var fighters = this.fighterRepository.GetFightersForArena(id);

            this.barracksService.InitBarracks(fighters);

            var results = this.DoTheTournament();

            var fightrounds = results.Select(x => MapResultToRound(x, arena)).ToList();

            this.arenaRepository.AssignHistoryToArenaEntity(id, fightrounds);

            return this.arenaRepository.GetArenaById(id).History.ToList();


        }

        private List<FightResult> DoTheTournament()
        {
            var ret = new List<FightResult>();

            var fightRound = new FightRound(this.randomRoller);

            int roundnr = 1;

            while (this.barracksService.HasMoreThanOnePerson())
            {
                var attacker = this.barracksService.GetFighterFromBarrack();
                var defender = this.barracksService.GetFighterFromBarrack();

                var result = fightRound.Fight(roundnr, attacker, defender);
                ret.Add(result);

                this.barracksService.Rest();
                foreach (var survivor in result.Survivors)
                {
                    this.barracksService.AddFighterToBarrack(survivor);
                }
                roundnr++;
            }

            return ret;


        }


        private static History MapResultToRound(FightResult result, Arena arena)
        {
            return new History
            {
                Arena = arena,
                AttackerName = result.AttackerName,
                DefenderName = result.DefenderName,
                FinalHealthAttacker =  result.AttackerLifeRemaining,
                FinalHealthDefender = result.DefenderLifeRemaining,
                HealthChangeAttacker = result.AttackerLifeLost,
                HealthChangedDefender = result.DefenderLifeLost,
                IsAttackerDead = result.AttackerIsDead,
                IsDefenderDead = result.DefenderIsDead,
                RoundNr = result.RoundNr,
                InitialHealthAttacker = result.StarterAttackerHP,
                InitialHealthDefender = result.StarterDefenderHP,
                IsDefenderKilled = result.DefenderWasKilled,
                IsAttackerKileld = result.AttackerWasKilled
            };
        }
    }
}
