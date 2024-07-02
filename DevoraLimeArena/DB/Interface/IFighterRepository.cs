using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.Models;

namespace DevoraLimeArena.DB.Interface
{
    public interface IFighterRepository
    {
        public List<FighterModel>GetFightersForArena(int arenaId);
    }
}
