using Application.Configuration.Queries;
using Application.Users.GetUserName;
using System;
using System.Collections.Generic;

namespace Application.Ads.EditAd
{
    public class GetEditAdQuery : IQuery<EditAdDto?>
    {
        public GetEditAdQuery(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public Guid Id { get; }

        public Guid UserId { get; }
    }
}
