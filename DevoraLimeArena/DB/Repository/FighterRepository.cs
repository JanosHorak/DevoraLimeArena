using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.Models;

namespace DevoraLimeArena.DB.Repository
{
    public class FighterRepository : IFighterRepository
    {

        private readonly ArenaDBContext _dbContext;

        public FighterRepository(ArenaDBContext arenaDBContext)
        {
            this._dbContext = arenaDBContext;
        }

        public List<FighterModel> GetFightersForArena(int arenaId)
        {
            return this._dbContext.Fighters.Where(x => x.ArenaId == arenaId).Select(x => new FighterModel(x)).ToList();   
        }


    }
}
