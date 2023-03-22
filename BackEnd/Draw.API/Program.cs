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

var builder = WebApplication.CreateBuilder(args);
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

    //User Serilog
    builder.Host.UseSerilog();
}
catch (Exception ex)
{
    Log.Fatal(ex, "I Can't Run The Project");
}
finally
{
    Log.CloseAndFlush();
}


//Add Cors And Create Policy For Ng App
builder.Services.AddCors(c => c.AddPolicy("ngApp", options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

//Add DB Context 
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PC_Windows")));

//Add UnitOfWork Repositry As Scoped
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Add JWT Service As Scoped
builder.Services.AddScoped<IJWTService, JWTService>();

///Add Auth Service As Scoped
builder.Services.AddScoped<IAuthService, AuthService>();

///Add  Diagram Service As Scoped
builder.Services.AddScoped<DiagramService, DiagramService>();

//Create Map Values From Between JWT Session With JWT CLass
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

//Add Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add JWT Service And Init Confgrations
builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = true;
    o.SaveToken = false;
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issure"],
        ValidAudience = builder.Configuration["JWT:Audince"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };

});

var app = builder.Build();

//Use Cors
app.UseCors("ngApp");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
