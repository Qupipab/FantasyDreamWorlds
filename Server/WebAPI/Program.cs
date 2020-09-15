using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace WebAPI
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      
      using(var serviceScope = host.Services.CreateScope())
      {
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if(!await roleManager.RoleExistsAsync("Admin"))
        {
          var adminRole = new IdentityRole("Admin");
          await roleManager.CreateAsync(adminRole);
        }

        if (!await roleManager.RoleExistsAsync("Moder"))
        {
          var adminRole = new IdentityRole("Moder");
          await roleManager.CreateAsync(adminRole);
        }
      }

      await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
