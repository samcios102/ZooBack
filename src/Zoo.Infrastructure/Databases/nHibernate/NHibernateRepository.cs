using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Linq;

namespace Zoo.Infrastructure.Databases.nHibernate
{
    internal sealed class NHibernateRepository<TEntity> : IRepository<TEntity> where TEntity : DbModel
    {
        private readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        public Task<TEntity> GetAsync(Guid id)
            => _session.GetAsync<TEntity>(id);

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
            => await _session.Query<TEntity>().Where(predicate).ToListAsync();

        public Task AddAsync(TEntity entity)
            => PersistAsync(() => _session.SaveAsync(entity));

        public Task UpdateAsync(TEntity entity)
            => PersistAsync(() => _session.MergeAsync(entity));

        public Task DeleteAsync(TEntity entity)
        {
            _session.Clear();
            return PersistAsync(() => _session.DeleteAsync(entity));
        }

        private async Task PersistAsync(Func<Task> persist)
        {
            using (var transaction = _session.BeginTransaction())
            {
                await persist();
                await transaction.CommitAsync();
            }
        }
        
    }
}