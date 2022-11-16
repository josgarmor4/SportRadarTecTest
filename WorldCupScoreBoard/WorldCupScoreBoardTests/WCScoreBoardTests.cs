using NUnit.Framework;
using System;
using WorldCupScoreBoardLibrary;

namespace WorldCupScoreBoardTests
{
    public class WCScoreBoardTests
    {
        public WCScoreBoard wcsb { get; set; }        

        [SetUp]
        public void Setup()
        {            
            wcsb = new WCScoreBoard();
        }

        [Test]
        public void CanStartAMatch()
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.
                                           TestExamplesConstants.HomeTeamName, WCScoreBoardConstansts.
                                           TestExamplesConstants.AwayTeamName);
            
            Assert.That(matchId, Is.Positive);
        }

        [Test]
        [TestCase(WCScoreBoardConstansts.TestExamplesConstants.HomeTeamName, "")]
        [TestCase("", WCScoreBoardConstansts.TestExamplesConstants.AwayTeamName)]
        [TestCase("", "")]
        public void StartMatchWithAnyTeamNameEmptyTrhowException(string homeTeam, string awayTeam)
        {            
            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.startMatch(homeTeam, awayTeam));
        }

        [Test]
        public void CanFinishAMatch()
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.
                                           TestExamplesConstants.HomeTeamName, WCScoreBoardConstansts.
                                           TestExamplesConstants.AwayTeamName);

            wcsb.finishMatch(matchId);
           
            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.getMatchFromId(matchId));            
        }

        [Test]
        public void FinishMatchWithInvalidIdTrhowException()
        {            
            Assert.Throws<ArgumentException>(() => wcsb.finishMatch(10));
        }

        [Test]
        public void CanUpdateMatch()
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.
                                           TestExamplesConstants.HomeTeamName, WCScoreBoardConstansts.
                                           TestExamplesConstants.AwayTeamName);

            wcsb.updateMatch(matchId, 1, 1);
            
            Assert.Pass();
        }

        [Test]
        [TestCase(1, 0)]
        public void CheckUpdateMatchIsCorrect(int homeTeamScore, int awayTeamScore)
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.
                                           TestExamplesConstants.HomeTeamName, WCScoreBoardConstansts.
                                           TestExamplesConstants.AwayTeamName);

            wcsb.updateMatch(matchId, homeTeamScore, awayTeamScore);
            Match matchToCheck = wcsb.getMatchFromId(matchId);
                        
            Assert.That(homeTeamScore, Is.EqualTo(matchToCheck.HomeTeamScore));
            Assert.That(awayTeamScore, Is.EqualTo(matchToCheck.AwayTeamScore));
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(2, -5)]
        [TestCase(-3, -2)]
        public void UpdateMatchWithAnyTeamScoreNegativeTrhowException(int homeTeamScore, int awayTeamScore)
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.
                                           TestExamplesConstants.HomeTeamName, WCScoreBoardConstansts.
                                           TestExamplesConstants.AwayTeamName);

            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.updateMatch(matchId, homeTeamScore, awayTeamScore));
        }

        [Test]
        public void UpdateMatchIfNoExitsTrhowException()
        {            
            Assert.Throws<ArgumentException>(() => wcsb.updateMatch(25, 2, 3));
        }

        [Test]
        public void GetSummaryOfGames()
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.
                                           TestExamplesConstants.HomeTeamName, WCScoreBoardConstansts.
                                           TestExamplesConstants.AwayTeamName);

            string correctSummary = WCScoreBoardConstansts.
                                           TestExamplesConstants.CorrectSumary;

            string sumary = wcsb.getSummary();
            
            Assert.That(sumary, Is.EqualTo(correctSummary));
        }

        [Test]
        public void GetSummaryOfGamesOrderByTotalScoreIfEqualScoreOrderByMostRecently()
        {            
            CreateMatches();
            string summaryMatches = wcsb.getSummary();           
            
            Assert.That(summaryMatches, Is.EqualTo(WCScoreBoardConstansts.TestExamplesConstants.correctOrderSummary));
        }

        [Test]
        public void CanGetMatchFromId()
        {            
            int matchId = wcsb.startMatch(WCScoreBoardConstansts.TestExamplesConstants.HomeTeamName,
                                          WCScoreBoardConstansts.TestExamplesConstants.AwayTeamName);
            Match matchObtained = wcsb.getMatchFromId(matchId);
                        
            Assert.That(matchObtained, Is.Not.Null);
            Assert.That(matchObtained.HomeTeamName, Is.EqualTo(WCScoreBoardConstansts.TestExamplesConstants.HomeTeamName));
            Assert.That(matchObtained.AwayTeamName, Is.EqualTo(WCScoreBoardConstansts.TestExamplesConstants.AwayTeamName));
        }

        [TestCase(10)]
        public void CanGetMathFromIdReturnExceptionIfIdNotExists(int matchId)
        {            
            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.getMatchFromId(matchId));
        }

        #region Help methods
        private void CreateMatches()
        {
            int matchId = wcsb.startMatch("Mexico", "Canada");
            wcsb.updateMatch(matchId, 0, 5);

            matchId = wcsb.startMatch("Spain", "Brazil");
            wcsb.updateMatch(matchId, 10, 2);

            matchId = wcsb.startMatch("Germany", "France");
            wcsb.updateMatch(matchId, 2, 2);

            matchId = wcsb.startMatch("Uruguay", "Italy");
            wcsb.updateMatch(matchId, 6, 6);

            matchId = wcsb.startMatch("Argentina", "Australia");
            wcsb.updateMatch(matchId, 3, 1);
        }
        #endregion
    }
}