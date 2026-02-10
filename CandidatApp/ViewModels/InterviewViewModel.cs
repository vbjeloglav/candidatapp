using CandidatApp.Models.Interviews;
using CandidatApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace CandidatApp.ViewModels
{
	public class InterviewViewModel
    {
        private readonly IInterviewService _interviewService;

        public ObservableCollection<InterviewListModel> Interviews { get; } = new();

        public InterviewViewModel(IInterviewService interviewService)
        {
            _interviewService = interviewService;
            Load();
        }

        private async void Load()
        {
            var items = await _interviewService.GetInterviewsAsync();

            Interviews.Clear();

            foreach (var item in items)
                Interviews.Add(item);
        }
    }
}