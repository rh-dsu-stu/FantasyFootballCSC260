using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;

namespace FantasyFootball
{
    class Quarterback : GeneralPlayer
    {
        public int passAtt;
        public int passCmp;
        public double passYds;
        public double passCmpPct;
        public double ydsPerAtt;
        public double ydsPerCmp;
        public int passTDs;                   // touchdowns
        public int interc;                // interceptions
        public int sacks;
        public double rushYds;
        public int rushTDs;
        
        public Quarterback()
        {
            name = "";
            playerID = 0;
            team = "";
            position = "";
            number = 0;
            fumbles = 0;
            passAtt = 0;
            passCmp = 0;
            passYds = 0;
            passCmpPct = 0;
            ydsPerAtt = 0;
            ydsPerCmp = 0;
            passTDs = 0;
            interc = 0;
            sacks = 0;
            rushYds = 0;
            rushTDs = 0;
        }

        public void GetQBStats(Quarterback q, NFLv3StatsClient client, int week)
        {
            var currSeason = "2018";
            var tmpPlayer = client.GetPlayerGameStatsByPlayerID(currSeason, week, q.playerID);

            q.fumbles = (int)tmpPlayer.Fumbles;
            q.passAtt = (int)tmpPlayer.PassingAttempts;
            q.passCmp = (int)tmpPlayer.PassingCompletions;
            q.passYds = (double)tmpPlayer.PassingYards;
            q.passCmpPct = (double)tmpPlayer.PassingCompletionPercentage;
            q.ydsPerAtt = (double)tmpPlayer.PassingYardsPerAttempt;
            q.ydsPerCmp = (double)tmpPlayer.PassingYardsPerCompletion;
            q.passTDs = (int)tmpPlayer.Touchdowns;
            q.interc = (int)tmpPlayer.Interceptions;
            q.sacks = (int)tmpPlayer.Sacks;
            q.rushYds = (double)tmpPlayer.RushingYards;
            q.rushTDs = (int)tmpPlayer.RushingTouchdowns;
        }

    }
}
