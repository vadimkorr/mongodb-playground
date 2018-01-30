using System;
using System.Collections.Generic;
using System.Text;

namespace mongodb_playground.Command.User
{
    public class UpdateLastNameAndEmail : ICommand
    {
        public UpdateLastNameAndEmail(string lastName, string email) {
            LastName = lastName;
            Email = email;
        }
        // no readonly use { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
