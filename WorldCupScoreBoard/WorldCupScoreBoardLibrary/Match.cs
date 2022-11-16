using System;

namespace WorldCupScoreBoardLibrary
{
    public class Match
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        //Prevent automatic generation of parameterless constructor
        private Match()
        {

        }

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

        public string toString() => $"{HomeTeamName} {HomeTeamScore} - {AwayTeamName} {AwayTeamScore} \r\n";
        
    }
}
