using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FantasyFootball
{
    class Quarterback : GeneralPlayer
    {
        
        public int passAtt;
        public int passCmp;
        public double passYds;
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
            passTDs = 0;
            interc = 0;
            sacks = 0;
            rushYds = 0;
            rushTDs = 0;
        }

        public Quarterback(string n, int p, string t, string pos, int no)
        {
            this.name = n;
            this.playerID = p;
            this.team = t;
            this.position = pos;
            this.number = no;
        }


        public void GetQBStats(Quarterback q, NFLv3StatsClient client, int week)
        {
            var currSeason = "2018";
            var tmpPlayer = client.GetPlayerGameStatsByPlayerID(currSeason, week, q.playerID);

            q.fumbles = (int)tmpPlayer.Fumbles;
            q.passAtt = (int)tmpPlayer.PassingAttempts;
            q.passCmp = (int)tmpPlayer.PassingCompletions;
            q.passYds = (double)tmpPlayer.PassingYards;
            q.passTDs = (int)tmpPlayer.Touchdowns;
            q.interc = (int)tmpPlayer.Interceptions;
            q.sacks = (int)tmpPlayer.Sacks;
            q.rushYds = (double)tmpPlayer.RushingYards;
            q.rushTDs = (int)tmpPlayer.RushingTouchdowns;
        }

        

    }
}
