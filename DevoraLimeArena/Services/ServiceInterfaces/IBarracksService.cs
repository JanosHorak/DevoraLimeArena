using DevoraLimeArena.Models;
using System;

namespace DevoraLimeArena.Services.ServiceInterfaces
{
    public interface IBarracksService
    {
        public void InitBarracks(List<FighterModel> fighters);
        public FighterModel GetFighterFromBarrack();
        public void AddFighterToBarrack(FighterModel fighter);
        public void Rest();
        public bool HasMoreThanOnePerson();

        public List<FighterModel> CheckFighters();
    }
}
