﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupScoreBoardLibrary
{
    public class WCScoreBoard
    {
        private Dictionary<int, string> matchesDictionary { get; set; }
        private int matchId { get; set; }

        public WCScoreBoard()
        {
            matchesDictionary = new Dictionary<int, string>();
            matchId += 1;
        }

        public int startMatch(string homeTeam, string awayTeam)
        {
            return -1;
        }
    }
}
