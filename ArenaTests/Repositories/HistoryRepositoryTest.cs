using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.DB.Interface;
using DevoraLimeArena.DB.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Repositories
{
    [TestClass]
    public class HistoryRepositoryTest : BaseRepositoryTest
    {
        private IArenaHistoryRepository _historyRepository;

        [TestInitialize]
        public void init()
        {
            this.initContext();
            _historyRepository = new ArenaHistoryRepository(this._context);
        }


        [TestMethod]
        public void CanGetHistoriesForArena() {

            var history = new List<History>();
            history.Add(new History()
            {
                AttackerName = "A",
                DefenderName = "B",
            });

            var arenaRepository = new ArenaRepository(_context);

            var ret = arenaRepository.CreateArenaEntity();


            arenaRepository.AssignHistoryToArenaEntity(ret.Id, history);

            var result = this._historyRepository.GetHistoriesForArena(ret.Id);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
