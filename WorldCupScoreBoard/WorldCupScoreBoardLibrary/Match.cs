using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupScoreBoardLibrary
{
    public class Match
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public Match() { }
        public Match(string homeTeamName, string awayTeamName, int homeTeamScore, int awayTeamScore)
        {
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }

        public string toString()
        {
            string sumaryMatch = $"{HomeTeamName} - {AwayTeamName}: {HomeTeamScore} - {AwayTeamScore}";
            return sumaryMatch;
        }
    }
}
