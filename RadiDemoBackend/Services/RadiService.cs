using Microsoft.EntityFrameworkCore;
using RadiDemoBackend.Configuration;
using RadiDemoBackend.Models;
using RadiDemoBackend.Responses;

namespace RadiDemoBackend.Services
{
    public class RadiService : IRadiService
    {
        private readonly RadiDbContext _dbContext;

        private readonly List<string> _types = new() { "CT", "MR", "UH", "RTG" };

        public RadiService(RadiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DashboardResponse> GetDashBoard()
        {
            var responseDashboardResponse = new DashboardResponse
            {
                DashboardItems = await this._dbContext.Measurements
                    .Where(x => x.PayedAt == null)
                    .Select(x => new DashboardItem { Id = x.Id, Name = x.Name, PayedAt = x.PayedAt })
                    .ToListAsync()
            };

            return responseDashboardResponse;
        }

        public async Task Genarate()
        {
            Random random = new Random();
            var index = (int)random.NextInt64(_types.Count);
            var model = new Measurement
            {
                Created = DateTime.UtcNow,
                Name = _types[index]
            };

            await _dbContext.Measurements.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Pay(long id)
        {
            var entity = await _dbContext.Measurements.FindAsync(id);
            if(entity is not null) 
            {
                entity.PayedAt = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
