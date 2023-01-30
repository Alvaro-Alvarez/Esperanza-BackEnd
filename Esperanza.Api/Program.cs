using AutoMapper;
using Esperanza.Api.Config;
using Esperanza.Api.Helpers;
using Esperanza.Api.Middleware;
using Esperanza.BackgroundTasks;
using Esperanza.Core.MappingProfiles;
using Esperanza.Core.Models.Options;
using Esperanza.Core.Options;
using Hangfire;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapperDependency();

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new PropductSyncMappingProfile());
    m.AddProfile(new CustomerConditionSyncMappingProfile());
    m.AddProfile(new CustomerSyncMappingProfile());
    m.AddProfile(new PriceListSyncMappingProfile());
    //m.AddProfile(new TransportSyncMappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#region Authentication
builder.Services.AddAuthentication("ESPAuthentication")
    .AddScheme<AuthenticationSchemeOptions, ESPAuthenticationHandler>("ESPAuthentication", null);
#endregion

#region Authorization
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin", policy => policy.AddRequirements(new AdminRequirement()));
//    options.AddPolicy("Anunciante", policy => policy.AddRequirements(new AdvertiserRequirement()));
//    options.AddPolicy("Cliente", policy => policy.AddRequirements(new ClientRequirement()));
//});
#endregion

#region Options
builder.Services.Configure<DBOptions>(builder.Configuration.GetSection("DataBase"));
builder.Services.Configure<ImageOptions>(builder.Configuration.GetSection("ImagesPath"));
builder.Services.Configure<GoogleReCaptchar>(builder.Configuration.GetSection("GoogleReCaptchar"));
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JwtBearerTokenSettings"));
builder.Services.Configure<BASApiOptions>(builder.Configuration.GetSection("BASApi"));
builder.Services.Configure<ServicesOption>(builder.Configuration.GetSection("Services"));
builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("EmailOptions"));
#endregion

#region Config Hangfire
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetValue<string>("DataBase:ConnectionString")));
builder.Services.AddHangfireServer();
#endregion

#region Dependency injection
DependencyConfig.AddRegistration(builder.Services);
#endregion

#region Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        builder.SetIsOriginAllowed(_ => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Hook in the global error-handling middleware
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard("/api/hangfire");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapHangfireDashboard();
//});

app.MapControllers();

SchedulerService.Start(builder.Configuration);

app.Run();