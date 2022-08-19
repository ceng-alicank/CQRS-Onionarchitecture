using Application.Services.Repositories.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories.Generic
{
    public class BaseRepository<TEntity> :IQueryRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
             _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity= await _context.Set<TEntity>().Where(p => p.Id == id).FirstOrDefaultAsync();
            if (entity !=null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await _context.Set<TEntity>().Where(p => p.Id == id).FirstOrDefaultAsync();
            if (entity!=null)
            {
                return entity;
            }
            return null;
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null) await _context.Set<TEntity>().Where(filter).ToListAsync();
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
             TEntity? existing = await _context.Set<TEntity>().FindAsync(entity.Id);
             if (existing !=null)
              {
                  
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
              }
        }
    }
}
