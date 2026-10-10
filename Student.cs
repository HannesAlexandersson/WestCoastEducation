using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class Student : Person
{
    public Guid StudentId { get; set; }
    public Course[] EnrolledCourses { get; set; } = [];


    public static List<Student> ListAllEnrolled()
    {
        var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        var studentsEnrolled = db.Read(path);

        return studentsEnrolled;
    }

    public static void AddNewStudentToDb(List<Student> studentList)
    {
        var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        db.Write(path, studentList);
    }

}
