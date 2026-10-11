using System;
using System.ComponentModel.Design;
using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class App
{
    public MainMenu Menu = new();

    public void Run()
    {
        try
        {
            Menu.RunMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



    public static void AddNewStudent()
    {
        var students = DatabaseHandler.GetList<Student>("students.json"); // get a copy of the current student list for later
        // ask the user for all new student info       
        string firstName = Helper.PromptUserForStringInput("Enter students firstname: ");
        string lastName = Helper.PromptUserForStringInput("Enter students lastname: ");
        string email = Helper.PromptUserForStringInput("Enter students email: ");
        string phone = Helper.PromptUserForStringInput("Enter students phonenumber: ");
        string address = Helper.PromptUserForStringInput("Enter students address: ");
        int pCode = Helper.PromptUserForIntInput("Enter students postal code: ");
        string city = Helper.PromptUserForStringInput("Enter what city the student lives in: ");
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        bool allFieldsCorrect = false;
        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            firstName = Helper.ValidateStringInput("Firstname", firstName);
            Console.Clear();
            lastName = Helper.ValidateStringInput("Lastname", lastName);
            Console.Clear();
            address = Helper.ValidateStringInput("Address", address);
            Console.Clear();
            pCode = Helper.ValidateIntInput("Postal code", pCode);
            Console.Clear();
            city = Helper.ValidateStringInput("City", city);
            Console.Clear();
            phone = Helper.ValidateStringInput("Phonenumber", phone);
            Console.Clear();
            email = Helper.ValidateStringInput("Email", email);
            Console.Clear();

            Console.WriteLine("NEW STUDENT FIELDS: ");
            Console.WriteLine($"{firstName} {lastName}");
            Console.WriteLine($"{address} {pCode} {city}");
            Console.WriteLine($"{phone}");
            Console.WriteLine($"{email}");

            allFieldsCorrect = Helper.ConfirmInput();
        }


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a studentId for the student");
        Console.ReadKey();
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" StudentId created: {id}. Press any key to add the new student into the database...");
        Console.ReadKey();
        Console.WriteLine("Please wait while the system adds the student to the database...");
        Thread.Sleep(450);
        // construct the new Student object with all the user input fields
        Student newStudent = new()
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phone,
            Email = email,
            Addresses =
            [
                new Address
                {
                    StreetAddress = address,
                    PostalCode = pCode,
                    City = city
                }
            ],
            StudentId = id
        };
        Console.WriteLine("....");
        Thread.Sleep(450);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(450);
        // add the new student to the students list
        students.Add(newStudent);
        Console.WriteLine("....");
        Thread.Sleep(450);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("students.json", students);
        Console.WriteLine("Student added to the rolls in the database!");
        MainMenu.ReturnToMenu();

    }

    public static void AddNewCourse()
    {
        var courses = DatabaseHandler.GetList<Course>("courses.json");
        string title = Helper.PromptUserForStringInput("Enter Title of course: ");
        int courseLngth = Helper.PromptUserForIntInput("Enter length of course in weeks: ");
        DateTime strtDate = Helper.PromptUserForDateInput("Enter the startdate: ");
        DateTime endDate = Helper.PromptUserForDateInput("Enter the enddate: ");
        Guid teacherId = Helper.SelectTeacher();

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
            endDate = Helper.ValidateDateInput("Start Date", endDate);
            Console.Clear();


            Console.WriteLine("NEW COURSE FIELDS: ");
            Console.WriteLine($"{title}");
            Console.WriteLine($"{courseLngth} weeks");
            Console.WriteLine($"{strtDate} - {endDate}");

            allFieldsCorrect = Helper.ConfirmInput(); // confirm all input

        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a CourseID for the Course");
        Console.ReadKey();
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" CourseId created: {id}. Press any key to add the new course into the database...");
        Console.ReadKey();
        Console.WriteLine("Please wait while the system adds the course to the database...");
        Thread.Sleep(450);
        Course newCourse = new()
        {
            CourseId = id,
            Title = title,
            StartDate = strtDate,
            EndDate = endDate,
            CourseLength = courseLngth,
            CourseTeacherId = teacherId
        };
        Console.WriteLine("....");
        Thread.Sleep(450);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(450);
        courses.Add(newCourse);
        Console.WriteLine("....");
        Thread.Sleep(450);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("courses.json", courses);
        Console.WriteLine("Student added to the rolls in the database!");
        MainMenu.ReturnToMenu();

    }
    public static void ListAllCourses()
    {
        var courses = DatabaseHandler.GetList<Course>("courses.json");
        int counter = 0;
        foreach (var course in courses)
        {
            counter++;
            Console.WriteLine(counter + "." + " " + course.Title);
        }
        MainMenu.ReturnToMenu();
    }
}
