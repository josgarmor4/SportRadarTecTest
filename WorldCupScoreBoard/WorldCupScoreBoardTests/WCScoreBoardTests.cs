using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WorldCupScoreBoardLibrary;

namespace WorldCupScoreBoardTests
{
    public class WCScoreBoardTests
    {
        public WCScoreBoard wcsb { get; set; }

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
            int matchId = wcsb.startMatch("Mexico", "Canada");

            // assert
            Assert.That(matchId, Is.Positive);
        }

        [Test]
        [TestCase("Mexico", "")]
        [TestCase("", "Canada")]
        [TestCase("", "")]
        public void StartMatchWithAnyTeamNameEmptyTrhowException(string homeTeam, string awayTeam)
        {
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.startMatch(homeTeam, awayTeam));
        }

        [Test]
        public void CanFinishAMatch()
        {
            // act
            int matchId = wcsb.startMatch("Mexico", "Canada");
            wcsb.finishMatch(matchId);

            // assert
            Assert.True(!wcsb.matchesDictionary.ContainsKey(matchId));
        }

        [Test]
        public void FinishMatchWithInvalidIdTrhowException()
        {
            // assert
            Assert.Throws<ArgumentException>(() => wcsb.finishMatch(10));
        }

        [Test]
        public void CanUpdateMatch()
        {
            // act
            int matchId = wcsb.startMatch("Mexico", "Canada");
            wcsb.updateMatch(matchId, 1, 1);
            // assert
            Assert.Pass();
        }

        [Test]
        [TestCase(1, 0)]
        public void CheckUpdateMatchIsCorrect(int homeTeamScore, int awayTeamScore)
        {
            int matchId = wcsb.startMatch("Mexico", "Canada");
            wcsb.updateMatch(matchId, homeTeamScore, awayTeamScore);
            Match matchToCheck;
            wcsb.matchesDictionary.TryGetValue(matchId, out matchToCheck);
            // assert
            Assert.That(homeTeamScore, Is.EqualTo(matchToCheck.HomeTeamScore));
            Assert.That(awayTeamScore, Is.EqualTo(matchToCheck.AwayTeamScore));
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(2, -5)]
        [TestCase(-3, -2)]
        public void UpdateMatchWithAnyTeamScoreNegativeTrhowException(int homeTeamScore, int awayTeamScore)
        {
            int matchId = wcsb.startMatch("Mexico", "Canada");
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => wcsb.updateMatch(matchId, homeTeamScore, awayTeamScore));
        }

        [Test]
        public void UpdateMatchIfNoExitsTrhowException()
        {
            // assert
            Assert.Throws<ArgumentException>(() => wcsb.updateMatch(25, 2, 3));
        }

        [Test]
        public void GetSummaryOfGames()
        {
            int matchId = wcsb.startMatch("Mexico", "Canada");
            Match match;
            wcsb.matchesDictionary.TryGetValue(matchId, out match);
            string matchSummary = match.toString();
            string sumarry = wcsb.getSummary();

            Assert.That(sumarry, Is.EqualTo(matchSummary));
        }

        [Test]
        public void GetSummaryOfGamesOrderByTotalScoreIfEqualScoreOrderByMostRecently()
        {
            CreateMatches();
            string summaryMatches = wcsb.getSummary();
            string correctOrderSummary = "Uruguay 6 - Italy 6";
            correctOrderSummary += "Spain 10 - Brazil 2";
            correctOrderSummary += "Mexico 0 - Canada 5";
            correctOrderSummary += "Argentina 3 - Australia 1";
            correctOrderSummary += "Germany 2 - France 2";

            Assert.That(summaryMatches, Is.EqualTo(correctOrderSummary));
        }

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
    }
}