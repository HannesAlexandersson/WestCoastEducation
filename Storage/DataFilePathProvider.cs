using WestCoastEducation.Interfaces;

namespace WestCoastEducation.Storage;

public class DataFilePathProvider : IDataFilePathProvider
{
    private readonly string _dataDirectory;

    public DataFilePathProvider(string dataDirectory)
    {
        _dataDirectory = dataDirectory;
    }

    public string GetPath(string fileName)
    {
        return Path.Combine(_dataDirectory, fileName);
    }
}
