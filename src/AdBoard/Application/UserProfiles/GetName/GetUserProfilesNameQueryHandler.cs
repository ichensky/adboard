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

namespace Application.UserProfiles.GetName
{
    public class GetUserProfilesNameQueryHandler : IQueryHandler<GetUserProfilesNameQuery, UserProfilesNameDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserProfilesNameQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<UserProfilesNameDto> Handle(GetUserProfilesNameQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[Id], " +
                              "[FirstName], " +
                              "[LastName] " +
                              "FROM dbo.UserProfiles " +
                              "WHERE [Id] = @UserId ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleAsync<UserProfilesNameDto>(sql, new
            {
                request.UserId
            });
        }
    }
}
