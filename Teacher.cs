namespace WestCoastEducation;

public class Teacher : Person
{
    public FieldOfKnowledge[] SubjectFields { get; set; } = [];
    public Course[] TeachingCourses { get; set; } = [];
    public Guid TeacherId { get; set; }
}
