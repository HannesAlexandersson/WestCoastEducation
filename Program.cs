using Microsoft.Extensions.DependencyInjection;
using WestCoastEducation.Utils;

namespace WestCoastEducation;

class Program
{
    static void Main()
    {
        var collection = new ServiceCollection(); // use the DI nugget package
        collection.AddServices(); // use services we registred in the serviceCollextionExtension
        using var services = collection.BuildServiceProvider(); // package all services and put them in 'services' to we can access them easily.

        var app = services.GetRequiredService<App>(); // here is where the instance of App is created and indirectly also an instance of menu. 
        app.Run();
    }
}
