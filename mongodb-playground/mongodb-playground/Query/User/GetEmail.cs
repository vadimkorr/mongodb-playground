using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace mongodb_playground.Query.User
{
    [BsonIgnoreExtraElements]
    public class GetEmail : IQuery
    {
        public Object _id { get; set; }
        public string Email { get; set; }
    }
}
