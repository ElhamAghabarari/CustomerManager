using CustomerManagement.Application.Extentions;
using CustomerManagement.Infrastructure.Extentions;
using CustomerManagement.WebApi.Handlers;

namespace CustomerManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); 
                                  });
            });
            // Add services to the container.

           

            builder.Configuration.AddJsonFile("appsettings.json");
            

            /*
                builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                if (app.Environment.IsDevelopment())
                {
                    var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                    if (appAssembly != null)
                    {
                        builder.Configuration.AddUserSecrets(appAssembly, optional: true);
                    }
                }

                builder.Configuration.AddEnvironmentVariables();

                if (args != null)
                {
                    builder.Configuration.AddCommandLine(args);
                }
            */

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            //Registers your custom exception handler in the service container
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Adds the middleware that utilizes your registered exception handler
            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

           

            app.MapControllers();

            app.Run();


           
        }
    }
}