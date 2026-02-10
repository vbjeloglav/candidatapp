
using CandidatApp.DB;
using CandidatApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidatApp.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CandidatappContext _db;

        public CandidateService(CandidatappContext db)
        {
            _db = db;
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            return await _db.Candidates.ToListAsync();
        }
    }

}
