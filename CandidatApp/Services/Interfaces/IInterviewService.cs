using CandidatApp.Models.Interviews;

namespace CandidatApp.Services.Interfaces
{
    public interface IInterviewService
    {
        Task<List<InterviewListModel>> GetInterviewsAsync();
    }
}
