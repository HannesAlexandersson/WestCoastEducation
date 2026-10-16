namespace WestCoastEducation.Factories;

public class PersonnelFactory<T> : IPersonnelFactory<T>
    where T : AdminPersonel, new()
{
    public T Create(Teacher teacher, DateTime dateOfEmployment)
    {
        return new T
        {
            TeacherId = Guid.NewGuid(),
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            PhoneNumber = teacher.PhoneNumber,
            Addresses = teacher.Addresses,
            SubjectFields = teacher.SubjectFields,
            TeachingCourses = teacher.TeachingCourses,
            DateOfEmployment = dateOfEmployment
        };
    }
}
