using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.DependencyInjection;

namespace WestCoastEducation;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddWestCoastEducation();

        using var serviceProvider = services.BuildServiceProvider();
        App app = serviceProvider.GetRequiredService<App>();
        app.Run();
    }
}
