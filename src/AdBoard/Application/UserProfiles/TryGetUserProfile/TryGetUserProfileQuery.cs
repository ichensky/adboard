using Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.TryGetUserProfile
{
    public class TryGetUserProfileQuery : IQuery<UserProfileDto?>
    {
        public TryGetUserProfileQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
