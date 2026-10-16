using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Managers;

public class PersonnelManager<T> where T : AdminPersonel, new()
{
    private readonly List<T> _personnel;
    private readonly List<Course> _courses;
    private readonly IDatabase<T> _database;
    private readonly IPersonnelFactory<T> _personnelFactory;

    public PersonnelManager(
        List<T> personnel,
        List<Course> courses,
        IDatabase<T> database,
        IPersonnelFactory<T> personnelFactory)
    {
        _personnel = personnel;
        _courses = courses;
        _database = database;
        _personnelFactory = personnelFactory;
    }

    public void AddNewPersonnel(string fileName, string position)
    {
        var teacher = Helper.PromptForPersonell(position, _courses);
        var dateOfEmployment = Helper.PromptUserForDateInput("Enter the startdate of the employment: ");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Press any key to generate a Id for the new {position}");
        Console.ReadKey();

        T newPerson = _personnelFactory.Create(teacher, dateOfEmployment);
        Console.WriteLine($" Id created: {newPerson.TeacherId}. Press any key to add {newPerson.FirstName} {newPerson.LastName} into the database...");
        Console.ReadKey();

        Console.Clear();
        Helper.SimulateInsertToDb(newPerson.FirstName, newPerson.LastName);

        _personnel.Add(newPerson);
        _database.Write(fileName, _personnel);

        Menu.ReturnToMenu();
    }
}
