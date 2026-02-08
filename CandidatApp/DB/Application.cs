using System;
using System.Collections.Generic;

namespace CandidatApp.DB;

public partial class Application
{
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public int PositionId { get; set; }

    public DateTime AppliedAt { get; set; }

    public byte ApplicationStatusId { get; set; }

    public string? Note { get; set; }

    public string? Source { get; set; }

    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
