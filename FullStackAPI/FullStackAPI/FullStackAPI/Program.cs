using FullStackAPI.Extensions;
using FullStack.Service.Services;
using NLog;
using Microsoft.EntityFrameworkCore;
using FullStack.Repo.Data;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LoggerManager logger = new LoggerManager();

// Add services to the container.
builder.Services.RegisterDependencies();
builder.Services.ConfigureMapping();
builder.Services.ConfigureLoggerService();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
//var connectionString = builder.Configuration.GetConnectionString("FullStackConnectionString");
//builder.Services.AddDbContext<RepositoryContext>(options => { 
//    options.UseSqlServer(connectionString);
//    options.EnableSensitiveDataLogging(true);}
//);

builder.Services.AddControllers();

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

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();