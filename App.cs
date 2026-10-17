using WestCoastEducation.Menus;

namespace WestCoastEducation;
// Apps responsibilty is to manage the lists via the managers and to run the menus
public class App
{
    private readonly Menu _menu;
    public App(Menu menu) // whenever a App is created an Menu is created
    {
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
