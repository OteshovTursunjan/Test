
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Test.DataAccess;
using Tests.Core.Enteties;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>(options =>
              options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDataAccess(builder.Configuration);
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "User"));
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Admin"));
            });
            builder.Services.AddHttpContextAccessor();

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

            app.Run();
        }
    }
}
