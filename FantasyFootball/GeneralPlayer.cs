﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;


namespace FantasyFootball
{
    [BsonKnownTypes(typeof(Quarterback), typeof(WRRBTE), typeof(Kicker))]
    class GeneralPlayer
    {
        // these fields apply to every player and should be inheritable by the other classes
        public ObjectId Id { get; set; }
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

        // function to get player's name
        public string GetPlayersName()
        {
            Console.WriteLine("Please enter a player's first name: ");
            var name = Console.ReadLine();

            return name;

        }

        // function to fill a user's team
        public List<GeneralPlayer> FillTeam(NFLv3StatsClient client)
        {
            List<GeneralPlayer> playersTeam = new List<GeneralPlayer>();
            GeneralPlayer player = new GeneralPlayer();

            // going to set a default team to size 7: 1 QB 2 RB 2 WR 1 TE 1 K not including ST/Def
            for (var i = 0; i < 7; i++)
            {
                player.name = GetPlayersName();
                GetPlayerInfo(player, client);
                if (player.position == "QB")
                {
                    playersTeam.Add(new Quarterback(player.name, player.playerID, player.team, player.position, player.number));
                }
                if (player.position == "RB" || player.position == "WR" || player.position == "TE")
                {
                    playersTeam.Add(new WRRBTE(player.name, player.playerID, player.team, player.position, player.number));
                }
                if (player.position == "K")
                {
                    playersTeam.Add(new Kicker(player.name, player.playerID, player.team, player.position, player.number));
                }
            }
            return playersTeam;
        }

        // function to get the playerID
        public void GetPlayerInfo(GeneralPlayer f, NFLv3StatsClient client)
        {
            Predicate<Player> playerFinder = (Player p) => { return p.Name == f.name; };

            var tmpPlayer = client.GetPlayers().Find(playerFinder);

            f.playerID = tmpPlayer.PlayerID;
            f.team = tmpPlayer.Team;
            f.position = tmpPlayer.Position;
            f.number = (int)tmpPlayer.Number;
        }

        public virtual void GetStat()
        {

        }

        // seperates the list into lists of player types and then gets their stats
        public void GetStats(List<GeneralPlayer> list)
        {
            Console.WriteLine("What week would you like stats for?");
            Console.WriteLine("Please enter a number between 1 and 17");
            var week = Convert.ToInt32(Console.ReadLine());
            var quarters = list.OfType<Quarterback>();
            var wrrbtes = list.OfType<WRRBTE>();
            var kicker = list.OfType<Kicker>();
            NFLv3StatsClient client = new NFLv3StatsClient("1996605cd1e84deeae0aab46b07dcf83");

            foreach (var q in quarters)
            {
                q.GetQBStats(q, client, week);
            }

            foreach (var wr in wrrbtes)
            {
                wr.GetWRRBTEStats(wr, client, week);
            }

            foreach (var k in kicker)
            {
                k.GetKickerStats(k, client, week);
            }



        }

        public void PrintStats(List<GeneralPlayer> list)
        {
            var quarters = list.OfType<Quarterback>();
            var wrrbtes = list.OfType<WRRBTE>();
            var kicker = list.OfType<Kicker>();

            Console.WriteLine("Weekly Stats");
            Console.WriteLine("Name\t\t\t" + "Att\t" + "Cmp\t" + "Yds\t" + "TDs\t" + "Int\t" + "Sacks\t" + "rYds\t" + "rTDs\t" + "fum\t");
            foreach (var q in quarters)
            {
                Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", q.name, q.passAtt, q.passCmp, q.passYds,
                    q.passTDs, q.interc, q.sacks, q.rushYds, q.rushTDs, q.fumbles);
            };
            Console.WriteLine("Name\t\t\t" + "RAtt\t" + "rYds\t" + "rTDs\t" + "rec\t" + "recYds\t" + "recTDs\t" + "fum\t");
            foreach (var wr in wrrbtes) 
            {
                Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t", wr.name, wr.rushAtt, wr.rushYds, wr.rushTDs,
                    wr.rec, wr.recYds, wr.recTDs, wr.fumbles);
            };
            Console.WriteLine("Name\t\t\t" + "epAtt\t"+ "epMade\t" + "fgAtt\t" + "fgMade\t");
            foreach (var k in kicker)
            {
                Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}", k.name, k.epAtt, k.epMade, k.fgAtt, k.fgMade);
            };



        }
    }
}
