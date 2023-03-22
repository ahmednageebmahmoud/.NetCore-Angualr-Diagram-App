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
    public static class ContextConfigurations
    {
        /// <summary>
        /// Add Identity,DB Context, UnitOfWork 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddContextConfigurations(this IServiceCollection services, Microsoft.AspNetCore.Builder.WebApplicationBuilder builder)
        {

            //Add Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

            //Add DB Context 
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PC_Windows")));

            //Add UnitOfWork Repositry As Scoped
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
