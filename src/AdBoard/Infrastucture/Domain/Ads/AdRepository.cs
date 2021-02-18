using Domain.Ads;
using Domain.Core;
using Domain.UserProfiles;
using Infrastucture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastucture.Domain.Ads
{
    public class AdRepository : IAdRepository
    {
        private readonly AdBoardDbContext context;

        public AdRepository(AdBoardDbContext context)
        {
            this.context = context;
        }
     
        public Ad Add(Ad model)
        {
            return context.Ads.Add(model).Entity;
        }

        public Task<Ad> GetAsync(TypedIdValueObject id)
        {
            return context.Ads.SingleAsync(x => x.Id == id);
        }

        public async Task<Ad?> TryGetAsync(TypedIdValueObject id)
        {
            return await context.Ads.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Ad Update(Ad model)
        {
            return context.Ads.Update(model).Entity;
        }

        public void Delete(Ad model)
        {
            context.Ads.Remove(model);
        }
    }
}
