using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tests.Core.Coomon;
using Tests.Core.Enteties;
using Test.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Test.DataAccess.DTOs.Register;

namespace Test.DataAccess;
    public  class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
    private readonly IClaimService _claimService;
    public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    public DbSet<ExamSession> Sessions { get; set; }
    public DbSet<Answer> answers { get; set; }
    public DbSet<Exam> exams        { get; set; }
    public DbSet<ExamAttempt> examAttempts { get; set; }
    public DbSet<ExamLogs> examLogs { get; set; }
    public DbSet<Faculty> faculties     { get; set; }
    public DbSet<Fail> fails { get; set; }
    public DbSet<Question> questions { get; set; }
    public DbSet<StudentAnswer> studentAnswers { get; set; }
    public DbSet<StudentResult> studentResult { get; set; }
    public DbSet<Subject> subjects { get; set; }
    public DbSet<RefreshToken> refreshTokens { get; set; }
    public DbSet<PasswordResetToken> passwordResetTokens { get; set; }
    public DbSet<StudentAttempt> studentAttempts { get; set; }
    public DbSet<Statictis> Statics { get; set;}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
       
    }
    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatBy = _claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdateBY = _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }
        return await base.SaveChangesAsync(cancellationToken);
    }

}

