using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.DTO;

namespace WebAPI.Installers
{
  public class CorsInstaller : IInstaller
  {
    readonly string VueCorsPolicy = "_vueCorsPolicy";
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
      var frontConfiguration = configuration.GetSection("Front").Get<FrontConfiguration>();
      
      services.AddCors(options =>
      {
        options
          .AddPolicy(name: VueCorsPolicy, builder =>
          {
            builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .WithOrigins(frontConfiguration.AddressFront);
          });
      });

      services.AddSingleton(frontConfiguration);
      services.AddControllers();
    }
  }
}
