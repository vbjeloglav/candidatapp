using CandidatApp.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatApp.ViewModels
{
	public class InterviewViewModel
	{
		public ObservableCollection<InterviewModel> Interviews { get; set; }

		public InterviewViewModel()
		{
			using (var db = new CandidatappContext())
			{
				Interviews = new ObservableCollection<InterviewModel>(db.Interviews.Select(x => new InterviewModel
				{
					StartTime = DateTime.Now,
					CandidateId = x.CandidateId,
					CandidateName = x.Candidate.Name +  " " + x.Candidate.Surname,
					Phone = x.Candidate.Phone,
					Email = x.Candidate.Email,
					ApplicationId = x.ApplicationId,
					ApplicationName = x.Application.Position.Name,
					AppliedAt = x.Application.AppliedAt,
					Source = x.Application.Source
				}).ToList());
			}
		}
	}

	public class InterviewModel
	{
		public DateTime? StartTime { get; set; }

		public int CandidateId { get; set; }
		public string CandidateName { get; set; }
		public string? Phone { get; set; }
		public string Email { get; set; }
		public string? Note { get; set; }
		public string? Source { get; set; }
		public int ApplicationId { get; set; }
		public string ApplicationName { get; set; }
		public string PositionName { get; set; }
		public DateTime AppliedAt { get; set; }
	}
}