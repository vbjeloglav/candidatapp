using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatApp.Models.Interviews
{
    public class InterviewListModel
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
