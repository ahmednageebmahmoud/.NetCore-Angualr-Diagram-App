using Serilog;
namespace Draw.API.Configurations
{
    public static class SerilogConfiguration
    {
        /// <summary>
        /// Add Serilog Configurations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddSerilogConfigurations(this IServiceCollection services, Microsoft.AspNetCore.Builder.WebApplicationBuilder builder)
        {
            try
            {
                //To Apply appsettings.json configrations you need to ConfigurationBuilder to easy do that
                var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json") // Add main appsettings.json
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true) // if you have setting file for every environment
                        .Build();

                //Now Create Logger And Pass Configration And Set File Configation
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    //I Prefer You Add the Configuration File Here Because It's Available To Add Args In File Path Like Date Or Else
                    //Write As Text
                    .WriteTo.File(
                    //Log Path
                    path: "./logs/log-text-",
                    //Every Day Log In A New File
                    rollingInterval: RollingInterval.Day,
                     //Log Text Formatter
                     outputTemplate: "[{Timestamp:HH:mm:ss} => {SourceContext} => [{Level}] => {Message}{NewLine}{Exception}"
                    )
                  //Write Also As Json
                  .WriteTo.File(
                    //Log Path
                    path: "./logs/log-json-",
                    //Every Day Log In A New File
                    rollingInterval: RollingInterval.Day,
                    //Or Log As Josn Format
                    formatter: new Serilog.Formatting.Json.JsonFormatter(",")
                    )
                    .CreateLogger();


                //Use Serilog
                builder.Host.UseSerilog();
                
                Log.Warning("Serilog Is Built");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "I Can't Run The Project");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            Log.Warning("I Here In SerilogConfiguration.AddConfigurations");
            
            return services;
        }
    }
}
