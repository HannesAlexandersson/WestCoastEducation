using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Classes;

namespace WestCoastEducation.Managers;

public class PersonnelManager<T> where T : AdminPersonel, new() // T must inherit from AdminPersonel and have a public parameterless constructor.
{
    private readonly ApplicationData _data;
    private readonly List<T> _personnel;

    public PersonnelManager(List<T> personnel, ApplicationData data)
    {
        _personnel = personnel;
        _data = data;

    }

    // since pretty much all these methods does the same thing exept for names and small details i tried to make a genereic method to handle all adminpersonell
    public AdminPersonel AddNewPersonnel(string position)
    {
        var newTeacher = Helper.PromptForPersonell(position, _data.Courses);
        var dateOfEmployment = Helper.PromptUserForDateInput("Enter the startdate of the employment: ");
        var officeLocation = Helper.PromptForOfficeLocation();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Press any key to generate a Id for the new {position}");
        Console.ReadKey();
        newTeacher.TeacherId = Helper.GenerateGuid();

        Console.WriteLine($" Id created: {newTeacher.TeacherId}. Press any key to confirm the creation of {newTeacher.FirstName} {newTeacher.LastName} ...");
        Console.ReadKey();

        Console.Clear();
        Helper.SimulateInsertToDb(newTeacher.FirstName, newTeacher.LastName);

        return new AdminPersonel
        {
            FirstName = newTeacher.FirstName,
            LastName = newTeacher.LastName,
            Email = newTeacher.Email,
            PhoneNumber = newTeacher.PhoneNumber,
            Addresses = newTeacher.Addresses,
            TeachingCourses = newTeacher.TeachingCourses,
            SubjectFields = newTeacher.SubjectFields,
            TeacherId = newTeacher.TeacherId,
            DateOfEmployment = dateOfEmployment,
            OfficeLocation = officeLocation
        };
    }
}
