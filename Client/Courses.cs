using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WestCoastEducation;

public class Course
{
    public string? CourseId { get; set; }
    public string? Title { get; set; }
    public int CourseLength { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
