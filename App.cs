using WestCoastEducation.Interfaces;
using WestCoastEducation.Managers;
using WestCoastEducation.Models;

namespace WestCoastEducation;

public class App
{
    private readonly Menu _menu;

    public List<Teacher> Teachers { get; set; }
    public List<Admin> Admins { get; set; }
    public List<Handler> Handlers { get; set; }

    public App(Menu menu) // whenever a App is created an Menu is created
    {
        Teachers = DatabaseHandler.GetList<Teacher>("teachers.json");
        Admins = DatabaseHandler.GetList<Admin>("admins.json");
        Handlers = DatabaseHandler.GetList<Handler>("handlers.json");

        _menu = menu;
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
}
