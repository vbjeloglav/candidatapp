using CandidatApp.DB;
using CandidatApp.Models.Interviews;
using CandidatApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidatApp.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly CandidatappContext _db;

        public InterviewService(CandidatappContext db)
        {
            _db = db;
        }

        public async Task<List<InterviewListModel>> GetInterviewsAsync()
        {
            return await _db.Interviews
                .Include(x => x.Candidate)
                .Include(x => x.Application)
                    .ThenInclude(a => a.Position)
                .Select(x => new InterviewListModel
                {
                    StartTime = x.StartTime,
                    CandidateId = x.CandidateId,
                    CandidateName = x.Candidate.Name + " " + x.Candidate.Surname,
                    Phone = x.Candidate.Phone,
                    Email = x.Candidate.Email,
                    ApplicationId = x.ApplicationId,
                    ApplicationName = x.Application.Position.Name,
                    AppliedAt = x.Application.AppliedAt,
                    Source = x.Application.Source
                })
                .ToListAsync();
        }
    }

}
