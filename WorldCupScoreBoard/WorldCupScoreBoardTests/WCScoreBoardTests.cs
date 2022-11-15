using NUnit.Framework;
using System;
using WorldCupScoreBoardLibrary;

namespace WorldCupScoreBoardTests
{
    public class WCScoreBoardTests
    {
        public WCScoreBoard wcsb {get;set;}

        [SetUp]
        public void Setup()
        {
            //arrange
            wcsb = new WCScoreBoard();
        }

        [Test]
        public void CanStartAMatch()
        {                  
            // act
            int matchId = wcsb.startMatch("Mexico","Canada");
            
            // assert
            Assert.That(matchId, Is.Positive);            
        }
          
        [Test]
        [TestCase("Mexico","")]
        [TestCase("", "Canada")]
        [TestCase("", "Canada")]
        public void StartMatchWithAnyTeamNameEmptyTrhowException(string homeTeam, string awayTeam)
        {            
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.startMatch(homeTeam, awayTeam));
        }
    }
}