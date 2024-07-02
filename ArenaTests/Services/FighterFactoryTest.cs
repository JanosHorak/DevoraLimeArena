using DevoraLimeArena.DB.Entities;
using DevoraLimeArena.Services.ServiceImplementations;
using DevoraLimeArena.Services.ServiceInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Services
{
    [TestClass]
    public class FighterFactoryTest
    {

        private IFighterFactory _factory;

        public void initSimple() {
            _factory = new FighterFactory(new RandomRoller());
        }

        public void initWithRandomMock(FighterType typeToEnsure)
        { 
            var randomRoller = new Mock<IRandomRoller>();
            randomRoller.Setup(x=>x.RandomClass()).Returns(typeToEnsure);
            _factory = new FighterFactory(randomRoller.Object);
        }

        [TestMethod]
        public void CanEnsureHorseman() {
            initSimple();
            var result = this._factory.EnsureHorseman();

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Horseman, result.type);

        }

        [TestMethod]
        public void CanEnsureHorsemanWithId()
        {
            initSimple();
            var result = this._factory.EnsureHorseman(123);

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Horseman, result.type);
            Assert.AreEqual(123, result.Id);
        }

        [TestMethod]
        public void CanEnsureSwordsman()
        {
            initSimple();
            var result = this._factory.EnsureSwordsman();

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Swordsman, result.type);

        }

        [TestMethod]
        public void CanEnsureSwordsmanWithId()
        {
            initSimple();
            var result = this._factory.EnsureSwordsman(123);

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Swordsman, result.type);
            Assert.AreEqual(123, result.Id);
        }

        [TestMethod]
        public void CanEnsureArcher()
        {
            initSimple();
            var result = this._factory.EnsureArcher();

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Archer, result.type);

        }

        [TestMethod]
        public void CanEnsureArcherWithId()
        {
            initSimple();
            var result = this._factory.EnsureArcher(123);

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Archer, result.type);
            Assert.AreEqual(123, result.Id);
        }

        [TestMethod]
        public void CanEnsureRandom()
        {
            initSimple();
            var result = this._factory.EnsureRandom();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanEnsureRandomHorseman()
        {
            initWithRandomMock(FighterType.Horseman);
            var result = this._factory.EnsureRandom();

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Horseman, result.type);
        }

        [TestMethod]
        public void CanEnsureRandomSwordsman()
        {
            initWithRandomMock(FighterType.Swordsman);
            var result = this._factory.EnsureRandom();

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Swordsman, result.type);
        }

        [TestMethod]
        public void CanEnsureRandomArcher()
        {
            initWithRandomMock(FighterType.Archer);
            var result = this._factory.EnsureRandom();

            Assert.IsNotNull(result);
            Assert.AreEqual(FighterType.Archer, result.type);
        }

    }
}
