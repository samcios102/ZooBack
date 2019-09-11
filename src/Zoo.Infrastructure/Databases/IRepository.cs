using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Zoo.Infrastructure.Databases
{
    internal interface IRepository<TDbModel> where TDbModel : DbModel
    {
        Task<TDbModel> GetAsync(Guid id);
        Task<IEnumerable<TDbModel>> SearchAsync(Expression<Func<TDbModel, bool>> predicate);
        Task AddAsync(TDbModel entity);
        Task DeleteAsync(TDbModel entity);
    }
}