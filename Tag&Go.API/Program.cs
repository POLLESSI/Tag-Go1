using Tag_Go.API.Tools;
using Tag_Go.DAL.Repositories;
using Tag_Go.DAL.Interfaces;
using Tag_Go.BLL;
using Tag_Go.BLL.Services;
using Tag_Go.API.Hubs;
using System.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Tag_Go.Models.Services;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Tag_Go.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(o => o.AddPolicy("mypolicy", options => options.WithOrigins("http://localhost:7168"/*, "http://localhost:"*/)
//                        .AllowCredentials()
//                        .AllowAnyHeader()
//                        .AllowAnyMethod()));

builder.Services.AddCors();

// SqlConnection

builder.Services.AddScoped<SqlConnection>(Sc => new SqlConnection(builder.Configuration.GetConnectionString("default")));

// Injections

builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IAvatarService, AvatarService>();
builder.Services.AddScoped<IAvatarRepository, AvatarRepository>();
builder.Services.AddScoped<IBonusService, BonusService>();
builder.Services.AddScoped<IBonusRepository, BonusRepository>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<INEvenementService, NEvenementService>();
builder.Services.AddScoped<INEvenementRepository, NEvenementRepository>();
builder.Services.AddScoped<INIconService, NIconService>();
builder.Services.AddScoped<INIconRepository, NIconRepository>();
builder.Services.AddScoped<IMapService, MapService>();
builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<IMediaItemService, MediaItemService>();
builder.Services.AddScoped<IMediaItemRepository, MediaItemRepository>();
builder.Services.AddScoped<INUserService, NUserService>();
builder.Services.AddScoped<INUserRepository, NUserRepository>();
builder.Services.AddScoped<IOrganisateurService, OrganisateurService>();
builder.Services.AddScoped<IOrganisateurRepository, OrganisateurRepository>();
builder.Services.AddScoped<INPersonService, NPersonService>();
builder.Services.AddScoped<INPersonRepository, NPersonRepository>();
builder.Services.AddScoped<IRecompenseService, RecompenseService>();
builder.Services.AddScoped<IRecompenseRepository, RecompenseRepository>();
builder.Services.AddScoped<INVoteService, NVoteService>();
builder.Services.AddScoped<INVoteRepository, NVoteRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

// Ajout SignalR

builder.Services.AddSignalR();

// Ajout Hubs

builder.Services.AddSingleton<ActivityHub>();
builder.Services.AddSingleton<AvatarHub>();
builder.Services.AddSingleton<BonusHub>();
builder.Services.AddSingleton<ChatHub>();
builder.Services.AddSingleton<NEvenementHub>();
builder.Services.AddSingleton<NIconHub>();
builder.Services.AddSingleton<MapHub>();
builder.Services.AddSingleton<MediaItemHub>();
builder.Services.AddSingleton<NUserHub>();
builder.Services.AddSingleton<OrganisateurHub>();
builder.Services.AddSingleton<NPersonHub>();
builder.Services.AddSingleton<RecompenseHub>();
builder.Services.AddSingleton<NVoteHub>();
builder.Services.AddSingleton<WeatherForecastHub>();

// Token Generator

builder.Services.AddScoped<TokenGenerator>();

// Secutity levels

//Declaration des différents niveaux de sécurité à mettre en place dans le controller grâce à l'attribut [Authorize("nom_de_la_police")]

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("adminpolicy", option => option.RequireRole("admin"));
    o.AddPolicy("modopolicy", option => option.RequireRole("admin", "modo"));
    o.AddPolicy("userpolicy", option => option.RequireAuthenticatedUser());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenGenerator.secretKey)),
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//name: "default",
//pattern: "{controller-Home}/{action=Index}/Iid?}"
//   );

app.MapControllers();

app.MapHub<ActivityHub>("/activityhub");
app.MapHub<AvatarHub>("/avatarhub");
app.MapHub<BonusHub>("/bonushub");
app.MapHub<ChatHub>("/chathub");
app.MapHub<NEvenementHub>("/nevenementhub");
app.MapHub<NIconHub>("/niconhub");
app.MapHub<MapHub>("/map");
app.MapHub<MediaItemHub>("/mediaitemhub");
app.MapHub<NUserHub>("/nuserhub");
app.MapHub<OrganisateurHub>("/organisateurhub");
app.MapHub<NPersonHub>("/personhub");
app.MapHub<RecompenseHub>("/recompensehub");
app.MapHub<NVoteHub>("/nvotehub");
app.MapHub<WeatherForecastHub>("/weatherforecasthub");

app.Run();
