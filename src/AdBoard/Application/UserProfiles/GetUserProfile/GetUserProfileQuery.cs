using Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.GetUserProfile
{
    public class GetUserProfileQuery : IQuery<UserProfileDto>
    {
        public GetUserProfileQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
