using Microsoft.EntityFrameworkCore;
using PartsAPI.Core.Entities;

namespace PartsAPI.Infrastructure.Data
{
    public class PartContext : DbContext
    {
        public PartContext(DbContextOptions<PartContext> options) : base(options)
        {

        }

        public DbSet<Part> Parts { get; set; }
    }
}
