using System;
using System.Collections.Generic;

namespace EFPractice.Models;

public partial class CustomEmployee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
