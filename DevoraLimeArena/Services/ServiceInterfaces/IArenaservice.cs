using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Repository;

namespace DevoraLimeArena.Services.ServiceInterfaces
{
    public interface IArenaservice
    {

        int BuildNewArena(int heroesAmount);

        List<History> StartArenaFight(int id);

    }
}
