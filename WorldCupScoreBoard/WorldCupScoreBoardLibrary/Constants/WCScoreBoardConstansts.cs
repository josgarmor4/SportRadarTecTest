using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupScoreBoardLibrary
{
    public class WCScoreBoardConstansts
    {
        public class TestExamplesConstants
        {
            public const string HomeTeamName = "Mexico";
            public const string AwayTeamName = "Canada";
            public const string CorrectSumary = "Mexico 0 - Canada 0 \r\n";
            public const string correctOrderSummary = "Uruguay 6 - Italy 6 \r\nSpain 10 - Brazil 2 \r\nMexico 0 - Canada 5 \r\nArgentina 3 - Australia 1 \r\nGermany 2 - France 2 \r\n";            
        }

        public class ExceptionsMessage
        {
            public const string ScoreCantBeNegative = "Match score can't be negative";
            public const string MatchNotExists = "Match doesn't exits";
            public const string MatchIdNotExists = "Match id doesn't exists";
        }
    }
}
