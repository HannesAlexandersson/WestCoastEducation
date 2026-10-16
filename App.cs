using WestCoastEducation.Models;

namespace WestCoastEducation;

public class App
{
    private readonly Menu _menu;
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Course> Courses { get; set; }
    public List<Admin> Admins { get; set; }
    public List<Handler> Handlers { get; set; }

    public App(
        Menu menu,
        List<Student> students,
        List<Teacher> teachers,
        List<Course> courses,
        List<Admin> admins,
        List<Handler> handlers)
    {
        _menu = menu;
        Students = students;
        Teachers = teachers;
        Courses = courses;
        Admins = admins;
        Handlers = handlers;
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
