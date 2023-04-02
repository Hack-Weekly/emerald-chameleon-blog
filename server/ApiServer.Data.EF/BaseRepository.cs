using ApiServer.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Data.EF
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
            where TEntity : class, IEntity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken token, bool save = true)
        {
            GenerateIdIfRequired(entity);
            await _context.Set<TEntity>().AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token, bool save = true)
        {
            var entry = _context.Attach(entity);
            entry.State = EntityState.Modified;
            if (save)
            {
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        private void GenerateIdIfRequired(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
        }

        public async Task DeleteAsync(Guid id, CancellationToken token, bool save = true)
        {
            var existingRecord = await GetAsync(id, token);
            if (existingRecord is not null)
            {
                _context.Remove(existingRecord);
                await _context.SaveChangesAsync(token);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken token)
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity?> GetAsync(Guid id, CancellationToken token)
        {
            return await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: token);
        }

        public async Task<int> SaveAsync(CancellationToken token)
        {
            return await _context.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken token, bool save = true)
        {
            var existingRecord = await GetAsync(entity.Id, token);
            if (existingRecord is not null)
            {
                _context.Remove(existingRecord);
                await _context.SaveChangesAsync(token);
            }

        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Get(Guid id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id);
        }
    }
}
