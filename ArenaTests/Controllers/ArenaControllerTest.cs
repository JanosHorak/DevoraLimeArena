using DevoraLimeArena.Controllers;
using DevoraLimeArena.DB;
using DevoraLimeArena.DB.Repository;
using DevoraLimeArena.Services.ServiceImplementations;
using DevoraLimeArena.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Controllers
{
    [TestClass]
    public class ArenaControllerTest
    {


        private ArenaController _controller;
        private ArenaRepository _arenaRepo;

        [TestInitialize]
        public void Init()
        {


            var options = new DbContextOptionsBuilder<ArenaDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;


            var context = new ArenaDBContext(options);
            _arenaRepo = new ArenaRepository(context);

            var arenaService = new Mock<IArenaservice>();
            arenaService.Setup(a => a.StartArenaFight(It.IsAny<int>())).Returns(new List<DevoraLimeArena.DB.Entities.History>());

            _controller = new ArenaController(arenaService.Object, _arenaRepo);

        }

        [TestMethod]
        public void CanGet()
        {
            var ret = _controller.Get();
            Assert.IsInstanceOfType<OkObjectResult>(ret);

        }

        [TestMethod]
        public void CanGenerate()
        {
            var ret = _controller.GenerateArenaWithHeroes(10);
            Assert.IsInstanceOfType<OkObjectResult>(ret);
        }

        [TestMethod]
        public void CanFailGenerate()
        {
            var ret = _controller.GenerateArenaWithHeroes(1);
            Assert.IsInstanceOfType<BadRequestObjectResult>(ret);
        }

        [TestMethod]
        public void CanFailGetArena()
        {
            var ret = _controller.Fight(1);
            Assert.IsInstanceOfType<NotFoundObjectResult>(ret);
        }

        [TestMethod]
        public void CanGetArena()
        {
            var arena = _arenaRepo.CreateArenaEntity();
            var ret = _controller.Fight(arena.Id);

            Assert.IsInstanceOfType<OkObjectResult>(ret);
        }
    }
}
