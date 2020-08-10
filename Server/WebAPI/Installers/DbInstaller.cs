using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Installers
{
  public class DbInstaller : IInstaller
  {

    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<RepositoryContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));

      services.AddIdentity<User, IdentityRole>(opt =>
      {
        opt.Password.RequiredLength = 12;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireNonAlphanumeric = false;
      })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddTop10000PasswordValidator<User>();
    }

  }
}
