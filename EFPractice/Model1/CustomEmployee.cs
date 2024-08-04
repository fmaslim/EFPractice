using System;
using System.Collections.Generic;

namespace EFPractice.Model1;

public partial class CustomEmployee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
