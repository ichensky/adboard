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

namespace Application.Ads.ListMyAds
{
    public class ListMyAdsQueryHandler : IQueryHandler<ListMyAdsQuery, IEnumerable<MyAdDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ListMyAdsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<IEnumerable<MyAdDto>> Handle(ListMyAdsQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[Id], " +
                              "[Name], " +
                              "[PublishDate], " +
                              "[PublishStatus] " +
                              "FROM [dbo].[Ads] " +
                              "WHERE [UserProfilesId] = @UserId " +
                              "and [DeleteDate] is NULL ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QueryAsync<MyAdDto>(sql, new
            {
                request.UserId
            });
        }
    }
}
