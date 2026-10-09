

using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class Course
{
    public string? CourseId { get; set; }
    public string? Title { get; set; }
    public int CourseLength { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public static List<Course> ListAllAvailableCourses()
    {
        var db = new DataBase<Course>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/courses.json");
        var studentsEnrolled = db.Read(path);

        return studentsEnrolled;
    }
}
