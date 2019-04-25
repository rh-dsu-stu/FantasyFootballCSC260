using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;

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
            name = "";
            playerID = 0;
            team = "";
            position = "";
            number = 0;
            fumbles = 0;
            fgAtt = 0;
            fgMade = 0;
            epAtt = 0;
            epMade = 0;
        }

        ~Kicker()
        {

        }

        public void GetKickerStats(Kicker k, NFLv3StatsClient client, int week)
        {
           
            var tmpPlayer = client.GetPlayerGameStatsByPlayerID("2018", week, k.playerID);

            k.epAtt = (int)tmpPlayer.ExtraPointsAttempted;
            k.epMade = (int)tmpPlayer.ExtraPointsMade;
            k.fgAtt = (int)tmpPlayer.FieldGoalsAttempted;
            k.fgMade = (int)tmpPlayer.FieldGoalsMade;

        }
    }
}
