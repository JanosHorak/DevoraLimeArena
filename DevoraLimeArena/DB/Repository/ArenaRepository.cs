using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using Microsoft.EntityFrameworkCore;

namespace DevoraLimeArena.DB.Repository
{
    public class ArenaRepository : IArenaRepository
    {
        private readonly ArenaDBContext _dbContext;

        public ArenaRepository(ArenaDBContext arenaDBContext) 
        {
            this._dbContext = arenaDBContext;
        }

        public void AssignHistoryToArenaEntity(int id, List<History> historyEntities)
        {
           var arena = this._dbContext.Arenas.Find(id);
            if (arena != null)
            {
                arena.History = historyEntities;
            }
            _dbContext.SaveChanges();
        }


        public Arena CreateArenaEntity()
        {
            var arena = new Arena();
            _dbContext.Arenas.Add(arena);
            _dbContext.SaveChanges();
            return arena;
        }

        public Arena GetArenaById(int id)
        {
            return _dbContext.Arenas.Include(x => x.History).Include(x => x.Fighters).FirstOrDefault(x => x.Id == id);
        }

        public Arena CreateArenaEntity(List<Fighter> fighters)
        {
            var arena = new Arena();
            arena.Fighters = fighters;
            _dbContext.Arenas.Add(arena);
            _dbContext.SaveChanges();
            return arena;
        }

        public bool ArenaExists(int id) {
            return _dbContext.Arenas.Any(x => x.Id == id);
        }
    }
}
