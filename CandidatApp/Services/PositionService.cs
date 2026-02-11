using CandidatApp.DB;
using CandidatApp.Models.Positions;
using Microsoft.EntityFrameworkCore;
namespace CandidatApp.Services
{
	internal class PositionService : IPositionService
	{
		private readonly IDbContextFactory<CandidatappContext> _contextFactory;

		public PositionService(IDbContextFactory<CandidatappContext> contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public async Task<List<PositionListModel>> GetPositionsAsync()
		{
			using var context = _contextFactory.CreateDbContext();

			return await context.Positions
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
