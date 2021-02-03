using Application.Configuration.Data;
using Application.Configuration.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.GetUserName
{
    public class GetAdUserNameQueryHandler : IQueryHandler<GetAdUserNameQuery, AdUserNameDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAdUserNameQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<AdUserNameDto> Handle(GetAdUserNameQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[User].[Id], " +
                              "[User].[FirstName], " +
                              "[User].[SecondName], " +
                              "FROM users.v_Users AS [User] " +
                              "WHERE [User].[Id] = @UserId ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleAsync<AdUserNameDto>(sql, new
            {
                request.UserId
            });
        }
    }
}
