using Draw.BLL.AuthBLL;
using Draw.Core.Model;
using Draw.Core.Repositories;
using Draw.EF.Repositories;
using Draw.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace Draw.API.Configurations
{
    public static class CorsConfigurations
    {
        /// <summary>
        /// Add Cors Configurations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddCorsConfigurations(this IServiceCollection services, Microsoft.AspNetCore.Builder.WebApplicationBuilder builder)
        {
            //Add Cors And Create Policy For Ng App
            builder.Services.AddCors(c => c.AddPolicy("ngApp", options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));
            return services;
        }

        /// <summary>
        /// Use Cors Configurations
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCorsConfigurations(this WebApplication app)
        {
            app.UseCors("ngApp");

            return app;
        }
    }
}
