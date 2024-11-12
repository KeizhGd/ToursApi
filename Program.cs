using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using slothlandapi.Contexts;
using slothlandapi.Services.AuthService;
using slothlandapi.Services.ClientService;
using slothlandapi.Services.TourService;
using slothlandapi.Services.ChoferService;
using System.Text;
using slothlandapi.Services.GuiaService;
using slothlandapi.Services.MovilService;
using slothlandapi.Services.TarifaTourService;
using slothlandapi.Services.ServicioService;
using slothlandapi.Services.ZonaService;
using slothlandapi.Services.ProveedoresService;
using slothlandapi.Services.TourOperatorService;
using slothlandapi.Services.TarifaCostoService;

var builder = WebApplication.CreateBuilder(args);



var reglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: reglasCors,
		builder =>
		{
			builder.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
		});
});

builder.Configuration.AddJsonFile("appsettings.json");
var secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretkey);

builder.Services.AddAuthentication(config =>
{
	config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
	config.RequireHttpsMetadata = false;
	config.SaveToken = true;
	config.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ClockSkew = TimeSpan.Zero
	};
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ConnectionSQLServer>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSQL")));
builder.Services.AddDbContext<ConnectionSLSQLServer>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TourConnectionSQL")));


builder.Services.AddScoped<IProveedoresServices, ProveedoresServices>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IMovilServices, MovilServices>();
builder.Services.AddScoped<ITourServices, TourServices>();
builder.Services.AddScoped<IChoferServices, ChoferServices>();
builder.Services.AddScoped<IGuiaServices, GuiaServices>();
builder.Services.AddScoped<ITarifaTourServices, TarifaTourServices>();
builder.Services.AddScoped<IServicioServices, ServicioServices>();
builder.Services.AddScoped<IZonaServices, ZonaServices>();
builder.Services.AddScoped<ITourOperatorServices, TourOperatorServices>();
builder.Services.AddScoped<ITarifaCostoServices, TarifaCostoServices>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(reglasCors);

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
