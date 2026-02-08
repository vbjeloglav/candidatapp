using CandidatApp.DB;
using System.Collections.ObjectModel;

namespace CandidatApp.ViewModels
{
	public class PositionsViewModel
	{
		public ObservableCollection<PositionModel> Positions { get; set; }

		public PositionsViewModel()
		{
			using (var db = new CandidatappContext())
			{
				Positions = new ObservableCollection<PositionModel>
					(db.Positions.Select(x =>
					new PositionModel
					{
						Name = x.Name,
						DatePosted = x.DatePosted,
						Status = x.Status.Name,
						NumberOfApplications = x.Applications.Count
					}).ToList());
			}
		}
	}

	public class PositionModel
	{
		public string Name { get; set; }
		public DateOnly? DatePosted { get; set; }
		public string Status { get; set; }
		public int NumberOfApplications { get; set; }
	}
}
