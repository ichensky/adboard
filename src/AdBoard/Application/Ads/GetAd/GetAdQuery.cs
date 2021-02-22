using Application.Configuration.Queries;
using Application.Users.GetUserName;
using System;
using System.Collections.Generic;

namespace Application.Ads.GetAd
{
    public class GetAdQuery : IQuery<GetAdDto?>
    {
        public GetAdQuery( Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
