using mongodb_playground.Query;
using System;

namespace mongodb_playground.DbModels
{
    public class User : IQuery
    {
        public Object _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
    }
}
