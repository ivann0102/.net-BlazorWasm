using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRatingAsm.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string ByFather { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string? Phone { get; set; }
    public string FullName
    {
        get 
        {
            var res = new StringBuilder();
            res.Append(Name);
            res.Append(' ');
            res.Append(Surname);
            return res.ToString();
        }
    }
}
