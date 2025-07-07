using PartsAPI.Core.Entities;

namespace PartsAPI.Core.Interfaces
{
    public interface IPartRepository
    {
        Task<ICollection<Part>> GetAllAsync();
        Task<Part> GetByIdAsync(string id);
        Task<bool> CreateAsync(Part part);
        Task<bool> UpdateAsync(Part part);
        Task<bool> DeleteAsync(string partNumber);
        Task<bool> Exists(string partNumber);

    }
}
