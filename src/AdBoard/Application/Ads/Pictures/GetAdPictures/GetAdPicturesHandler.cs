using Application.Configuration.Data;
using Application.Configuration.Queries;
using Application.Users.GetUserName;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Ads.Pictures.GetAdPictures
{
    public class GetAdPicturesHandler : IQueryHandler<GetAdPicturesQuery, IEnumerable<AdPictureDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAdPicturesHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<IEnumerable<AdPictureDto>> Handle(GetAdPicturesQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "p.[Id], " +
                              "p.[GoogleId], " +
                              "p.[Description], " +
                              "p.[OrderId], " +
                              "FROM [dbo].[Pictures] as p" +
                              "INNER JOIN [dbo].[Ads] as a on a.[Id] = p.[AdsId] " +
                              "WHERE a.[Id] = @id " +
                              "AND [UserProfilesId] = @userId " +
                              "AND [DeleteDate] is NULL ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QueryAsync<AdPictureDto>(sql, new
            {
                id = request.AdId,
                userId= request.UserId
            });
        }
    }
}
