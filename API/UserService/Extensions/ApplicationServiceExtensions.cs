
namespace UserService.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
  {
    services.AddScoped<IUserRepo, UserRepo>();
    services.AddAutoMapper(typeof(Program).Assembly);
    services.AddDbContext<DataContext>(options =>
      options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
    );
    return services;
  }
}
