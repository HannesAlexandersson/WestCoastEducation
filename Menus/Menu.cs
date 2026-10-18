using Microsoft.VisualBasic;
using WestCoastEducation.Storage;
using WestCoastEducation.Managers;
using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Models;
using WestCoastEducation.Enums;

namespace WestCoastEducation.Menus;

public class Menu
{
    private readonly IServiceProvider _serviceProvider;

    public Menu(IServiceProvider serviceProvider)
    {
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
    private void NewTeacher()
    {
        var manager = GetManager<TeacherManager>();
        manager.AddNewTeacher();
    }
    private void NewAdmin()
    {
        var manager = GetManager<AdminManager>();
        manager.AddNewAdmin();
    }
    private void NewHandler()
    {
        var manager = GetManager<HandlerManager>();
        manager.AddNewHandler();
    }
    private void GetAllCourses()
    {
        var manager = GetManager<CourseManager>();
        manager.ListAllCourses();
    }
    private void SortedCourses(CourseTypeEnum type)
    {
        var manager = GetManager<CourseManager>();
        manager.ListAllCoursesSorted(type);
    }
    private void GetCourselength()
    {
        var manager = GetManager<CourseManager>();
        manager.ListCoursesLength();
    }
    public static void ReturnToMenu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to go back to the menu...");
        Console.ResetColor();
        Console.ReadKey();
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
                        NewTeacher();
                        break;
                    case 2:
                        NewStudent();
                        break;
                    case 3:
                        NewHandler();
                        break;
                    case 4:
                        NewAdmin();
                        break;
                    case 5:
                        HandleCourseSubMenu();
                        //GetAllCourses();
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
    public void HandleCourseSubMenu()
    {
        bool inCourseMenu = true;
        string[] listCourseMenuIptions = ["1. List all courses", "2. List all distance course", "3. List all at classroom courses", "4. List courses assigned teachers", "5. Go back to main menu"];
        int courseMenuSelection = 0;
        while (inCourseMenu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            if (courseMenuSelection == 0)
            {
                Console.WriteLine("List course functions");
                Console.WriteLine("*********************");
                Console.WriteLine("* " + listCourseMenuIptions[0] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (courseMenuSelection == 1)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listCourseMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listCourseMenuIptions[1] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (courseMenuSelection == 2)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listCourseMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listCourseMenuIptions[2] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (courseMenuSelection == 3)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listCourseMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listCourseMenuIptions[3] + " *");
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[4]);
                Console.WriteLine("- - - - - - - - - - -");
            }
            if (courseMenuSelection == 4)
            {
                Console.WriteLine("List student functions");
                Console.WriteLine("*********************");
                Console.WriteLine(listCourseMenuIptions[0]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[1]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[2]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine(listCourseMenuIptions[3]);
                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("* " + listCourseMenuIptions[4] + " *");
                Console.WriteLine("- - - - - - - - - - -");
            }
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.DownArrow && courseMenuSelection != listCourseMenuIptions.Length - 1)
            {
                courseMenuSelection++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && courseMenuSelection >= 1)
            {
                courseMenuSelection--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (courseMenuSelection)
                {
                    case 0:

                        GetAllCourses();
                        ReturnToMenu();
                        break;
                    case 1:

                        SortedCourses(CourseTypeEnum.Classroom);
                        ReturnToMenu();
                        break;
                    case 2:

                        SortedCourses(CourseTypeEnum.Distance);
                        ReturnToMenu();
                        break;
                    case 3:
                        GetCourselength();
                        ReturnToMenu();
                        break;
                    case 4:
                        inCourseMenu = false;
                        break;
                    default:
                        Helper.CheckInput();
                        break;
                }
            }
        }

    }

}
