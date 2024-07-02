using DevoraLimeArena.DB.Entities;

namespace DevoraLimeArena.DB.Interface
{
    public interface IArenaRepository
    {
       Arena GetArenaById(int id);


        Arena CreateArenaEntity();
        Arena CreateArenaEntity(List<Fighter> fighters);

        void AssignHistoryToArenaEntity(int id, List<History> historyEntities);

        bool ArenaExists(int id);

    }
}
