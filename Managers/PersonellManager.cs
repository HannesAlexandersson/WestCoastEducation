using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class PersonnelManager<T> where T : AdminPersonel, new() // T must inherit from AdminPersonel and have a public parameterless constructor.
{
    private readonly List<T> _personnel;

    public PersonnelManager(List<T> personnel)
    {
        _personnel = personnel;
    }

    // since pretty much all these methods does the same thing exept for names and small details i tried to make a genereic method to handle all adminpersonell
    public void AddNewPersonnel(string fileName, string position)
    {
        var newTeacher = Helper.PromptForPersonell(position);
        var dateOfEmployment = Helper.PromptUserForDateInput("Enter the startdate of the employment: ");

        // map all shared propertys & add in the specific from handler class
        T newPerson = new()
        {
            FirstName = newTeacher.FirstName,
            LastName = newTeacher.LastName,
            Email = newTeacher.Email,
            PhoneNumber = newTeacher.PhoneNumber,
            Addresses = newTeacher.Addresses,
            SubjectFields = newTeacher.SubjectFields,
            TeachingCourses = newTeacher.TeachingCourses,
            DateOfEmployment = dateOfEmployment
        };

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Press any key to generate a Id for the new {position}");
        Console.ReadKey();

        newPerson.TeacherId = Helper.GenerateGuid();

        Console.WriteLine($" Id created: {newPerson.TeacherId}. Press any key to add {newPerson.FirstName} {newPerson.LastName} into the database...");
        Console.ReadKey();

        Console.Clear();
        Helper.SimulateInsertToDb(newPerson.FirstName, newPerson.LastName);

        _personnel.Add(newPerson);
        DatabaseHandler.SaveList(fileName, _personnel);

        Menu.ReturnToMenu();
    }
}
