using CandidatApp.DB;

namespace CandidatApp.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetCandidatesAsync();
    }
}
