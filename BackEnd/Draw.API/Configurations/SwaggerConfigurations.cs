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
    public static class SwaggerConfigurations
    {
        /// <summary>
        /// Add Swagger Configurations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection services, Microsoft.AspNetCore.Builder.WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return services;
        }

        /// <summary>
        /// Use Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerConfigurations(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            return app;
        }
    }
}
