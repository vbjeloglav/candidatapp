using System;
using System.Collections.Generic;

namespace CandidatApp.DB;

public partial class Position
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	public DateOnly? DatePosted { get; set; }

	public byte? NumberOfOpenPositions { get; set; }

	public byte? StatusId { get; set; }

	public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

	public virtual PositionStatus? Status { get; set; }
}
