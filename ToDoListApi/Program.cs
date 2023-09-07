using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// herhangi bir sitede bu apinin kullanýlmöasýný izin ver diyoruz.
builder.Services.AddCors(s => s.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(ob => ob.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
