using System;

namespace WestCoastEducation.Managers;

public class TeacherManager
{
    private readonly List<Teacher> _teachers;

    public TeacherManager(List<Teacher> teachers)
    {
        _teachers = teachers;
    }

    public void AddNewTeacher()
    {
        Teacher newTeacher = Helper.PromptForPersonell("Teacher");
        //check if the teachers 'Person' propertys already exists in the teachers lsit, if it does it means the teacher already in the list
        if (Helper.CheckForDuplicates(_teachers, newTeacher))
        {
            Console.WriteLine("ERROR!!! The teacher is already in the list! Press any key to return to menu...");
            Console.ReadLine();
            return;
        }
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
        _teachers.Add(newTeacher);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("teachers.json", _teachers);
        Thread.Sleep(550);
        Console.WriteLine($"{newTeacher.FirstName} {newTeacher.LastName} added to the teacher rolls in the database!");
        Menu.ReturnToMenu();
    }
}
