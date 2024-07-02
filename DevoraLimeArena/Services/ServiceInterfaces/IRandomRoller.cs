using DevoraLimeArena.DB.Entities;

namespace DevoraLimeArena.Services.ServiceInterfaces
{
    public interface IRandomRoller
    {
        bool RandomRoll(int successChance);
        FighterType RandomClass();
    }
}
