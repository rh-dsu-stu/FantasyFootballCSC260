using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;


namespace FantasyFootball
{
    class GeneralPlayer
    {
        // these fields apply to every player and should be inheritable by the other classes
        public string name { get; set; }
        public int playerID { get; set; }
        public string team { get; set; }
        public string position { get; set; }
        public int number { get; set; }
        public int fumbles { get; set; }

        // default constructor
        // paramaterless constructor can be used when storing objects in mongoDB
        public GeneralPlayer()
        {
            name = "";
            playerID = 0;
            team = "";
            position = "";
            number = 0;
            fumbles = 0;
        }

        ~GeneralPlayer()
        {
        }

        // function to get the playerID
        public void GetPlayerInfo(GeneralPlayer f, NFLv3StatsClient client)
        {
            Predicate<Player> playerFinder = (Player p) => { return p.Name == name; };
            
            var tmpPlayer = client.GetPlayers().Find(playerFinder);

            f.playerID = tmpPlayer.PlayerID;
            f.team = tmpPlayer.Team;
            f.position = tmpPlayer.Position;
            f.number = (int)tmpPlayer.Number;
        }

        
    }
}
