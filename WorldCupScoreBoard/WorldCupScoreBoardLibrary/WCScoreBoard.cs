﻿using System.Collections.Generic;


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
            
            Match match = new Match (homeTeam, awayTeam,0,0);            
            matchId++;
            matchesDictionary.Add(matchId, match);
            return matchId;
        }
    }
}
