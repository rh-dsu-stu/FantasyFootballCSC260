using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FantasyFootball
{
    class User
    {
        private string _userName;

        public string UserName => _userName;


        public User(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }
            _userName = userName;
        }

        public bool UserNameExists(IMongoDatabase database, string userName)
        {
            var filter = new BsonDocument("name", userName);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }

        
    }
}
