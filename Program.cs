using Microsoft.EntityFrameworkCore;
using dodik_todolist.Data;

var builder = WebApplication.CreateBuilder(args);

// Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Konfirgurasi HTTP Req
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
