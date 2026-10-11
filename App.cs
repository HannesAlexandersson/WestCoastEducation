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

    public static void AddNewTeacher()
    {
        var teachers = DatabaseHandler.GetList<Teacher>("teachers.json");
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
        teachers.Add(newTeacher);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("teachers.json", teachers);
        Thread.Sleep(550);
        Console.WriteLine($"{newTeacher.FirstName} {newTeacher.LastName} added to the teacher rolls in the database!");
        MainMenu.ReturnToMenu();
    }

    public static void AddNewAdmin()
    {
        AddNewPersonnel<AdminPersonel>("admins.json", "Admin"); // use the genric method of adding new adminsitrive personell
    }
    public static void AddNewHandler()
    {
        AddNewPersonnel<Handler>("handlers.json", "Handler");
    }

    // this was also really really hard, I thought long and hard on how to create a generic ethod to add in handler AND admin personell
    public static void AddNewPersonnel<T>(string fileName, string position) where T : Handler, new()
    {
        var personnel = DatabaseHandler.GetList<T>(fileName);
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
        personnel.Add(newPerson);
        DatabaseHandler.SaveList(fileName, personnel);
        MainMenu.ReturnToMenu();
    }
    public static void AddNewStudent()
    {
        var students = DatabaseHandler.GetList<Student>("students.json"); // get a copy of the current student list for later
        Person personData = Helper.PromptForPerson("student");
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        bool allFieldsCorrect = false;
        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            personData.FirstName = Helper.ValidateStringInput("Firstname", personData.FirstName);
            Console.Clear();

            personData.LastName = Helper.ValidateStringInput("Lastname", personData.LastName);
            Console.Clear();

            personData.Addresses[0].StreetAddress =
                Helper.ValidateStringInput("Address", personData.Addresses[0].StreetAddress);
            Console.Clear();

            personData.Addresses[0].PostalCode =
                Helper.ValidateIntInput("Postal code", personData.Addresses[0].PostalCode);
            Console.Clear();

            personData.Addresses[0].City =
                Helper.ValidateStringInput("City", personData.Addresses[0].City);
            Console.Clear();

            personData.PhoneNumber =
                Helper.ValidateStringInput("Phonenumber", personData.PhoneNumber);
            Console.Clear();

            personData.Email =
                Helper.ValidateStringInput("Email", personData.Email ?? ""); // its allowed for a person to not have an email, so leave it empty if they dont have one
            Console.Clear();

            Console.WriteLine("NEW STUDENT FIELDS:");
            Console.WriteLine($"{personData.FirstName} {personData.LastName}");
            Console.WriteLine($"{personData.Addresses[0].StreetAddress} {personData.Addresses[0].PostalCode} {personData.Addresses[0].City}");
            Console.WriteLine(personData.PhoneNumber);
            Console.WriteLine(personData.Email);

            allFieldsCorrect = Helper.ConfirmInput();
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a studentId for the student");
        Console.ReadKey();
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" StudentId created: {id}. Press any key to add the new student into the database...");
        Console.ReadKey();
        Thread.Sleep(550);
        Console.WriteLine("Please wait while the system adds the student to the database...");
        Thread.Sleep(550);
        // construct the new Student object with all the user inputted fields
        Student newStudent = new()
        {
            StudentId = id,
            FirstName = personData.FirstName,
            LastName = personData.LastName,
            PhoneNumber = personData.PhoneNumber,
            Email = personData.Email,
            Addresses = personData.Addresses
        };
        Thread.Sleep(550);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        // add the new student to the students list
        students.Add(newStudent);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("students.json", students);
        Console.WriteLine($"{personData.FirstName} {personData.LastName} added to the rolls in the database!");
        MainMenu.ReturnToMenu();

    }

    public static void AddNewCourse()
    {
        var teachers = DatabaseHandler.GetList<Teacher>("teachers.json");
        var courses = DatabaseHandler.GetList<Course>("courses.json");
        string title = Helper.PromptUserForStringInput("Enter Title of course: ");
        int courseLngth = Helper.PromptUserForIntInput("Enter length of course in weeks: ");
        DateTime strtDate = Helper.PromptUserForDateInput("Enter the startdate: ");
        DateTime endDate = Helper.PromptUserForDateInput("Enter the enddate: ");
        Guid[] teacherId = Helper.SelectTeacher(teachers);

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
        Thread.Sleep(550);
        Course newCourse = new()
        {
            CourseId = id,
            Title = title,
            StartDate = strtDate,
            EndDate = endDate,
            CourseLength = courseLngth,
            CoursePersonnelIds = teacherId
        };
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Connecting to database...");
        Thread.Sleep(550);
        courses.Add(newCourse);
        Console.WriteLine("....");
        Thread.Sleep(550);
        Console.WriteLine("Writing to disk...");
        // write the new updated list to file
        DatabaseHandler.SaveList("courses.json", courses);
        Console.WriteLine($"{newCourse.Title} added to the rolls in the database!");
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
