

using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class Course
{
    public Guid CourseId { get; set; }
    public required string Title { get; set; }
    public int CourseLength { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


}
