namespace WestCoastEducation;

class Program
{
    static void Main()
    {
        try
        {
            App app = new();
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
