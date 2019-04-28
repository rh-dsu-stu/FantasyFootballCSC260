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
    class Kicker : GeneralPlayer 
    {
        
        public int fgAtt;
        public int fgMade;
        public int epAtt;
        public int epMade;


        public Kicker()
        {
            //name = "";
            //playerID = 0;
            //team = "";
            //position = "";
            //number = 0;
            fumbles = 0;
            fgAtt = 0;
            fgMade = 0;
            epAtt = 0;
            epMade = 0;
            byeWeek = 0;
        }

        public Kicker(string n, int p, string t, string pos, int no, int bye)
        {
            this.name = n;
            this.playerID = p;
            this.team = t;
            this.position = pos;
            this.number = no;
            this.byeWeek = bye;
        }

        ~Kicker()
        {

        }

        public void GetKickerStats(Kicker k, NFLv3StatsClient client, int week)
        {
           
            var tmpPlayer = client.GetPlayerGameStatsByPlayerID("2018", week, k.playerID);

            if (tmpPlayer != null)
            {
                k.epAtt = (int)tmpPlayer.ExtraPointsAttempted;
                k.epMade = (int)tmpPlayer.ExtraPointsMade;
                k.fgAtt = (int)tmpPlayer.FieldGoalsAttempted;
                k.fgMade = (int)tmpPlayer.FieldGoalsMade;

            } else
            {
                k = new Kicker();
            }

        }
    }
}
