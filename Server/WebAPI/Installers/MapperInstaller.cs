using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.MappingProfiles;

namespace WebAPI.Installers
{
  public class MapperInstaller : IInstaller
  {

    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new MappingProfile());
        mc.AddProfile(new RequestToModelProfile());
      });

      services.AddSingleton(mappingConfig.CreateMapper());
    }
  }
}
