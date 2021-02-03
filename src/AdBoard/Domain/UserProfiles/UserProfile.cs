using Domain.Core;
using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.UserProfiles
{
    public class UserProfile : AggregateRoot
    {
        private TypedIdValueObject id;
        private Name name;
        private ContactInformation? contactInformation;
        private Picture? picture;

        private UserProfile()
        {
            // For EF
        }

        private UserProfile(TypedIdValueObject id, Name name, Picture? picture)
        {
            this.id = id;
            this.name = name;
            this.picture = picture;
        }

        public static UserProfile CreateUserProfile(TypedIdValueObject id, Name name, Picture? picture) 
        {
            return new UserProfile(id, name, picture);
        }

        public ContactInformation? ContactInformation => contactInformation;

        public TypedIdValueObject Id => id;

        public Picture? Picture => picture;

        public Name Name => name;
    }
}
