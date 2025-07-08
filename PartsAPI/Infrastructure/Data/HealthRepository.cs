using PartsAPI.Core.Interfaces;

namespace PartsAPI.Infrastructure.Data
{
    public class HealthRepository : IHealthRepository
    {
        private readonly PartContext _context;
        public HealthRepository(PartContext context)
        {
            _context = context;
        }

        public async Task<bool> CanConnectToDatabaseAsync()
        {
            var canConnect = await _context.Database.CanConnectAsync();
            return canConnect;
        }
    }
}
