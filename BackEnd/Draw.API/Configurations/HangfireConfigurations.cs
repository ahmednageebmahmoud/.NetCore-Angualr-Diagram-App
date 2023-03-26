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
using Hangfire;
using Draw.BLL.HangfireBLL;

namespace Draw.API.Configurations
{

    public static class HangfireConfigurations
    {
        /// <summary>
        /// Add Hangfire Configurations
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddHangfireConfigurations(this IServiceCollection services, Microsoft.AspNetCore.Builder.WebApplicationBuilder builder)
        {
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(nameOrConnectionString: builder.Configuration.GetConnectionString("PC_Windows")));
            builder.Services.AddHangfireServer();

            //Add Hangfire Service
            builder.Services.AddScoped<IHangfireService, HangfireService>( );
            return services;
        }

        /// <summary>
        /// Scheduled Job, Call Job After Some Seconds, Call For Fisrt Itme Only
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHangfireConfigurations(this WebApplication app)
        {
            app.UseHangfireDashboard(pathMatch: "/hangfire");
            return app;
        }



    }
}
