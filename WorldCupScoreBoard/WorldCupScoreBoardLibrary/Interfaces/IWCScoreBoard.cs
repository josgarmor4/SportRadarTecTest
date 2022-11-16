using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupScoreBoardLibrary.Interfaces
{
    public interface IWCScoreBoard
    {
        int StartMatch(string homeTeam, string awayTeam);
        void FinishMatch(int matchId);
        void UpdateMatch(int matchId, int homeScore, int awayScore);
        string GetSummary();
        Match GetMatchFromId(int matchId);
    }
}
