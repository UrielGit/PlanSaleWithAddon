using PlanSaleWithAddon.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using PlanSaleWithAddon.EFCore.Context;
using PlanSaleWithAddon.Repositories._Interfaces;
using PlanSaleWithAddon.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAddonRepository, AddonRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    //Add JSON Result and Serialize to controllers
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISystemClock, SystemClock>();

//Database conectionString as service
builder.Services.AddDbContext<AppDbContext>(configure =>
{
    configure.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));

});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//Policy - cors
builder.Services.AddCors(configure =>
{
    configure.AddDefaultPolicy(builder =>
    {
        //builder.AllowAnyOrigin()
        builder.WithOrigins("https://multistep-form-with-login-testeapi.vercel.app")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });

});

// JWT
var JWTSettingsSection = builder.Configuration.GetSection("JWTSettings");

builder.Services.Configure<JWTSettings>(JWTSettingsSection);

var JWTSettings = JWTSettingsSection.Get<JWTSettings>();

builder.Services.AddAuthentication(configure => {

    configure.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    configure.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    configure.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(configure => {

    configure.RequireHttpsMetadata = false;
    configure.SaveToken = true;
    configure.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWTSettings:Valid"],
        ValidIssuer = builder.Configuration["JWTSettings:Author"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:Secret"]))
    };

});

//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
