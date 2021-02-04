using Application.Configuration.Data;
using Application.Configuration.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserProfiles.GetUserProfile
{
    public class GetUserProfileQueryHandler : IQueryHandler<GetUserProfileQuery, UserProfileDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserProfileQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
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

            return connection.QuerySingleAsync<UserProfileDto>(sql, new
            {
                request.UserId
            });
        }
    }
}
