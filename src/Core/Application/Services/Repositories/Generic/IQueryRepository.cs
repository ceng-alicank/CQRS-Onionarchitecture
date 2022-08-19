using Domain;
using System.Linq.Expressions;

namespace Application.Services.Repositories.Generic
{
    public interface IQueryRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetById(Guid id);
        Task Update(TEntity entity);
        Task Add(TEntity entity);
        Task Delete(Guid id);
    }
}
