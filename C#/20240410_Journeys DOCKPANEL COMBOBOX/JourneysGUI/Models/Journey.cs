using System;
using System.Collections.Generic;

namespace JourneysGUI.Models;

public partial class Journey
{
    public int Id { get; set; }

    public int Vehicle { get; set; }

    public string Country { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly Departure { get; set; }

    public int? Capacity { get; set; }

    public virtual Vehicle VehicleNavigation { get; set; } = null!;
}
