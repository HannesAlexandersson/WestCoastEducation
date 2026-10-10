using Microsoft.VisualBasic;
using WestCoastEducation.Storage;

namespace WestCoastEducation;

public class MainMenu
{


    public void RunMenu()
    {
        string[] menuOptions = ["1. Add new course", "2. Add new teacher", "3. Add new student", "4. Add new handler", "5. Add new admins", "6. List all courses", "7. List all students", "8. Exit"];
        int menuSelect = 0;
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;
            if (menuSelect == 0)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine("* " + menuOptions[0] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);

                Console.WriteLine("*********************");

            }
            else if (menuSelect == 1)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[1] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);


                Console.WriteLine("*********************");
            }
            else if (menuSelect == 2)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[2] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);

                Console.WriteLine("*********************");
            }
            else if (menuSelect == 3)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[3] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);

                Console.WriteLine("*********************");
            }
            else if (menuSelect == 4)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[4] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);

                Console.WriteLine("*********************");
            }
            else if (menuSelect == 5)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[5] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);

                Console.WriteLine("*********************");
            }
            else if (menuSelect == 6)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[6] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[7]);

                Console.WriteLine("*********************");
            }
            else if (menuSelect == 7)
            {
                Console.WriteLine("WestCoast Education");
                Console.WriteLine("*********************");
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[5]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(menuOptions[6]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + menuOptions[7] + " *");

                Console.WriteLine("*********************");
            }


            // let the user use the up and down keys to navigate the menu
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter) // listen to when the user press enter key
            {
                switch (menuSelect)// whatever the index of menuSelect that the user was on when they pressed enter, that correlating method we call
                {
                    case 0:
                        // add new courser
                        break;
                    case 1:
                        // add new teaches
                        break;
                    case 2:
                        AddNewStudent();
                        break;
                    case 3:
                        // add ny handlers
                        break;
                    case 4:
                        // add new admins
                        break;
                    case 5:
                        ListAllCourses();
                        break;
                    case 6:
                        HandleListStudents();
                        break;
                    case 7:
                        Terminate();
                        break;
                    default:
                        Helper.CheckInput();
                        break;

                }
            }
        }
    }

    public void HandleListStudents()
    {
        bool inStudentMenu = true;
        var students = GetStudentsList();
        string[] listStudentMenuIptions = ["1. List student names", "2. List student e-mails", "3. List students phonenumbers", "4. List students addressess", "5. Go back to main menu"];
        int studentMenuSelection = 0;
        while (inStudentMenu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            if (studentMenuSelection == 0)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine("* " + listStudentMenuIptions[0] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (studentMenuSelection == 1)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listStudentMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listStudentMenuIptions[1] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (studentMenuSelection == 2)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listStudentMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listStudentMenuIptions[2] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (studentMenuSelection == 3)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listStudentMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listStudentMenuIptions[3] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (studentMenuSelection == 4)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listStudentMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listStudentMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listStudentMenuIptions[4] + " *");
                Console.WriteLine("- - - - - - - - - - -");
            }
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.DownArrow && studentMenuSelection != listStudentMenuIptions.Length - 1)
            {
                studentMenuSelection++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && studentMenuSelection >= 1)
            {
                studentMenuSelection--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                int counter;
                switch (studentMenuSelection)
                {
                    case 0:
                        // list names
                        counter = 0;
                        foreach (var student in students)
                        {
                            counter++;
                            Console.WriteLine($"{counter}. {student.FirstName} {student.LastName} - id: {student.StudentId}.");
                        }
                        ReturnToMenu();
                        break;
                    case 1:
                        // list emails
                        counter = 0;
                        foreach (var student in students)
                        {
                            counter++;
                            Console.WriteLine($"{counter}. {student.StudentId} - {student.Email}");
                        }
                        ReturnToMenu();
                        break;
                    case 2:
                        // list phone
                        counter = 0;
                        foreach (var student in students)
                        {
                            counter++;
                            Console.WriteLine($"{counter}. {student.StudentId} - {student.PhoneNumber}");
                        }
                        ReturnToMenu();
                        break;
                    case 3:
                        // list addressess
                        counter = 0;
                        foreach (var student in students)
                        {
                            counter++;
                            Console.WriteLine($"{counter}. {student.StudentId} - {student.Address}");
                        }
                        ReturnToMenu();
                        break;
                    case 4:
                        inStudentMenu = false;
                        break;
                    default:
                        Helper.CheckInput();
                        break;
                }
            }
        }

    }

    public void AddNewStudent()
    {
        // first fetch the current student list
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
        Student.AddNewStudentToDb(students);
        Console.WriteLine("Student added to the rolls in the database!");
        ReturnToMenu();
    }



    public void ListAllCourses()
    {
        var courses = Course.ListAllAvailableCourses();
        int counter = 0;
        foreach (var course in courses)
        {
            counter++;
            Console.WriteLine(counter + "." + " " + course.Title);
        }
        ReturnToMenu();
    }



    public List<Student> GetStudentsList()
    {
        return Student.ListAllEnrolled();
    }
    private void ReturnToMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to go back to the menu...");
        Console.ResetColor();
        Console.ReadKey();
    }


    private void Terminate()
    {
        Environment.Exit(0);
    }


}
