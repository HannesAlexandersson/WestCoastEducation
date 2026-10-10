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

    public static List<Student> GetStudentsList()
    {
        var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        var studentsEnrolled = db.Read(path);

        return studentsEnrolled;
    }
    public static List<Course> GetCoursesList()
    {
        var db = new DataBase<Course>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/courses.json");
        var studentsEnrolled = db.Read(path);

        return studentsEnrolled;
    }
    public static void AddNewStudentToDb(List<Student> studentList)
    {
        var db = new DataBase<Student>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/students.json");
        db.Write(path, studentList);
    }

    public static void AddNewCourseToDb(List<Course> courseList)
    {
        var db = new DataBase<Course>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/courses.json");
        db.Write(path, courseList);
    }


    public static void AddNewStudent()
    {
        var students = GetStudentsList();
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
            bool allClear = false;
            while (!allClear)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Is all fields correct? Y/N");
                Console.ForegroundColor = ConsoleColor.Green;
                var userCheck = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(userCheck))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect input value! Please answer with Y for yes or N for no!");
                    Console.ResetColor();
                    continue;
                }
                else if (userCheck != "y" && userCheck != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please only answer with 'Y' or 'N'");
                    Console.ResetColor();
                    continue;
                }
                else if (userCheck == "y")
                {
                    allClear = true;
                    allFieldsCorrect = true; // end the loop and continue to the write to file
                }
                else if (userCheck == "n")
                {
                    allClear = true;
                    // send the user back to the start of the outer while loop to revalidate the fields                    
                }
            }
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
            Address = address,
            PostalCode = pCode,
            City = city,
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
        AddNewStudentToDb(students);
        Console.WriteLine("Student added to the rolls in the database!");
        MainMenu.ReturnToMenu();

    }

    public static void AddNewCourse()
    {
        var courses = GetCoursesList();
        string title = Helper.PromptUserForStringInput("Enter Title of course: ");
        int courseLngth = Helper.PromptUserForIntInput("Enter length of course in weeks: ");
        DateTime strtDate = Helper.PromptUserForDateInput("Enter the startdate: ");
        DateTime endDate = Helper.PromptUserForDateInput("Enter the enddate: ");

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
            bool allClear = false;
            while (!allClear)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Is all fields correct? Y/N");
                Console.ForegroundColor = ConsoleColor.Green;
                var userCheck = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(userCheck))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect input value! Please answer with Y for yes or N for no!");
                    Console.ResetColor();
                    continue;
                }
                else if (userCheck != "y" && userCheck != "n")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please only answer with 'Y' or 'N'");
                    Console.ResetColor();
                    continue;
                }
                else if (userCheck == "y")
                {
                    allClear = true;
                    allFieldsCorrect = true; // end the loop and continue to the write to file
                }
                else if (userCheck == "n")
                {
                    allClear = true;
                    // send the user back to the start of the outer while loop to revalidate the fields                    
                }
            }
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
            Title = title,
            StartDate = strtDate,
            EndDate = endDate,
            CourseLength = courseLngth,
            CourseId = id
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
        AddNewCourseToDb(courses);
        Console.WriteLine("Student added to the rolls in the database!");
        MainMenu.ReturnToMenu();

    }
    public static void ListAllCourses()
    {
        var courses = GetCoursesList();
        int counter = 0;
        foreach (var course in courses)
        {
            counter++;
            Console.WriteLine(counter + "." + " " + course.Title);
        }
        MainMenu.ReturnToMenu();
    }
}
