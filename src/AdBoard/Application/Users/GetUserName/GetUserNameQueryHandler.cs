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
    public class GetUserNameQueryHandler : IQueryHandler<GetUserNameQuery, UserNameDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserNameQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<UserNameDto> Handle(GetUserNameQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                              "[User].[Id], " +
                              "[User].[FirstName], " +
                              "[User].[SecondName], " +
                              "FROM users.v_Users AS [User] " +
                              "WHERE [User].[Id] = @UserId ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleAsync<UserNameDto>(sql, new
            {
                request.UserId
            });
        }
    }
}
