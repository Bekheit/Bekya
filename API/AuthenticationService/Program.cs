using AuthenticationService.Data;
using AuthenticationService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<DataContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
  options.Password.RequiredLength = 6;
})
  .AddEntityFrameworkStores<DataContext>();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.Services.CreateScope().ServiceProvider.GetService<DataContext>().Database.MigrateAsync();

app.Run();
