using ProjectMap.WebApi.Models;

namespace ProjectMap.WebApi.Repositories
{
    public interface IObject2DRepository
    {
        Task DeleteAsync(Guid id);
        Task<Object2D> InsertAsync(Object2D object2D);
        Task<IEnumerable<Object2D>> ReadAsync();
        Task<Object2D?> ReadAsync(Guid id);
        Task UpdateAsync(Object2D environment);
    }
}