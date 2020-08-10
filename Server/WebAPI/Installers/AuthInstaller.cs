using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Options;

namespace WebAPI.Installers
{
  public class AuthInstaller : IInstaller
  {
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
      var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(jwtSettings), jwtSettings);

      services.AddSingleton(jwtSettings);

      services
        .AddAuthentication(a =>
        {
          a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          a.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(b =>
        {
          b.SaveToken = true;
          b.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
          };
        });
        
    }
  }
}
