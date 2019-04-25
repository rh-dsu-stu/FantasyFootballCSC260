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
            var projections = client.GetTeamGameStats("2018", 7).OrderByDescending(p => p.PasserRating).Take(20).ToList();

            // Write data to console
            foreach (var projection in projections)
            {
                Console.WriteLine($"{projection.Team} ({projection.PasserRating}) {projection.PasserRating}");
            }
            Console.ReadKey();

            //var dbClient = new MongoClient("mongodb://127.0.0.1:27017"); 
            var vom = new GeneralPlayer();
            vom.name = "Matt Ryan";
            vom.GetPlayerInfo(vom, client);

            Console.WriteLine($"{vom.playerID} ----- {vom.name} --- {vom.number} ---- {vom.team} ---- {vom.position}");
            Console.ReadKey();




            /*var db = dbClient.GetDatabase("test");
            var collection = db.GetCollection<User>("test");
            var document = new User
            {
                userName = "Hello"
            };
            collection.InsertOne(document);
            */




        }
    }
}
