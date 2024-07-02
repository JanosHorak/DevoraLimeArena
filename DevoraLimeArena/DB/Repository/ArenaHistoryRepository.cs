using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevoraLimeArena.DB.Repository
{
    public class ArenaHistoryRepository : IArenaHistoryRepository
    {
        private readonly ArenaDBContext _dbContext;

        public ArenaHistoryRepository(ArenaDBContext arenaDBContext)
        {
            this._dbContext = arenaDBContext;
        }

        public List<History> GetHistoriesForArena(int arenaId) { 
            return this._dbContext.Histories.Where(x=>x.ArenaId == arenaId).ToList();
        }
    }
}
