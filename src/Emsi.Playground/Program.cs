using Emsi.Playground;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        var startup = new Startup();

        startup.ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var dataServices = serviceProvider.GetService<DataService>();

        //if (dataServices != null) await dataServices.RunAsync();
        if (dataServices != null) await dataServices.RunDbExampleAsync();
    }
}