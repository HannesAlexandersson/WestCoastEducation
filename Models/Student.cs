using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class Student : Person
{
    public Guid StudentId { get; set; }
    public Course[] EnrolledCourses { get; set; } = []; // Aggregation, the courses exists independently from the Students or better said: i dont need to createan student instance to create anew course

}
