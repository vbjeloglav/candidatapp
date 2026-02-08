using System;
using System.Collections.Generic;

namespace CandidatApp.DB;

public partial class PositionStatus
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
