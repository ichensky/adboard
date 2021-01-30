using Application.Configuration.Queries;
using System;

namespace Application.Users.GetUserName
{
    public class GetAdUserNameQuery : IQuery<AdUserNameDto>
    {
        public GetAdUserNameQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
