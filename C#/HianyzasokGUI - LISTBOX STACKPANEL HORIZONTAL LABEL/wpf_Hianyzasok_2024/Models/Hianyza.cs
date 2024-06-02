using System;
using System.Collections.Generic;

namespace wpf_Hianyzasok_2024.Models;

public partial class Hianyza
{
    public string Nev { get; set; } = null!;

    public string Osztaly { get; set; } = null!;

    public int ElsoNap { get; set; }

    public int UtolsoNap { get; set; }

    public int MulasztottOrak { get; set; }

    public int Id { get; set; }
}
