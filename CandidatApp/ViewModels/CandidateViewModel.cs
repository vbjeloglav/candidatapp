using CandidatApp.DB;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CandidatApp.ViewModels
{
	public class CandidateViewModel
	{
		public ObservableCollection<Candidate> Candidates { get; set; }

		public CandidateViewModel()
		{
			using (var db = new CandidatappContext())
			{
				Candidates = new ObservableCollection<Candidate>(db.Candidates.ToList());
			}
		}
	}
}