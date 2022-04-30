using Esperanza.Api.Config;
using Esperanza.Core.Models.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Authentication
//builder.Services.AddAuthentication("AdAuthentication")
//    .AddScheme<AuthenticationSchemeOptions, AdAuthenticationHandler>("AdAuthentication", null);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
