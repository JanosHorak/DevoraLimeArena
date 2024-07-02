using DevoraLimeArena.DB;
using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.DB.Repository;
using DevoraLimeArena.Services.ServiceImplementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Repositories
{
    [TestClass]
    public class ArenaRepositoryTest : BaseRepositoryTest
    {

        IArenaRepository _arenaRepository;
        

        [TestInitialize]
        public void init()
        {
            this.initContext();
            _arenaRepository = new ArenaRepository(this._context);
        }


        [TestMethod]
        public void CanCreateArenaEntityThenGetByID()
        {
            var ret = _arenaRepository.CreateArenaEntity();
            Assert.IsNotNull(ret);

            var ret2 = _arenaRepository.GetArenaById(ret.Id);
            Assert.IsNotNull(ret2);
        }


        [TestMethod]
        public void CanCreateArenaEntityWithFighters()
        {

            var fighters = new List<Fighter>();

            var factory = new FighterFactory(new RandomRoller());

            fighters.Add(factory.EnsureHorseman());

            var ret = _arenaRepository.CreateArenaEntity(fighters);
            Assert.IsNotNull(ret);

            var ret2 = _arenaRepository.GetArenaById(ret.Id);
            Assert.IsNotNull(ret2);
            Assert.AreNotEqual(0, ret2.Fighters.Count);
        }

        [TestMethod]
        public void CanAssignHistoryToArenaEntity()
        {

            var history = new List<History>();
            history.Add(new History() { 
            AttackerName = "A",
            DefenderName = "B",
            });

            var ret = _arenaRepository.CreateArenaEntity();


            _arenaRepository.AssignHistoryToArenaEntity(ret.Id, history);

            var ret2 = _arenaRepository.GetArenaById(ret.Id);
            Assert.IsNotNull(ret2);
            Assert.AreNotEqual(0, ret2.History.Count);
        }

        [TestMethod]
        public void CanSeeIfArenaExists()
        {
            Assert.IsFalse(_arenaRepository.ArenaExists(999));

            var ret = _arenaRepository.CreateArenaEntity();

            Assert.IsTrue(_arenaRepository.ArenaExists(ret.Id));
        }


    }
}
