using CandidatApp.DB;
using CandidatApp.Models.Positions;
using Microsoft.EntityFrameworkCore;
namespace CandidatApp.Services
{
    internal class PositionService : IPositionService
    {
        private readonly CandidatappContext _db;

        public PositionService(CandidatappContext db)
        {
            _db = db;
        }

        public async Task<List<PositionListModel>> GetPositionsAsync()
        {
            return await _db.Positions
                .Include(p => p.Status)
                .Include(p => p.Applications)
                .Select(x => new PositionListModel
                {
                    Name = x.Name,
                    DatePosted = x.DatePosted,
                    Status = x.Status.Name,
                    NumberOfApplications = x.Applications.Count
                })
                .ToListAsync();
        }
    }
}
