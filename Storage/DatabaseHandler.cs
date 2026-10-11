using WestCoastEducation.Storage;

namespace WestCoastEducation;

// another helper method to take responsibility for deciding where the application stores it files
public class DatabaseHandler
{
    // generic methods to replace the 5 almost identical former methods I had
    public static List<T> GetList<T>(string fileName) where T : class
    {
        var db = new DataBase<T>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/", fileName);

        return db.Read(path);
    }

    public static void SaveList<T>(string fileName, List<T> data) where T : class
    {
        var db = new DataBase<T>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/", fileName);

        db.Write(path, data);
    }
}