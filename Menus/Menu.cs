using Microsoft.VisualBasic;
using WestCoastEducation.Storage;
using WestCoastEducation.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace WestCoastEducation;

public class Menu
{
    private readonly TeacherManager _teacherManager;
    private readonly AdminManager _adminManager;
    private readonly HandlerManager _handlerManager;
    private readonly IServiceProvider _serviceProvider;

    public Menu(StudentManager studentManager, TeacherManager teacherManager, AdminManager adminManager, HandlerManager handlerManager, IServiceProvider serviceProvider)
    {
        _teacherManager = teacherManager;
        _adminManager = adminManager;
        _handlerManager = handlerManager;
        _serviceProvider = serviceProvider;
    }
    private T GetManager<T>() where T : class
    {
        var manager = _serviceProvider.GetRequiredService<T>();
        return manager;
    }
    private void NewCourse() // now use DI instead to create an manager when needed instead for from start
    {
        var manager = GetManager<CourseManager>();
        manager.AddNewCourse();
    }
    private void GetAllCourses()
    {
        var manager = GetManager<CourseManager>();
        manager.ListAllCourses();
    }
    private void NewStudent()
    {
        var manager = GetManager<StudentManager>();
        manager.AddNewStudent();
    }
    private void GetStudentData(string nameOfData)
    {
        var manager = GetManager<StudentManager>();
        manager.ListStudentData(nameOfData);
    }
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
                        NewCourse();
                        break;
                    case 1:
                        _teacherManager.AddNewTeacher();
                        break;
                    case 2:
                        NewStudent();
                        break;
                    case 3:
                        _handlerManager.AddNewHandler();
                        break;
                    case 4:
                        _adminManager.AddNewAdmin();
                        break;
                    case 5:
                        GetAllCourses();
                        break;
                    case 6:
                        HandleStudentSubMenu();
                        break;
                    case 7:
                        Helper.Terminate();
                        break;
                    default:
                        Helper.CheckInput();
                        break;
                }
            }
        }
    }

    public void HandleStudentSubMenu()
    {
        bool inStudentMenu = true;
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
                switch (studentMenuSelection)
                {
                    case 0:
                        // list names
                        GetStudentData("name");
                        ReturnToMenu();
                        break;
                    case 1:
                        // list emails
                        GetStudentData("email");
                        ReturnToMenu();
                        break;
                    case 2:
                        // list phone
                        GetStudentData("phone");
                        ReturnToMenu();
                        break;
                    case 3:
                        // List addresses
                        GetStudentData("address");
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


    public static void ReturnToMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to go back to the menu...");
        Console.ResetColor();
        Console.ReadKey();
    }

}
