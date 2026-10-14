using System;

namespace WestCoastEducation.Managers;

public class CourseManager
{
    private readonly List<Course> _courses;
    private readonly List<Teacher> _teachers;

    public CourseManager(List<Course> courses, List<Teacher> teachers)
    {
        _courses = courses;
        _teachers = teachers;
    }

    public void ListAllCourses()
    {
        int counter = 0;
        foreach (var course in _courses)
        {
            counter++;
            Console.WriteLine($"\e[0;34m{counter}. {course.Title} =>   \e[0;33m{course.CourseType} \e[0m"); // Display all courses with name and type (classroom or ditance)
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
        Course newCourse = new()
        {
            Title = title,
            StartDate = strtDate,
            EndDate = endDate,
            CourseLength = courseLngth,
            CoursePersonnelIds = teacherId,
            CourseType = courseType
        };
        if (Helper.CheckForDuplicates(_courses, newCourse))
        {
            Console.WriteLine("ERROR!!! The course you are trying to add already exists!!! Stand by while the system explodes... (press any key)");
            return;
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a CourseID for the Course");
        Console.ReadKey();
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" CourseId created: {id}. Press any key to add the new course into the database...");
        Console.ReadKey();
        Console.WriteLine("Please wait while the system adds the course to the database...");
        Thread.Sleep(550);
        // add the id
        newCourse.CourseId = id;
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        _courses.Add(newCourse);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("courses.json", _courses);
        Console.WriteLine($"{newCourse.Title} added to the rolls in the database!");
        Menu.ReturnToMenu();
    }
}
