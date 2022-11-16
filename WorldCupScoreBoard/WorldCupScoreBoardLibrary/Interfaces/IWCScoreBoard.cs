using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupScoreBoardLibrary.Interfaces
{
    public interface IWCScoreBoard
    {
        int startMatch(string homeTeam, string awayTeam);
        void finishMatch(int matchId);
        void updateMatch(int matchId, int homeScore, int awayScore);
        string getSummary();
        Match getMatchFromId(int matchId);
    }
}
