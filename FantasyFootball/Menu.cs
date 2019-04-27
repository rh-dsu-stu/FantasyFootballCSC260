using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NFLv3;

namespace FantasyFootball
{
    class Menu : GeneralPlayer
    {
        private static readonly string _menuItems = 
            "Welcome to the Fantasy Football Calculator App!\n" +
            "Please Select an Option:\n" +
            "1) Create Team\n" + 
            "2) Save Team\n" +
            "3) View Teams Stats for Week\n" +
            "4) Access Saved Team\n" +
            "5) Calculate Fantasy Points\n" +
            "6) Exit\n";
        
        public static int DisplayMenu()
        {
            int userOpt = 1;
            bool isInt1to5 = false;
            while (!isInt1to5 && userOpt > 0 && userOpt < 7)
            {
                Console.WriteLine(_menuItems);
                var input = Console.ReadLine();
                isInt1to5 = int.TryParse(input, out userOpt);
            }

            return userOpt;
            
        }    

        /*public static int SelectFantasyPointValue()
        {
            var ppr
        }*/



        
      



        
    }
}
