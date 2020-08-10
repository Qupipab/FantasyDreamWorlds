using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace WebAPI.Installers
{
  public class SwaggerInstaller : IInstaller
  {

    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {

      services.AddSwaggerGen(s =>
      {
        s.SwaggerDoc("FantasyDreamWorlds",
          new OpenApiInfo { Title = "FantasyDreamWorlds API", Version = "v1" });

        var security = new Dictionary<string, IEnumerable<string>>
        {
          { "Bearer", new string[0] }
        };

        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using bearer scheme",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey
        });

        s.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
              }
            }, new List<string>()
          }
        });
      });
    }

  }
}
