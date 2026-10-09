namespace WestCoastEducation.Client;

public class Teacher : Person
{
    public string? Subject { get; set; }
    public Course[] TeachingCourses { get; set; } = [];
}
