namespace WestCoastEducation;

public class Presentation
{
    public void Present()
    {
        try
        {
            Console.WriteLine("Presentation running.... ");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
