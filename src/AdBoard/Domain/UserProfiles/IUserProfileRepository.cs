using Domain.Core;
using System;
using System.Threading.Tasks;

namespace Domain.UserProfiles
{
    // This is just the RepositoryContracts or Interface defined at the Domain Layer
    // as requisite for the UserProfile Aggregate

    public interface IUserProfileRepository
    {
        Task AddAsync(UserProfile userProfile);

        Task<UserProfile> GetAsync(TypedIdValueObject userProfileId);

        UserProfile Update(UserProfile userProfile);
    }
}