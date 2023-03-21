using Draw.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Draw.Core.Repositories;
using Draw.EF;
using Draw.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Draw.BLL.AuthBLL;
using Draw.BLL.DiagramBLL;

var builder = WebApplication.CreateBuilder(args);

//Add Cors And Create Policy For Ng App
builder.Services.AddCors(c =>c.AddPolicy("ngApp", options =>options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

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
