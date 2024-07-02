using ArenaTests.Situations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Tests.FightSituations
{
    [TestClass]
    public class HorsemanAttacks : BaseSituationTest
    {

        [TestInitialize]
        public void Init()
        {
            base.initfighterFactory();
            base.initFightRound();
        }


        [TestMethod]
        public void HorsemanAttackHorseman()
        {
            var attacker = this.fighterFactory.EnsureHorseman();
            var defender = this.fighterFactory.EnsureHorseman();
            var result = round.Fight(1, attacker, defender);

            Assert.IsFalse(result.AttackerIsDead);
            Assert.IsTrue(result.DefenderIsDead);
        }

        [TestMethod]
        public void HorsemanAttackArcher()
        {
            var attacker = this.fighterFactory.EnsureHorseman();
            var defender = this.fighterFactory.EnsureArcher();
            var result = round.Fight(1, attacker, defender);

            Assert.IsFalse(result.AttackerIsDead);
            Assert.IsTrue(result.DefenderIsDead);
        }

        [TestMethod]
        public void HorsemanAttackSwordsman()
        {
            var attacker = this.fighterFactory.EnsureHorseman();
            var defender = this.fighterFactory.EnsureSwordsman();
            var result = round.Fight(1, attacker, defender);

            Assert.IsTrue(result.AttackerIsDead);
            Assert.IsFalse(result.DefenderIsDead);
        }
    }
}
