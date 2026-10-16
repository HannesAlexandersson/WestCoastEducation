namespace WestCoastEducation.Factories;

public class StudentFactory : IStudentFactory
{
    public Student Create(Person person)
    {
        return new Student
        {
            StudentId = Guid.NewGuid(),
            FirstName = person.FirstName,
            LastName = person.LastName,
            PhoneNumber = person.PhoneNumber,
            Email = person.Email,
            Addresses = person.Addresses
        };
    }
}
