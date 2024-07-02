using ArenaTests.Situations;
using DevoraLimeArena.Services.ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Tests.FightSituations
{
    [TestClass]
    public class ArcherAttacks : BaseSituationTest
    {

     

        [TestInitialize]
        public void Init()
        {
            base.initfighterFactory();
        }


        [TestMethod]
        public void ArcherAttacksHorsemanHorseManWins()
        {
            var attacker = this.fighterFactory.EnsureArcher();
            var defender = this.fighterFactory.EnsureHorseman();
            this.initFightRoundWithMock(true);
            var result = round.Fight(1, attacker, defender);

            Assert.IsFalse(result.AttackerIsDead);
            Assert.IsTrue(result.DefenderIsDead);
        }

        [TestMethod]
        public void ArcherAttacksHorsemanHorseArcherWins()
        {
            var attacker = this.fighterFactory.EnsureArcher();
            var defender = this.fighterFactory.EnsureHorseman();
            this.initFightRoundWithMock(false);
            var result = round.Fight(1, attacker, defender);
            
            Assert.IsFalse(result.AttackerIsDead);
            Assert.IsFalse(result.DefenderIsDead);
        }

        [TestMethod]
        public void ArcherAttackArcher()
        {
            var attacker = this.fighterFactory.EnsureArcher();
            var defender = this.fighterFactory.EnsureArcher();
            base.initFightRound();
            var result = round.Fight(1, attacker, defender);

            Assert.IsFalse(result.AttackerIsDead);
            Assert.IsTrue(result.DefenderIsDead);
        }

        [TestMethod]
        public void ArcherAttackSwordsman()
        {
            var attacker = this.fighterFactory.EnsureArcher();
            var defender = this.fighterFactory.EnsureSwordsman();
            base.initFightRound();
            var result = round.Fight(1, attacker, defender);

            Assert.IsFalse(result.AttackerIsDead);
            Assert.IsTrue(result.DefenderIsDead);
        }
    }
}
