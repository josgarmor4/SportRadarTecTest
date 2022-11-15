using System;
using System.Collections.Generic;


namespace WorldCupScoreBoardLibrary
{
    public class WCScoreBoard
    {
        public Dictionary<int, Match> matchesDictionary { get; set; }
        private int matchId { get; set; }

        public WCScoreBoard()
        {
            matchesDictionary = new Dictionary<int, Match>();
            matchId = 0;
        }

        public int startMatch(string homeTeam, string awayTeam)
        {
            Match match;
            try
            {
                match = new Match(homeTeam, awayTeam);
                matchId++;
                matchesDictionary.Add(matchId, match);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException(ex.Message);
            }
            return matchId;
        }

        public void finishMatch(int matchId)
        {
            Match match;
            matchesDictionary.TryGetValue(matchId, out match);
            if (match != null)
            {
                matchesDictionary.Remove(matchId);
            }
            else
            {
                throw new ArgumentException("Id don't exists");
            }
                                
        }

        public void updateMatch(int matchId, int homeScore, int awayScore)
        {
            Match matchToUpdate;
            matchesDictionary.TryGetValue(matchId, out matchToUpdate);
            if (matchToUpdate == null)
            {
                throw new ArgumentException("Match don't exits");
            }
            if(homeScore < 0 || awayScore < 0)
            {
                throw new ArgumentOutOfRangeException("Match score can't be negative");
            }
            matchToUpdate.HomeTeamScore = homeScore;
            matchToUpdate.AwayTeamScore = awayScore;
        }
    }
}
