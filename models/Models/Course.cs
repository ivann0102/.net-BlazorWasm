using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StudentRatingAsm.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TeacherId { get; set; }

    public short? MaxGrade { get; set; }

    [AllowNull]
    public virtual Teacher Teacher { get; set; }
}
