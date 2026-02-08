using System;
using System.Collections.Generic;

namespace CandidatApp.DB;

public partial class ApplicationStatus
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
