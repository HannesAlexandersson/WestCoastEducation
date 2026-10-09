namespace WestCoastEducation;

class Program
{
    static void Main()
    {
        MainMenu menu = new();
        try
        {
            menu.RunMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
