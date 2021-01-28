using Application.Configuration.Queries;
using System;

namespace Application.Users.GetUserName
{
    public class GetUserNameQuery : IQuery<UserNameDto>
    {
        public GetUserNameQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
