using Domain.Core;
using Infrastucture.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastucture.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdBoardDbContext context;

        public UnitOfWork(AdBoardDbContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
