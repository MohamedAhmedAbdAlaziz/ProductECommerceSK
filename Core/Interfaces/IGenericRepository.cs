using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
    Task<T> GetByIdAsync(int id) ;     
    Task<IReadOnlyList<T>> GetAllAsync() ;
    Task<T> GetEntityWithSpec(ISpecifications<T> spec);     
    Task <IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);     
    }
}

