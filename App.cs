using WestCoastEducation.Menus;

namespace WestCoastEducation;
// Apps responsibilty is to manage the lists via the managers and to run the menus
public class App
{
    private readonly Menu _menu; //Composition, whenever a App is created an Menu is created
    public App(Menu menu)
    {
        _menu = menu;
    }

    public void Run()
    {
        _menu.RunMenu();
    }
}
