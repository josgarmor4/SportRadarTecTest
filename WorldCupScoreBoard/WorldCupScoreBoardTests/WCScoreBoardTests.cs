using NUnit.Framework;
using WorldCupScoreBoardLibrary;

namespace WorldCupScoreBoardTests
{
    public class WCScoreBoardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanStartAMatch()
        {
            WCScoreBoard wcsb = new WCScoreBoard();           
            int matchId = wcsb.startMatch("Mexico","Canada");
            Assert.That(matchId, Is.Positive);            
        }
       
    }
}