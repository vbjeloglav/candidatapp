using System;
using System.Collections.Generic;

namespace CandidatApp.DB;

public partial class Candidate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }
	public string Role { get; set; }

	public short? ExpirienceMonths { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
