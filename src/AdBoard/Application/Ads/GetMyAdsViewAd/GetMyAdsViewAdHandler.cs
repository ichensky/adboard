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

namespace Application.Ads.GetMyAdsViewAd
{
    public class GetMyAdsViewAdHandler : IQueryHandler<GetMyAdsViewAdQuery, GetMyAdsViewAdDto?>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetMyAdsViewAdHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<GetMyAdsViewAdDto?> Handle(GetMyAdsViewAdQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[Id], " +
                              "[Name], " +
                              "[PublishDate], " +
                              "[PublishStatus] " +
                              "FROM [dbo].[Ads] " +
                              "WHERE [Id] = @id " +
                              "AND [UserProfilesId] = @userId " +
                              "AND [DeleteDate] is NULL ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleOrDefaultAsync<GetMyAdsViewAdDto?>(sql, new
            {
                id = request.Id,
                userId= request.UserId
            });
        }
    }
}
