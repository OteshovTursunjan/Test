
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess
{
    public  class DatabaseContextSeed
    {
        public static async Task SeedDatabaseAsync(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser { FirstName = "Tony", LastName = "SS", UserName = "admin", Email = "admin@admin.com", EmailConfirmed = true };
                await userManager.CreateAsync(user, "Admin123.?");
            }
            await context.SaveChangesAsync();
        }
    }
}
