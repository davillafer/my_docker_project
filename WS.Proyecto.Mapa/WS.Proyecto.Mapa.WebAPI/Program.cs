using WS.Proyecto.Mapa.WebAPI.DataAccessLayer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WS.Proyecto.Mapa.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().CreateDatabase<PetitionsDbContext>().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}