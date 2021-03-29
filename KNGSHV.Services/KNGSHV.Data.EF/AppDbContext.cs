using KNGSHV.Data.EF.Configurations;
using KNGSHV.Data.Entities;
using KNGSHV.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace KNGSHV.Data.EF
{
    public class AppDbContext : IdentityDbContext<Account, Function, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Function> Functions { get; set; }


        public DbSet<BlogType> BlogTypes { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Learner> Learners { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<LectureSchedule> LectureSchedules { get; set; }

        public DbSet<RegistrationForm> RegistrationForms { get; set; }
        
        public DbSet<Course> Courses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(FunctionConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(BlogTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(BlogConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ClassRoomConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ContactConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(FeedbackConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(LearnerConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(LectureConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(SubjectConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(LectureScheduleConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(RegistrationFormConfiguration).Assembly);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("Permissions");




        }


        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {

            public AppDbContext CreateDbContext(string[] args)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<AppDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new AppDbContext(builder.Options);
            }
        }
    }
}
