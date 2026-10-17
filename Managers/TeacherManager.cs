using System;
using WestCoastEducation.Classes;
using WestCoastEducation.Menus;
using WestCoastEducation.Models;

namespace WestCoastEducation.Managers;

public class TeacherManager
{
    private readonly ApplicationData _data;

    public TeacherManager(ApplicationData data)
    {
        _data = data;
    }

    public void AddNewTeacher()
    {
        Teacher newTeacher = Helper.PromptForPersonell("Teacher", _data.Courses);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a TeacherId for the teacher");
        Console.ReadKey();
        newTeacher.TeacherId = Helper.GenerateGuid();
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
        _data.Teachers.Add(newTeacher);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("teachers.json", _data.Teachers);
        Thread.Sleep(550);
        Console.WriteLine($"{newTeacher.FirstName} {newTeacher.LastName} added to the teacher rolls in the database!");
        Menu.ReturnToMenu();
    }
}
