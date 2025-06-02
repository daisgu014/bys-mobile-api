using BYS.Mobile.API.API.Extensions;
using BYS.Mobile.API.API.TokenHandlers;
using BYS.Mobile.API.Business;
using BYS.Mobile.API.Data;
using BYS.Mobile.API.Data.Extensions;
using BYS.Mobile.API.Data.Profiles;
using BYS.Mobile.API.Service;
using BYS.Mobile.API.Shared.Providers.Abstractions;
using BYS.Mobile.API.Shared.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var settingPath = builder.SetConfigurationPath();
#if !DEBUG
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile(settingPath).Build());
});
#endif
var configSection = builder.Configuration.GetSection("BysMobileAPI");
var setting = configSection.Get<BysMobileAPISetting>();
BysMobileAPISetting.Instance = setting;
builder.Services.AddSingleton(setting);
builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddControllersAsServices();
builder.Services.AddSqlServerDbContext(builder.Configuration);
builder.Services.RegisterAutoMapper();
builder.Services.RegisterRepositoryDependencies();
builder.Services.RegisterServiceDependencies();
builder.Services.RegisterBusinessDependencies();
builder.Services.AddHealthChecks();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(_ => true);
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenHandlers.Clear();
    options.TokenHandlers.Add(new TokenHandler());
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = string.Empty;

            if (context.Request.Query.ContainsKey("access_token"))
            {
                token = context.Request.Query["access_token"];
            }
            
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrWhiteSpace(token) && path.StartsWithSegments("/chat"))
            {
                context.Token = token;
            }

            return Task.CompletedTask;
        },
        OnTokenValidated = ctx =>
        {
            if (ctx.Principal.Identity.IsAuthenticated)
            {
                var provider = ctx.HttpContext.RequestServices.GetService<IIdentityProvider>();
                provider.UpdateIdentity(ctx.Principal);
            }

            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BYS.Mobile.API APIs"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});
var app = builder.Build();
//app.ConfigGlobalException();

if (!setting.Auth.IsProdEnv)
{
    app.UseSwagger(c =>
    {
        c.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(c =>
    {
        var assembly = Assembly.GetEntryAssembly();
        var version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        var date = File.GetLastWriteTimeUtc(assembly.Location);
        c.SwaggerEndpoint("/swagger/v1/swagger.json", $"API - Version: {version} - Date: {date}");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHealthChecks("/health");
app.Run();
