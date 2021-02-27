using Application.Configuration.Queries;
using Application.Users.GetUserName;
using System;
using System.Collections.Generic;

namespace Application.Ads.Pictures.GetAdPictures
{
    public class GetAdPicturesQuery : IQuery<IEnumerable<AdPictureDto>>
    {
        public GetAdPicturesQuery(Guid adId, Guid userId)
        {
            AdId = adId;
            UserId = userId;
        }

        public Guid AdId { get; }

        public Guid UserId { get; }
    }
}
