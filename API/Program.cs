using API.Entities;
using API.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();

// // link voi data => phan nay thuc ra chua hieu lam 
// builder.Services.AddDbContext<DataContext>(
//     options =>
//     {
//         options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//     }
// );


// // them CORS
// builder.Services.AddCors();

// // them service token 
// builder.Services.AddScoped<ITokenService, TokenService>();



// // them service authentic
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//         .AddJwtBearer(options =>
//                     {
//                         var tokenKey = builder.Configuration["TokenKey"] ?? throw Exception("TokenKey not found! ");
//                         options.TokenValidationParameters = new TokenValidationParameters
//                         {
//                             ValidateIssuerSigningKey = true,
//                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
//                             ValidateIssuer = false,
//                             ValidateAudience = false,
//                         };
//                     });

// static Exception Exception(string v)
// {
//     throw new NotImplementedException();
// };

// viet gon lai cho cac IServiceCollection
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);

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

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
