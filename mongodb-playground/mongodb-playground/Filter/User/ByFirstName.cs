using System;
using System.Collections.Generic;
using System.Text;

namespace mongodb_playground.Filter.User
{
    public class ByFirstName : IFilter
    {
        public ByFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public string FirstName { get; }
    }
}
