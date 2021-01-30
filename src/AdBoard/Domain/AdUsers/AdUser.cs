using Domain.Core;
using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.AdUsers
{
    public class AdUser : AggregateRoot
    {
        private readonly Guid userId;
        private readonly Name name;
        private readonly ContactInformation contactInformation;

        private AdUser()
        {
            // For EF
        }

        public AdUser(Guid userId, Name name, ContactInformation contactInformation)
        {
            this.userId = userId;
            this.name = name;
            this.contactInformation = contactInformation;
        }

        public Name Name => name;

        public ContactInformation ContactInformation => contactInformation;

        public Guid UserId => userId;
    }
}
