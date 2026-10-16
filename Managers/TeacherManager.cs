using System;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Managers;

public class TeacherManager
{
    private readonly List<Teacher> _teachers;
    private readonly List<Course> _courses;
    private readonly IDatabase<Teacher> _database;
    private readonly ITeacherFactory _teacherFactory;

    public TeacherManager(
        List<Teacher> teachers,
        List<Course> courses,
        IDatabase<Teacher> database,
        ITeacherFactory teacherFactory)
    {
        _teachers = teachers;
        _courses = courses;
        _database = database;
        _teacherFactory = teacherFactory;
    }

    public void AddNewTeacher()
    {
        Teacher teacher = Helper.PromptForPersonell("Teacher", _courses);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a TeacherId for the teacher");
        Console.ReadKey();
        Teacher newTeacher = _teacherFactory.Create(teacher);
        Console.WriteLine($" TeacherId created: {newTeacher.TeacherId}. Press any key to add {newTeacher.FirstName} {newTeacher.LastName} into the database...");
        Console.ReadKey();
        Thread.Sleep(550);
        Console.WriteLine("Please wait while the system adds the teacher to the database...");
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        // add the new teacher to the teachers list
        _teachers.Add(newTeacher);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        _database.Write("teachers.json", _teachers);
        Thread.Sleep(550);
        Console.WriteLine($"{newTeacher.FirstName} {newTeacher.LastName} added to the teacher rolls in the database!");
        Menu.ReturnToMenu();
    }
}
