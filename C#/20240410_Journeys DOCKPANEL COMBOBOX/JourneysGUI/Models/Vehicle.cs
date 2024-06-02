using System;
using System.Collections.Generic;

namespace JourneysGUI.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Journey> Journeys { get; set; } = new List<Journey>();

    public int JourneyCount 
    { 
        get
        {
            return Journeys.Count;
        }
    }
}
