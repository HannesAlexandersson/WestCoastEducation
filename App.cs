using WestCoastEducation.Managers;
using WestCoastEducation.Models;

namespace WestCoastEducation;

public class App
{   // "Global" propertys and fields. One List of each type to be used around the application. Only ever one copy, that lives and dies with App
    private Menu _menu;
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Course> Courses { get; set; }
    public List<Admin> Admins { get; set; }
    public List<Handler> Handlers { get; set; }

    private StudentManager _studentManager;
    private TeacherManager _teacherManager;
    private AdminManager _adminManager;
    private HandlerManager _handlerManager;
    private CourseManager _courseManager;


    public App()
    {
        Students = DatabaseHandler.GetList<Student>("students.json");
        Teachers = DatabaseHandler.GetList<Teacher>("teachers.json");
        Courses = DatabaseHandler.GetList<Course>("courses.json");
        Admins = DatabaseHandler.GetList<Admin>("admins.json");
        Handlers = DatabaseHandler.GetList<Handler>("handler.json");
        _studentManager = new StudentManager(Students);
        _teacherManager = new TeacherManager(Teachers);
        _adminManager = new AdminManager(Admins);
        _handlerManager = new HandlerManager(Handlers);
        _courseManager = new CourseManager(Courses, Teachers);
        // send all mangers to menu
        _menu = new Menu(this, _studentManager, _teacherManager, _adminManager, _handlerManager, _courseManager); // create the menu with the current instance of App to avoid circular dependencies
    }

    // Apps main responsibilty is to manage the lists and to run the menus
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
}
