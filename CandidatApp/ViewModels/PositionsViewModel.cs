using CandidatApp.Models.Positions;
using System.Collections.ObjectModel;

namespace CandidatApp.ViewModels
{
    public class PositionsViewModel
    {

        private readonly IPositionService _positionService;

        public ObservableCollection<PositionListModel> Positions { get; } = new();

        public PositionsViewModel(IPositionService positionService)
        {
            _positionService = positionService;
            LoadPositions();
        }

        private async void LoadPositions()
        {
            var items = await _positionService.GetPositionsAsync();
            Positions.Clear();
            foreach (var p in items)
                Positions.Add(p);
        }
    }
}
