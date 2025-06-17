using DotNetEnv;
using Ticketing.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

string connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ??
                          throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured properly.");

builder.Services.AddApplicationServices(connectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
