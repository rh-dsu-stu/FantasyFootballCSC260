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
            NFLv3StatsClient client = new NFLv3StatsClient("1996605cd1e84deeae0aab46b07dcf83");
            //var projections = client.GetTeamGameStats("2018", 7).OrderByDescending(p => p.PasserRating).Take(20).ToList();

            var week = 0;
            bool onBye = false;

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
                        break;
                    case 2:
                        if (teamList.Count() == 0)
                        {
                            Console.WriteLine("Please create or access a saved team first!\n");
                            break;
                        }
                        Database.SaveTeam(teamList);
                        Console.WriteLine("Team Saved\n");
                        break;
                    case 3:
                        if (teamList.Count() == 0)
                        {
                            Console.WriteLine("Please create or access a saved team first!\n");
                            break;
                        }
                        week = play.GetStatWeek();
                        onBye = play.CheckByes(teamList, week);
                        if ( onBye)
                        { break; } // exits this case because a new team needs to be selected
                        play.GetStats(teamList, client, week);
                        play.PrintStats(teamList);
                        break;
                    case 4:
                        teamName = Database.ListTeams();
                        teamList = Database.GetSavedTeam(teamName);
                        break;
                    case 5:
                        if (teamList.Count() == 0)
                        {
                            Console.WriteLine("Please create or access a saved team first!\n");
                            break;
                        }
                        var ppr = FantasyPoints.GetPPR();
                        FantasyPoints.CalcFantasyPoints(teamList, ppr);
                        FantasyPoints.PrintFantasyPoints(teamList);
                        break;

                }
            }
        }
    }
}
