using Domain.Core;
using Domain.UserProfiles;
using Infrastucture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastucture.Domain.UserProfiles
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AdBoardDbContext context;

        public UserProfileRepository(AdBoardDbContext context)
        {
            this.context = context;
        }

        public async Task<UserProfile> GetAsync(TypedIdValueObject userProfileId)
        {
            return await context.UserProfiles.SingleOrDefaultAsync(x => x.Id == userProfileId);
        }

        public async Task<UserProfile?> TryGetAsync(TypedIdValueObject id)
        {
            return await context.UserProfiles.SingleOrDefaultAsync(x => x.Id == id);
        }

        public UserProfile Update(UserProfile userProfile)
        {
            return context.UserProfiles.Update(userProfile).Entity;
        }

        public UserProfile Add(UserProfile userProfile)
        {
            return context.UserProfiles.Add(userProfile).Entity;
        }

        public void Delete(UserProfile model)
        {
            context.UserProfiles.Remove(model);
        }
    }
}
