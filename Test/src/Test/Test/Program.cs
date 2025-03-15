
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;
using Test.Application;
using Test.DataAccess;
using Test.Middleware;
using Tests.Core.Enteties;
using ExceptionHandlerMiddleware = Test.Middleware.ExceptionHandlerMiddleware;
using Quartz;
using Quartz.AspNetCore;
namespace Test;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddQuartz(q =>
        {
            var jobKey = new JobKey("RabbitMqToPostgresJob");

          
            q.AddJob<RabbitMqToPostgresJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
           .ForJob(jobKey)
           .WithIdentity("RabbitMqToPostgresTrigger")
           .WithCronSchedule("0 29 22 * * ?"));
        });

        builder.Services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        builder.Services.AddControllers();
       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));
       
        builder.Services.AddApplication(builder.Environment);
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
        app.UseMiddleware<LoggingMiddleware>();
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseMiddleware<PerformanceMiddleware>();
        app.UseMiddleware<TransactionMiddleware>();
        //app.UseMiddleware<UserIdMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
