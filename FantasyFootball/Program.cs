using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using FantasyData.Api.Client;

namespace FantasyFootball
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to client and get data
            NFLv3StatsClient client = new NFLv3StatsClient("apikey");
            //var projections = client.GetTeamGameStats("2018", 7).OrderByDescending(p => p.PasserRating).Take(20).ToList();



            string teamName = "";
            GeneralPlayer play = new GeneralPlayer();
            List<GeneralPlayer> teamList = new List<GeneralPlayer>();

            var userChoice = 1;
            while (userChoice != 6)
            {
                userChoice = Menu.DisplayMenu();
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Create Team");
                        var team = new List<GeneralPlayer>();
                        team = play.FillTeam(client);
                        teamList = team;
                        //play.GetStats(team);
                        break;
                    case 2:
                        Database.SaveTeam(teamList);
                        Console.WriteLine("Team Saved\n");
                        break;
                    case 3:
                        play.GetStats(teamList);
                        play.PrintStats(teamList);
                        break;
                    case 4:
                        teamName = Database.ListTeams();
                        teamList = Database.GetSavedTeam(teamName);
                        break;
                    case 5:


                        break;

                }
            }
           

            


            
           
            




        }
    }
}
