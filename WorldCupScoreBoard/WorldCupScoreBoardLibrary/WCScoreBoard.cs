using System;
using System.Collections.Generic;
using System.Linq;
using WorldCupScoreBoardLibrary.Interfaces;

namespace WorldCupScoreBoardLibrary
{
    public class WCScoreBoard : IWCScoreBoard
    {
        private Dictionary<int, Match> matchesDictionary;
        private int matchId;
       
        public WCScoreBoard()
        {
            matchesDictionary = new Dictionary<int, Match>();
            matchId = 0;
        }

        public int StartMatch(string homeTeam, string awayTeam)
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

        public void FinishMatch(int matchId)
        {            
            if (matchesDictionary.ContainsKey(matchId))
            {
                matchesDictionary.Remove(matchId);
            }

            else
            {
                throw new ArgumentException(WCScoreBoardConstansts.ExceptionsMessage.MatchIdNotExists);
            }
        }

        public void UpdateMatch(int matchId, int homeScore, int awayScore)
        {
            Match matchToUpdate;
            matchesDictionary.TryGetValue(matchId, out matchToUpdate);

            if (matchToUpdate == null)
            {
                throw new ArgumentException(WCScoreBoardConstansts.ExceptionsMessage.MatchNotExists);
            }

            if (homeScore < 0 || awayScore < 0)
            {
                throw new ArgumentOutOfRangeException(WCScoreBoardConstansts.ExceptionsMessage.ScoreCantBeNegative);
            }
            
            matchToUpdate.HomeTeamScore = homeScore;
            matchToUpdate.AwayTeamScore = awayScore;
        }

        public string GetSummary()
        {
            string matchesSummary = "";

            List<Match> matches = matchesDictionary.OrderByDescending(O => O.Value.HomeTeamScore + O.Value.AwayTeamScore)
                             .ThenByDescending(THO => THO.Key)
                             .ToDictionary(x => x.Key, x => x.Value)
                             .Values
                             .ToList();


            foreach (Match match in matches)
            {
                matchesSummary += match.toString();
            }

            return matchesSummary;
        }

        public Match GetMatchFromId(int matchId)
        {
            Match match;
            
            if (!matchesDictionary.TryGetValue(matchId, out match))
            {
                throw new ArgumentOutOfRangeException(WCScoreBoardConstansts.ExceptionsMessage.MatchIdNotExists);
            }
            
            return match;
        }          
    }
}
