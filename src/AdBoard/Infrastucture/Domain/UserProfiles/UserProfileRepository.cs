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

        public async Task<UserProfile> GetAsync(Guid id)
        {
            return await context.UserProfiles.SingleOrDefaultAsync(x => x.Id.Value == id);
        }

        public UserProfile Update(UserProfile userProfile)
        {
            return context.UserProfiles.Update(userProfile).Entity;
        }

        public async Task AddAsync(UserProfile userProfile)
        {
            await context.UserProfiles.AddAsync(userProfile);
        }
    }
}
