using Draw.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Draw.Core.Repositories;
using Draw.EF;
using Draw.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Draw.BLL.Interface;
using Draw.BLL.Service;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Draw.BLL.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

//Add DB Context 
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PC_Windows")));

//Add UnitOfWork Repositry As Transient
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//Add JWT Service As Scoped
builder.Services.AddScoped<IJWTService, JWTService>();

///Add Auth Service As Scoped
builder.Services.AddScoped<IAuthService, AuthService>();

//Create Map Values From Between JWT Session With JWT CLass
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
