using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceImplementations;

namespace DevoraLimeArena.Services.ServiceInterfaces
{
    public interface IFighterFactory
    {
        FighterModel EnsureArcher(int? id = null);

        FighterModel EnsureSwordsman(int? id = null);

        FighterModel EnsureHorseman(int? id = null);

        FighterModel EnsureRandom();

    }
}
