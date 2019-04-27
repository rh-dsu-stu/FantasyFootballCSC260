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
    class WRRBTE : GeneralPlayer
    {
        
        public int rushAtt;
        public double rushYds;
        public int rushTDs;
        public int rec;
        public double recYds;
        public int recTDs;

        public WRRBTE()
        {
            name = "";
            playerID = 0;
            team = "";
            position = "";
            number = 0;
            fumbles = 0;
            rushAtt = 0;
            rushYds = 0;
            rushTDs = 0;
            rec = 0;
            recYds = 0;
            recTDs = 0;
        }

        public WRRBTE(string n, int p, string t, string pos, int no)
        {
            this.name = n;
            this.playerID = p;
            this.team = t;
            this.position = pos;
            this.number = no;
        }

        ~WRRBTE()
        {

        }

        public void GetWRRBTEStats(WRRBTE b, NFLv3StatsClient client, int week)
        { 
            var tmpPlayer = client.GetPlayerGameStatsByPlayerID("2018", week, b.playerID);

            b.fumbles = (int)tmpPlayer.Fumbles;
            b.rushAtt = (int)tmpPlayer.RushingAttempts;
            b.rushYds = (double)tmpPlayer.RushingYards;
            b.rushTDs = (int)tmpPlayer.RushingTouchdowns;
            b.rec = (int)tmpPlayer.Receptions;
            b.recYds = (double)tmpPlayer.ReceivingYards;
            b.recTDs = (int)tmpPlayer.ReceivingTouchdowns;
            
        }
    }
}
