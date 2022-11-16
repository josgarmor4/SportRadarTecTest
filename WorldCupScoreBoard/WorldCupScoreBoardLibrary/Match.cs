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
        
        public Match(string homeTeamName, string awayTeamName)
        {
            if (string.IsNullOrEmpty(homeTeamName) || string.IsNullOrEmpty(awayTeamName))
            {
                throw new ArgumentOutOfRangeException("Teams names could not be empty");
            }
            else
            {
                HomeTeamName = homeTeamName;
                AwayTeamName = awayTeamName;
                HomeTeamScore = 0;
                AwayTeamScore = 0;
            }
        }

        public string toString()
        {
            string sumaryMatch = $"{HomeTeamName} {HomeTeamScore} - {AwayTeamName} {AwayTeamScore} \r\n";
            return sumaryMatch;
        }
    }
}
