using Application.Configuration.Data;
using Application.Configuration.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserProfiles.TryGetUserProfile
{
    public class TryGetUserProfileQueryHandler : IQueryHandler<TryGetUserProfileQuery, UserProfileDto?>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public TryGetUserProfileQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<UserProfileDto?> Handle(TryGetUserProfileQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[Id], " +
                              "[FirstName], " +
                              "[LastName], " +
                              "[Picture], " + 
                              "[Telegram], " +
                              "[Instagram], " +
                              "[PhoneNumber] " +
                              "FROM dbo.UserProfiles " +
                              "WHERE [Id] = @UserId ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return await connection.QuerySingleOrDefaultAsync<UserProfileDto>(sql, new
            {
                request.UserId
            });
        }
    }
}
