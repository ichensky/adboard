using Domain.Core;
using System;
using System.Threading.Tasks;

namespace Domain.Ads
{
    // This is just the RepositoryContracts or Interface defined at the Domain Layer
    // as requisite for the UserProfile Aggregate

    public interface IAdRepository : IBaseRepository<Ad> { }
}