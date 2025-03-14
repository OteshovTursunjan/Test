using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Repository.lmpl;
using Test.DataAccess.Repository;
using Test.Shared;
using Tests.Core.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Test.DataAccess;

public static class DataAccessDependesInjcetion
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddIdentity();

        services.AddRepositories();
       
        return services;
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IExamRepository,ExamRepository>();
        services.AddScoped<IExamAttemptRepository,ExamAttemptRepository>();
        services.AddScoped<IFacultyRepository,FacultyRepository>();
        services.AddScoped<IFailRepository,FailRepository>();
        services.AddScoped<IQuestionRepository,QuestionRepository>();
        services.AddScoped<IStudentAsnwerRepository,StudentAnswerRepository>();
        services.AddScoped<IStudentResultRepository,StudentResultRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IStudentAttemptRepository, StudentAttemptRepository>();
        services.AddScoped<IStaticRepository, StaticRepository>();
        services.AddScoped<IExamSessionRepository , ExamSessionRepository>();   
    }
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

        if (databaseConfig.UseInMemoryDatabase)
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("Test");
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
        else
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(databaseConfig.ConnectionString,
                    opt => opt.MigrationsAssembly("Test.DataAccess")));  // Убедитесь, что здесь указана правильная сборка миграций
    }


    private static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }

}
public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }

    public string ConnectionString { get; set; }
}


