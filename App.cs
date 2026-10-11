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
        var newTeacherPersonData = Helper.PromptForPerson("teacher");
        var newTeacherData = Helper.PromptForTeacher();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("please make sure that all info is correct before proceeding...");
        Console.ReadKey();
        bool allFieldsCorrect = false;

        while (!allFieldsCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            newTeacherPersonData.FirstName =
                Helper.ValidateStringInput("Firstname", newTeacherPersonData.FirstName);
            Console.Clear();

            newTeacherPersonData.LastName =
                Helper.ValidateStringInput("Lastname", newTeacherPersonData.LastName);
            Console.Clear();

            newTeacherPersonData.Addresses[0].StreetAddress =
                Helper.ValidateStringInput("Address", newTeacherPersonData.Addresses[0].StreetAddress);
            Console.Clear();

            newTeacherPersonData.Addresses[0].PostalCode =
                Helper.ValidateIntInput("Postal code", newTeacherPersonData.Addresses[0].PostalCode);
            Console.Clear();

            newTeacherPersonData.Addresses[0].City =
                Helper.ValidateStringInput("City", newTeacherPersonData.Addresses[0].City);
            Console.Clear();

            newTeacherPersonData.PhoneNumber =
                Helper.ValidateStringInput("Phonenumber", newTeacherPersonData.PhoneNumber);
            Console.Clear();

            newTeacherPersonData.Email =
                Helper.ValidateStringInput("Email", newTeacherPersonData.Email ?? "");
            Console.Clear();

            for (int i = 0; i < newTeacherData.SubjectFields.Length; i++)
            {
                newTeacherData.SubjectFields[i].NameOfSubject =
                    Helper.ValidateStringInput(
                        $"Subject field {i + 1}",
                        newTeacherData.SubjectFields[i].NameOfSubject);
                Console.Clear();
            }

            for (int i = 0; i < newTeacherData.TeachingCourses.Length; i++)
            {
                newTeacherData.TeachingCourses[i].Title =
                    Helper.ValidateStringInput(
                        $"Course title {i + 1}",
                        newTeacherData.TeachingCourses[i].Title);
                Console.Clear();
            }

            Console.WriteLine("*** NEW TEACHER FIELDS ***");
            Console.WriteLine($"{newTeacherPersonData.FirstName} {newTeacherPersonData.LastName}");
            Console.WriteLine($"{newTeacherPersonData.Addresses[0].StreetAddress} {newTeacherPersonData.Addresses[0].PostalCode} {newTeacherPersonData.Addresses[0].City}");
            Console.WriteLine(newTeacherPersonData.PhoneNumber);
            Console.WriteLine(newTeacherPersonData.Email);

            Console.WriteLine("Subject fields:");
            foreach (var subject in newTeacherData.SubjectFields)
            {
                Console.WriteLine(subject.NameOfSubject);
            }

            Console.WriteLine("Teaching courses:");
            foreach (var course in newTeacherData.TeachingCourses)
            {
                Console.WriteLine(course.Title);
            }

            Console.WriteLine("********-----********");
            allFieldsCorrect = Helper.ConfirmInput();
        }


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Press any key to generate a TeacherId for the teacher");
        Console.ReadKey();
        Guid id = Helper.GenerateGuid();
        Console.WriteLine($" TeacherId created: {id}. Press any key to add the new teacher into the database...");
        Console.ReadKey();
        Thread.Sleep(550);
        Console.WriteLine("Please wait while the system adds the teacher to the database...");
        Thread.Sleep(550);

        // construct the new teacher object with all the user inputted fields
        Teacher newTeacher = new()
        {
            TeacherId = id,
            FirstName = newTeacherPersonData.FirstName,
            LastName = newTeacherPersonData.LastName,
            PhoneNumber = newTeacherPersonData.PhoneNumber,
            Email = newTeacherPersonData.Email,
            Addresses = newTeacherPersonData.Addresses,
            SubjectFields = newTeacherData.SubjectFields,
            TeachingCourses = newTeacherData.TeachingCourses
        };
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
        Console.WriteLine($"{newTeacherPersonData.FirstName} {newTeacherPersonData.LastName} added to the teacher rolls in the database!");
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
        Guid teacherId = Helper.SelectTeacher(teachers);

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
            CourseTeacherId = teacherId
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
