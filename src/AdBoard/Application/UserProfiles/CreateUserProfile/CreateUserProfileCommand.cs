using Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.CreateUserProfile
{
    public class CreateUserProfileCommand : CommandBase<UserProfileDto>
    {
        public CreateUserProfileCommand(Guid aspNetUsersId, string picture, string firstName, string lastName)
        {
            AspNetUsersId = aspNetUsersId;
            Picture = picture;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid AspNetUsersId { get; }

        public string Picture { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
