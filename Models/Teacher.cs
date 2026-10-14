namespace WestCoastEducation;

public class Teacher : Person
{
    public FieldOfKnowledge[] SubjectFields { get; set; } = []; // composition, the Subjectfields/FieldOfKnowledge doesnt exist anywhere without there first is a Teacher instance created
    public Course[] TeachingCourses { get; set; } = []; // aggregation, the courses exist without a teacher object
    public Guid TeacherId { get; set; }
}
