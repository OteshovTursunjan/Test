using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Enteties;

namespace Test.DataAccess
{
    public  class AutomatedMigration
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<DatabaseContext>();

            if (context.Database.IsNpgsql()) await context.Database.MigrateAsync();

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await DatabaseContextSeed.SeedDatabaseAsync(context, userManager);
        }
    }
}
