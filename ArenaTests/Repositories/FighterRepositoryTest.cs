using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.DB.Repository;
using DevoraLimeArena.Services.ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Repositories
{
    [TestClass]
    public class FighterRepositoryTest : BaseRepositoryTest
    {


        IFighterRepository _fighterRepository;


        [TestInitialize]
        public void init()
        {
            this.initContext();
            _fighterRepository = new FighterRepository(this._context);
        }

        [TestMethod]
        public void CanGetFightersForArena() {
            var arenaRepository = new ArenaRepository(this._context);
            
            var fighters = new List<Fighter>();

            var factory = new FighterFactory(new RandomRoller());

            var hm = factory.EnsureHorseman();
            hm.Id = null;

            fighters.Add(hm);

            var arena = arenaRepository.CreateArenaEntity(fighters);

            var res = _fighterRepository.GetFightersForArena(arena.Id);

            Assert.IsNotNull(res);
            Assert.AreNotEqual(0, res.Count);
        }
    }
}
