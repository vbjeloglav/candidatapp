
using CandidatApp.DB;
using CandidatApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidatApp.Services
{
	public class CandidateService : ICandidateService
	{
		private readonly IDbContextFactory<CandidatappContext> _contextFactory;

		public CandidateService(IDbContextFactory<CandidatappContext> contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<List<Candidate>> GetCandidatesAsync()
		{
			using var context = _contextFactory.CreateDbContext();

			return await context.Candidates.ToListAsync();
		}
	}

}
