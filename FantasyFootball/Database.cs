using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FantasyFootball
{
    class Database
    {
        
        

        public static void SaveTeam(List<GeneralPlayer> list)
        {
            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
            var db = dbClient.GetDatabase("MyDB");

            Console.WriteLine("What is the name of the team?");
            var teamName = Console.ReadLine();
            var collection = db.GetCollection<GeneralPlayer>(teamName);
            collection.InsertMany(list);
        }

        public static string ListTeams()
        {
            var teamtoreturn = "";
            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
            var db = dbClient.GetDatabase("MyDB");
            var col = db.ListCollectionNames();
            var all = col.ToList();
            Console.WriteLine("The list of saved teams is:");
            foreach (var c in all)
            {
                Console.WriteLine("{0}", c);
            }
            Console.WriteLine("Please enter a team name from the list above.");
            teamtoreturn = Console.ReadLine();
            return teamtoreturn;
        }

        public static List<GeneralPlayer> GetSavedTeam(string team)
        {
            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");
            var db = dbClient.GetDatabase("MyDB");
            var returnteamQB = db.GetCollection<Quarterback>(team).Find<Quarterback>(_ => true).ToList();
            return returnteam;
        }
            
    }
}
