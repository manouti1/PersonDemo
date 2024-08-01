using Microsoft.EntityFrameworkCore;
using PersonalInformationFormApp.Data;
using PersonalInformationFormApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
