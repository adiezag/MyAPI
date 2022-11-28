using Microsoft.EntityFrameworkCore;
using MyNewAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyNewAPIDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
