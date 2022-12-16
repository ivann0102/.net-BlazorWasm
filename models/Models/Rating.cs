using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StudentRatingAsm.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public DateTime Date { get; set; }

    public int Grade { get; set; }
    [AllowNull]
    public virtual Course Course { get; set; }
    [AllowNull]
    public virtual Student Student { get; set; }
}
