using System;
using System.Collections.Generic;

namespace CandidatApp.DB;

public partial class Interview
{
    public int Id { get; set; }

    public DateTime? StartTime { get; set; }

    public int CandidateId { get; set; }

    public string? Note { get; set; }

    public int ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual Candidate Candidate { get; set; } = null!;
}
