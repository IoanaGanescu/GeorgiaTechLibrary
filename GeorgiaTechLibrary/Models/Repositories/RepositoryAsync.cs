﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GeorgiaTechLibraryAPI.Models.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public RepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public Task AddAsync(T entity)
        {
            return AddAsync(entity, new CancellationToken());
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddAsync(entity, cancellationToken);

        public Task AddAsync(params T[] entities) => _dbSet.AddRangeAsync(entities);


        public Task AddAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default(CancellationToken)) =>
            _dbSet.AddRangeAsync(entities, cancellationToken);


        public async Task DeleteAsync(T entity)
        {
            var existing = _dbSet.Find(entity);
            if (existing != null) _dbSet.Remove(existing);
        }

        public async Task DeleteAsync(object id)
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<T>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null) DeleteAsync(entity);
            }
        }

        public async Task DeleteAsync(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task DeleteAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }


        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task UpdateAsync(params T[] entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsEnumerable();

        public async Task<IEnumerable<T>> GetAsync() => _dbSet.AsEnumerable();

    }
}
