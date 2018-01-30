using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using mongodb_playground.Command.User;
using mongodb_playground.Query.User;
using System;
using System.Linq;
using mongodb_playground.Filter.User;
using mongodb_playground.Command;
using mongodb_playground.Filter;
using mongodb_playground.Query;
using mongodb_playground.DbModels;

namespace mongodb_playground
{
    class Program
    {
        const string DB_NAME = "test_db";
        const string USERS_COLL = "users_coll";
        static DbClient client = new DbClient();

        public static IMongoCollection<TColl> RunQuery<TColl>(
            string collName)
            where TColl : IQuery
        {
            return client.getDatabase(DB_NAME).GetCollection<TColl>(collName);
        }

        public static UpdateResult RunUpdateCommand<TColl, TCommand, TFilter>(
            IMongoCollection<TColl> coll,
            TCommand update,
            TFilter filter)
            where TCommand : ICommand
            where TFilter : IFilter
        {
            var upd = new BsonDocument("$set", update.ToBsonDocument());
            return coll.UpdateOne(filter.ToBsonDocument(), upd);
        }

        public static void PrintResults(
            IMongoQueryable res)
        {
            int i = 0;
            foreach (var r in res)
            {
                Console.WriteLine(String.Format("[RES {0}]: {1}", ++i, r.ToJson()));
            }
        }

        static void Main(string[] args)
        {
            /*
                === Create users ===
                mongo
                use test_db
                u1 = { FirstName: "fUser1", LastName: "lUser1", Email: "email1@email.com", Organization: "org1" }
                u2 = { FirstName: "fUser2", LastName: "lUser2", Email: "email2@email.com", Organization: "org2" }
                db.users_coll.insert(u1)
                db.users_coll.insert(u2)
                db.users_coll.find().pretty()
            */

            // === Partial query 
            var res = RunQuery<GetEmail>(USERS_COLL); //.AsQueryable().Where(u => u.Email == "email");
            PrintResults(res.AsQueryable());

            // === Partial update
            var result = RunUpdateCommand(
                RunQuery<User>(USERS_COLL),
                new UpdateLastNameAndEmail("NEW NAME", "NEW@EMAIL.EMAIL"),
                new ByFirstName("fUser2"));
            Console.WriteLine(result.ToJson());

            Console.ReadLine();
        }
    }
}
