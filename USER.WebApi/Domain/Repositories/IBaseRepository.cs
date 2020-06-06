using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool Create(TEntity entity);
        bool Delete(Guid id);
    }
}
