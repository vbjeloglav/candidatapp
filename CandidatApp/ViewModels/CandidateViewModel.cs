using CandidatApp.DB;
using CandidatApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace CandidatApp.ViewModels
{
    public class CandidateViewModel
    {
        private readonly ICandidateService _candidateService;

        public ObservableCollection<Candidate> Candidates { get; } = new();

        public CandidateViewModel(ICandidateService candidateService)
        {
            _candidateService = candidateService;
            LoadCandidates();
        }

        private async void LoadCandidates()
        {
            var items = await _candidateService.GetCandidatesAsync();

            Candidates.Clear();

            foreach (var c in items)
                Candidates.Add(c);
        }
    }
}