using ProjectMap.WebApi.Models;

namespace ProjectMap.WebApi.Repositories
{
    public interface IEnvironment2DRepository
    {
        Task DeleteAsync(Guid id);
        Task<Environment2D> InsertAsync(Environment2D environment2D);
        Task<IEnumerable<Environment2D>> ReadAsync();
        Task<Environment2D?> ReadAsync(Guid id);
        Task UpdateAsync(Environment2D environment);
    }
}