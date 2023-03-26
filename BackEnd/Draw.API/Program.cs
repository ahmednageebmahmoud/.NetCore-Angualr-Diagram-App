using Draw.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Draw.Core.Repositories;
using Draw.EF;
using Draw.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Draw.BLL.AuthBLL;
using Draw.BLL.DiagramBLL;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System.Configuration;
using Draw.API.Configurations;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);



//Add Serilog Configurations
builder.Services.AddSerilogConfigurations(builder);

//Add Cors Configurations
builder.Services.AddCorsConfigurations(builder);

// Add services to the container.
builder.Services.AddControllers();

//Add Swagger Configurations
builder.Services.AddSwaggerConfigurations(builder);

//DBContext Configurations
builder.Services.AddContextConfigurations(builder);

//Add JWT Service As Scoped
builder.Services.AddScoped<IJWTService, JWTService>();

///Add Auth Service As Scoped
builder.Services.AddScoped<IAuthService, AuthService>();

///Add  Diagram Service As Scoped
builder.Services.AddScoped<DiagramService, DiagramService>();

//Add JWT Configurations
builder.Services.AddJWTConfigurations(builder);

//Add Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add Hangfire Configrations
builder.Services.AddHangfireConfigurations(builder);

var app = builder.Build();

//Use Cors
app.UseCorsConfigurations();

//Use Swagger
 app.UseSwaggerConfigurations();

//User Hangfire
app.UseHangfireConfigurations();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

