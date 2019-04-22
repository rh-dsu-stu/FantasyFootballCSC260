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
            var client = new NFLv3ProjectionsClient("1996605cd1e84deeae0aab46b07dcf83");
            var projections = client.GetFantasyDefenseProjectionsByGame("2018",7).OrderByDescending(p => p.PointsAllowed).Take(20).ToList();

            // Write data to console
            foreach (var projection in projections)
            {
                Console.WriteLine($"{projection.PlayerID} - {projection.Team} ({projection.PointsAllowed}) Points Allowed by Defense ST: {projection.PointsAllowedByDefenseSpecialTeams}");
            }
            Console.ReadKey();

            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

            //Database List  
            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases are :");
            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();


        }
    }
}
