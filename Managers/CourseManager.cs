using System;
using WestCoastEducation.Factories;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Managers;

public class CourseManager
{
    private readonly List<Course> _courses;
    private readonly List<Teacher> _teachers;
    private readonly IDatabase<Course> _database;
    private readonly ICourseFactory _courseFactory;

    public CourseManager(
        List<Course> courses,
        List<Teacher> teachers,
        IDatabase<Course> database,
        ICourseFactory courseFactory)
    {
        _courses = courses;
        _teachers = teachers;
        _database = database;
        _courseFactory = courseFactory;
    }

    public void ListAllCourses()
    {
        int counter = 0;
        foreach (var course in _courses)
        {
            counter++;
            Console.WriteLine($"{counter}. {course.Title} => {course.CourseType}"); // Display all courses with name and type (classroom or ditance)
        }
        Menu.ReturnToMenu();
    }

    public void AddNewCourse()
    {
        string title = Helper.PromptUserForStringInput("Enter Title of course: ");
        int courseLngth = Helper.PromptUserForIntInput("Enter length of course in weeks: ");
        DateTime strtDate = Helper.PromptUserForDateInput("Enter the startdate: ");
        DateTime endDate = Helper.PromptUserForDateInput("Enter the enddate: ");
        Guid[] teacherId = Helper.SelectTeacher(_teachers);
        CourseType courseType = Helper.PromptForCourseType();
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        bool allFieldsCorrect = false;
        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            title = Helper.ValidateStringInput("Title", title);
            Console.Clear();
            courseLngth = Helper.ValidateIntInput("Course Length", courseLngth);
            Console.Clear();
            strtDate = Helper.ValidateDateInput("Start Date", strtDate);
            Console.Clear();
            endDate = Helper.ValidateDateInput("End Date", endDate);
            Console.Clear();
            if (Helper.ValidateCourseType("Course type", courseType))
            {
                courseType = Helper.PromptForCourseType();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("NEW COURSE FIELDS: ");
            Console.WriteLine($"{title}");
            Console.WriteLine($"{courseLngth} weeks");
            Console.WriteLine($"{strtDate} - {endDate}");
            Console.WriteLine($"Course type: {courseType}");
            allFieldsCorrect = Helper.ConfirmInput(); // confirm all input
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a CourseID for the Course");
        Console.ReadKey();
        Course newCourse = _courseFactory.Create(title, courseLngth, strtDate, endDate, teacherId, courseType);
        Console.WriteLine($" CourseId created: {newCourse.CourseId}. Press any key to add the new course into the database...");
        Console.ReadKey();
        Console.WriteLine("Please wait while the system adds the course to the database...");
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        _courses.Add(newCourse);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        _database.Write("courses.json", _courses);
        Console.WriteLine($"{newCourse.Title} added to the rolls in the database!");
        Menu.ReturnToMenu();
    }
}
