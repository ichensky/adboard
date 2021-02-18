using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IBaseRepository<T>
    {
        public T Add(T model);

        public Task<T> GetAsync(TypedIdValueObject id);

        public Task<T?> TryGetAsync(TypedIdValueObject id);

        public T Update(T model);

        public void Delete(T model);
    }
}
