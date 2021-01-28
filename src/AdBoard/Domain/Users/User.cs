using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users
{
    public class User : AggregateRoot
    {
        private readonly Name name;
        private readonly ContactInformation contactInformation;

        public User(Name name, ContactInformation contactInformation)
        {
            this.name = name;
            this.contactInformation = contactInformation;
        }

        public Name Name => name;
        public ContactInformation ContactInformation => contactInformation;
    }
}
