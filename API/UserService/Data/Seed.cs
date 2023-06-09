using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Entities;

namespace UserService.Data
{
  public class Seed
  {
    public static async void SeedData(IApplicationBuilder app)
    {
      using var serviceScope = app.ApplicationServices.CreateAsyncScope();
      await SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
    }

    private static async Task SeedData(DataContext? context)
    {
      if (await context.Users.AnyAsync())
      {
        return;
      }

      context.Users.AddRange(
        new AppUser() { FirstName = "Ahmed" },
        new AppUser() { FirstName = "Mohamed" }
      );

      context.SaveChanges();
    }
  }
}