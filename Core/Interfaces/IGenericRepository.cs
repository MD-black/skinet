using Core.Entities;
using Core.Spacefications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpacefication<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpacefication<T> spec);
    }
}
