using System;
using System.Collections.Generic;

namespace StudentRatingAsm.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string ByFather { get; set; } = null!;
    public string FullName
    {
        get
        {
            return Name + " " + Surname;
        }
    }

}
