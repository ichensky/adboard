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

namespace Application.Ads.GetAd
{
    public class GetAdQueryHandler : IQueryHandler<GetAdQuery, GetAdDto?>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<GetAdDto?> Handle(GetAdQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[Id], " +
                              "[Name], " +
                              "[PublishDate], " +
                              "[PublishStatus] " +
                              "FROM [dbo].[Ads] " +
                              "WHERE [Id] = @Id " +
                              "and [DeleteDate] is NULL ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleOrDefaultAsync<GetAdDto?>(sql, new
            {
                request.Id,
            });
        }
    }
}
