using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(Guid id);
    }
}
