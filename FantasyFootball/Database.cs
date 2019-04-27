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
            var collection = db.GetCollection<GeneralPlayer>(team);
           // var qb = (Quarterback)collection.AsQueryable().FirstOrDefault(n => n.position == "QB");

            var returnteamQB = db.GetCollection<Quarterback>(team).Find(x => x.position.Contains("QB")).ToList();
            var returnteamWR = db.GetCollection<WRRBTE>(team).Find(x => x.position.Contains("WR")).ToList();
            var returnteamRB = db.GetCollection<WRRBTE>(team).Find(x => x.position.Contains("RB")).ToList();
            var returnteamTE = db.GetCollection<WRRBTE>(team).Find(x => x.position.Contains("TE")).ToList();
            var returnteamK = db.GetCollection<Kicker>(team).Find(x => x.position.Contains("K")).ToList();
              
            var returnteam = new List<GeneralPlayer>();
            
            
            foreach (var qb in returnteamQB)
                returnteam.Add(qb);
            foreach (var rb in returnteamRB)
                returnteam.Add(rb);
            foreach (var wr in returnteamWR)
                returnteam.Add(wr);
            foreach (var te in returnteamTE)
                returnteam.Add(te);
            foreach (var k in returnteamK)
                returnteam.Add(k);
            

            return returnteam;
        }
            
    }
}
