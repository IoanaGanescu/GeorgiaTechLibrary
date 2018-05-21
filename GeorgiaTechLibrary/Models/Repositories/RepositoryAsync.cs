﻿using GeorgiaTechLibrary.Models.Members;
using Microsoft.EntityFrameworkCore;
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
            AddAsync(entity, new CancellationToken());
            return _dbContext.SaveChangesAsync();

        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken)) {
            _dbContext.Entry(new LoanRule(1, 5, 7, 21)).State = EntityState.Unchanged; // hard coded --- to be remove from here
            _dbSet.AddAsync(entity, cancellationToken);
            return _dbContext.SaveChangesAsync();
        }

        public Task AddAsync(params T[] entities) { _dbSet.AddRangeAsync(entities);
            _dbContext.Entry(new LoanRule(1, 5, 7, 21)).State = EntityState.Unchanged; // hard coded --- to be remove from here
            return _dbContext.SaveChangesAsync();
        }


        public Task AddAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbSet.AddRangeAsync(entities, cancellationToken);
            return _dbContext.SaveChangesAsync();
        }



        public async Task DeleteAsync(T entity)
        {
            var existing = await _dbSet.FindAsync(entity);
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
                var entity = await _dbSet.FindAsync(id);
                if (entity != null) DeleteAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(params T[] entities)
        {
            _dbSet.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsEnumerable();

        public async Task<IEnumerable<T>> GetAsync() => _dbSet.AsEnumerable();

    }
}