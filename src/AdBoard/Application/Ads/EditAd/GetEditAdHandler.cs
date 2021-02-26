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

namespace Application.Ads.EditAd
{
    public class GetEditAdHandler : IQueryHandler<GetEditAdQuery, EditAdDto?>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEditAdHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<EditAdDto?> Handle(GetEditAdQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[Id], " +
                              "[Name], " +
                              "[Description], " +
                              "[ShortDescription], " +
                              "[Keywords], " +
                              "[YoutubeUrl], " +
                              "[PublishDate], " +
                              "[PublishStatus] " +
                              "FROM [dbo].[Ads] " +
                              "WHERE [Id] = @id " +
                              "AND [UserProfilesId] = @userId " +
                              "AND [DeleteDate] is NULL ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleOrDefaultAsync<EditAdDto?>(sql, new
            {
                id = request.Id,
                userId= request.UserId
            });
        }
    }
}
