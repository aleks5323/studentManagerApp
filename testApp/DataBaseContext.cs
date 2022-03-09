using Microsoft.EntityFrameworkCore;
using testApp.Models;

namespace testApp
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Organization> organizations { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Organization>().ToTable("Organization");
        }
    }
}
