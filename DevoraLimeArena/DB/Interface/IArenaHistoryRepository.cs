using DevoraLimeArena.DB.Entities;

namespace DevoraLimeArena.DB.Interface
{
    public interface IArenaHistoryRepository
    {
        List<History> GetHistoriesForArena(int arenaId);
    }
}
