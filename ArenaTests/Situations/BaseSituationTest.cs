using DevoraLimeArena.Services.ServiceImplementations;
using DevoraLimeArena.Services.ServiceInterfaces;
using Moq;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTests.Situations
{
    public class BaseSituationTest
    {
      public required FightRound round;
      public required FighterFactory fighterFactory;
        

        protected void initFightRound() {
            this.round = new FightRound(new RandomRoller());          
        }

        protected void initFightRoundWithMock(bool alwaysreturn)
        {
            var randomRollerMock = new Mock<IRandomRoller>();
            randomRollerMock.Setup(r => r.RandomRoll(It.IsAny<int>())).Returns(alwaysreturn);

            this.round = new FightRound(randomRollerMock.Object);
        }

        protected void initfighterFactory()
        {
            this.fighterFactory = new FighterFactory(new RandomRoller());
        }
    }
}
