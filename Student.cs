using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class Student : Person
{
    public Guid StudentId { get; set; }
    public Course[] EnrolledCourses { get; set; } = [];

}
