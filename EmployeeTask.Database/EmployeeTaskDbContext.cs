
using Microsoft.EntityFrameworkCore;
using EmployeeTask.Models.Entities;

namespace EmployeeTask.Database
{
    public class EmployeeTaskDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskEnt> Tasks { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public EmployeeTaskDbContext(DbContextOptions<EmployeeTaskDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Tasks)
                .IsRequired();

            modelBuilder.Entity<TaskEnt>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskEnt>()
               .Property(t => t.Title)
               .IsRequired();

            modelBuilder.Entity<TaskEnt>()
                .Property(t => t.Assingnees)
                .IsRequired();

            modelBuilder.Entity<Meeting>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Meeting>()
                .Property(m => m.Subject)
                .IsRequired();
            modelBuilder.Entity<Meeting>()
                .Property(m => m.Atendees)
                .IsRequired();

            //modelBuilder.Entity<Meeting>()
            //     .Property(m => m.Duration)
            //     .HasComputedColumnSql("[EndTime] - [StartTime]");

        }
    }
}
