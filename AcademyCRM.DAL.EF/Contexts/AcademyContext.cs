using AcademyCRM.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Contexts
{
    public class AcademyContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<StudentGroup> StudentGroups { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Topic> Topics { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<StudentRequest> StudentRequests { get; set; } = default!;

        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
