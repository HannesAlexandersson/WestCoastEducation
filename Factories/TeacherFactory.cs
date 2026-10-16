namespace WestCoastEducation.Factories;

public class TeacherFactory : ITeacherFactory
{
    public Teacher Create(Teacher teacher)
    {
        return new Teacher
        {
            TeacherId = Guid.NewGuid(),
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            PhoneNumber = teacher.PhoneNumber,
            Addresses = teacher.Addresses,
            SubjectFields = teacher.SubjectFields,
            TeachingCourses = teacher.TeachingCourses
        };
    }
}
