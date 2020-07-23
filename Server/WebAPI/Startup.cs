using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.DTO;

namespace WebAPI
{
  public class Startup
  {
    readonly string VueCorsPolicy = "_vueCorsPolicy";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var frontConfiguration = Configuration.GetSection("Front").Get<FrontConfiguration>();
      services.AddCors(options =>
      {
        options.AddPolicy(name: VueCorsPolicy,
                                builder =>
                                {
                                  builder
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials()
                                          .WithOrigins(frontConfiguration.AddressFront);
                                });
      });

      services.AddControllers();

      services.AddSingleton(frontConfiguration);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("FantasyDreamWorlds", 
          new OpenApiInfo { Title = "FantasyDreamWorlds API", Version = "v1" });
      });

      services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseCors(VueCorsPolicy);

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/FantasyDreamWorlds/swagger.json", "FantasyDreamWorlds API");
        c.RoutePrefix = string.Empty;
      });

    }
  }
}
