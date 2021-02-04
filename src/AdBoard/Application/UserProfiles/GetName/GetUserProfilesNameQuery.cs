using Application.Configuration.Queries;
using Application.Users.GetUserName;
using System;

namespace Application.UserProfiles.GetName
{
    public class GetUserProfilesNameQuery : IQuery<UserProfilesNameDto>
    {
        public GetUserProfilesNameQuery(Guid userId)
        {
            UserId = userId;
        }


        public Guid UserId { get; }
    }
}
