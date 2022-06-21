using GenericEFpoc;
using GenericEFpoc.Model;
using GenericEFpoc.Model.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolContext>(options =>
             options.UseInMemoryDatabase("TESTDB"));
builder.Services.AddScoped(typeof(IContextService), typeof(ContextService));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.CreateAndInitializeDbIfNotExists();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
