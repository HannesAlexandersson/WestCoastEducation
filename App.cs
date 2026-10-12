using WestCoastEducation.Managers;

namespace WestCoastEducation;

public class App
{
    private Menu _menu;
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Course> Courses { get; set; }
    public List<AdminPersonel> Admins { get; set; }
    public List<Handler> Handlers { get; set; }

    private StudentManager _studentManager;

    public App()
    {
        // create lists for all the types. One list for each that gets used throughout the app. Only ever one that lives and dies with App instance
        Students = DatabaseHandler.GetList<Student>("students.json");
        Teachers = DatabaseHandler.GetList<Teacher>("teachers.json");
        Courses = DatabaseHandler.GetList<Course>("courses.json");
        Admins = DatabaseHandler.GetList<AdminPersonel>("admins.json");
        Handlers = DatabaseHandler.GetList<Handler>("handler.json");
        _studentManager = new StudentManager(Students); // send the list of students to the manager so we always only use the one list
        _menu = new Menu(this, _studentManager); // create the menu with the current instance of App to avoid circular dependencies with App creating Menu, and in Menu we create an App object. 
    }

    public void Run()
    {
        try
        {
            _menu.RunMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void AddNewTeacher()
    {
        Teacher newTeacher = Helper.PromptForPersonell("Teacher");
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
        Teachers.Add(newTeacher);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("teachers.json", Teachers);
        Thread.Sleep(550);
        Console.WriteLine($"{newTeacher.FirstName} {newTeacher.LastName} added to the teacher rolls in the database!");
        Menu.ReturnToMenu();
    }

    public void AddNewAdmin()
    {
        AddNewPersonnel(Admins, "admins.json", "Admin"); // use the new genric method of adding new adminsitrive personell
    }
    public void AddNewHandler()
    {
        AddNewPersonnel(Handlers, "handlers.json", "Handler"); // use the new genric method of adding new adminsitrive personell
    }

    // since pretty much all these methods does the same thing exept for names and small details i tried to make a genereic method to handle all adminpersonell
    public void AddNewPersonnel<T>(List<T> personnelList, string fileName, string position) where T : Handler, new()
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
        personnelList.Add(newPerson);
        DatabaseHandler.SaveList(fileName, personnelList);
        Menu.ReturnToMenu();
    }


    public void AddNewCourse()
    {
        string title = Helper.PromptUserForStringInput("Enter Title of course: ");
        int courseLngth = Helper.PromptUserForIntInput("Enter length of course in weeks: ");
        DateTime strtDate = Helper.PromptUserForDateInput("Enter the startdate: ");
        DateTime endDate = Helper.PromptUserForDateInput("Enter the enddate: ");
        Guid[] teacherId = Helper.SelectTeacher(Teachers);
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
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" CourseId created: {id}. Press any key to add the new course into the database...");
        Console.ReadKey();
        Console.WriteLine("Please wait while the system adds the course to the database...");
        Thread.Sleep(550);
        Course newCourse = new()
        {
            CourseId = id,
            Title = title,
            StartDate = strtDate,
            EndDate = endDate,
            CourseLength = courseLngth,
            CoursePersonnelIds = teacherId,
            CourseType = courseType
        };
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        Courses.Add(newCourse);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("courses.json", Courses);
        Console.WriteLine($"{newCourse.Title} added to the rolls in the database!");
        Menu.ReturnToMenu();
    }
    public void ListAllCourses()
    {
        int counter = 0;
        foreach (var course in Courses)
        {
            counter++;
            Console.WriteLine($"{counter}. {course.Title} => {course.CourseType}"); // Display all courses with name and type (classroom or ditance)
        }
        Menu.ReturnToMenu();
    }
}
