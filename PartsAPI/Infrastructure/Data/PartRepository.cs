using Microsoft.EntityFrameworkCore;
using PartsAPI.Core.Entities;
using PartsAPI.Core.Interfaces;

namespace PartsAPI.Infrastructure.Data
{
    public class PartRepository : IPartRepository
    {
        private readonly PartContext _context;
        public PartRepository(PartContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Part>> GetAllAsync()
        {
            return await _context.Parts.OrderBy(x => x.PartNumber).ToListAsync();
        }

        public async Task<Part> GetByIdAsync(string id)
        {
            return await _context.Parts.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Part part)
        {
            var studentCount = _context.Parts.ToList().Count;
            studentCount++;
            await _context.Parts.AddAsync(part);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(Part part)
        {
            _context.Entry(part).State = EntityState.Modified;
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(string partNumber)
        {
            var part = _context.Parts.Where(x => x.PartNumber == partNumber).FirstOrDefault();
            _context.Parts.Remove(part);
            return await SaveAsync();
        }

        public async Task<bool> Exists(string partNumber)
        {
            return await _context.Parts.AnyAsync(x => x.PartNumber == partNumber);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
