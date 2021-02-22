using Application.Configuration.Queries;
using Application.Users.GetUserName;
using System;
using System.Collections.Generic;

namespace Application.Ads.ListMyAds
{
    public class ListMyAdsQuery : IQuery<IEnumerable<MyAdDto>>
    {
        public ListMyAdsQuery(Guid userId)
        {
            UserId = userId;
        }


        public Guid UserId { get; }
    }
}
