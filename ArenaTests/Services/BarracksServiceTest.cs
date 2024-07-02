using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.Models;
using DevoraLimeArena.Services.ServiceImplementations;
using DevoraLimeArena.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Services
{
    [TestClass]
    public class BarracksServiceTest
    {

        private IFighterFactory _factory;
        private IBarracksService _barracksService;

        [TestInitialize]
        public void Init() { 
            _factory = new FighterFactory(new RandomRoller());
        }

        private void initBarrack() { 
            this._barracksService = new BarracksService();
        }

        [TestMethod]
        public void CanInitBarracks() { 
            this.initBarrack();

            var fighters = new List<FighterModel>();

            fighters.Add(_factory.EnsureSwordsman());
            fighters.Add(_factory.EnsureSwordsman());
            fighters.Add(_factory.EnsureSwordsman());

            this._barracksService.InitBarracks(fighters);

            Assert.AreEqual(3, this._barracksService.CheckFighters().Count);
        }

        [TestMethod]
        public void CanAddAndRemovePersonToBarrack()
        {
            initBarrack();
   
            Assert.AreEqual(0, _barracksService.CheckFighters().Count);
           
            var fighter = this._factory.EnsureSwordsman();

            _barracksService.AddFighterToBarrack(fighter);

            Assert.AreEqual(1,_barracksService.CheckFighters().Count);

            _barracksService.GetFighterFromBarrack();

            Assert.AreEqual(0, _barracksService.CheckFighters().Count);

        }

        [TestMethod]
        public void CanCheckForMoreThanOnePerson()
        {
            initBarrack();

            Assert.IsFalse(_barracksService.HasMoreThanOnePerson());

            var fighter = this._factory.EnsureSwordsman();

            _barracksService.AddFighterToBarrack(fighter);

            Assert.IsFalse(_barracksService.HasMoreThanOnePerson());

            var fighter2 = this._factory.EnsureSwordsman();

            _barracksService.AddFighterToBarrack(fighter2);

            Assert.IsTrue(_barracksService.HasMoreThanOnePerson());

        }

        [TestMethod]
        public void CanRestInBarracks()
        {
            initBarrack();

            var fighters = new List<FighterModel>();

            var fighter = this._factory.EnsureSwordsman(1);
            fighter.HP /= 2;

            fighters.Add(fighter);

            var fighter2 = this._factory.EnsureSwordsman(2);

            fighters.Add(fighter2);

            this._barracksService.InitBarracks(fighters);

            Assert.AreEqual(fighter.InitialHP / 2, this._barracksService.CheckFighters().First(x => x.Id == 1).HP);
            Assert.AreEqual(fighter.InitialHP, this._barracksService.CheckFighters().First(x => x.Id == 2).HP);

            _barracksService.Rest();

            Assert.AreEqual((fighter.InitialHP / 2)+10, this._barracksService.CheckFighters().First(x => x.Id == 1).HP);
            Assert.AreEqual(fighter.InitialHP, this._barracksService.CheckFighters().First(x => x.Id == 2).HP);


        }


    }
}
