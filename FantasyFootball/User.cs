using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace FantasyFootball
{
    class User
    {

        public ObjectId ID { get; set; }
        public string userName { get; set; }


        

        public User()
        {
            
        }



        
    }
}
