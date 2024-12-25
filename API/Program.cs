using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// link voi data => phan nay thuc ra chua hieu lam 
builder.Services.AddDbContext<DataContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);



// chua dung den 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();



// chua dung den 
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

app.Run();
