using AcademyCRM.Core.Models;
using AcademyCRM.DAL.EF.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Contexts
{
    public class AcademyContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseCategory> Topics { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentRequest> StudentRequests { get; set; }

        public DbSet<CourseProgram> CoursePrograms { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseMaterial> CourseMaterials { get; set; }
        public DbSet<CourseTopic> CourseTopics { get; set; }
        public DbSet<StudentToGroupAssignment> StudentAssignments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduledWeeklyLesson> ScheduledWeeklyItems { get; set; }
        public DbSet<StudentVisit> StudentVisits { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasOne(c => c.Program).WithOne(p => p.Course).HasForeignKey<CourseProgram>(p => p.CourseId);
            modelBuilder.Entity<StudentGroup>().HasOne(g => g.Schedule).WithOne(s => s.Group).HasForeignKey<Schedule>(s => s.GroupId);

            modelBuilder.Entity<CourseProgram>().HasMany<CourseTopic>().WithOne().HasForeignKey(t => t.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CourseTopic>().HasMany<CourseMaterial>().WithOne().HasForeignKey(m => m.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentGroup>().HasMany<Lesson>().WithOne().HasForeignKey(l => l.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Lesson>().HasMany<StudentVisit>().WithOne().HasForeignKey(v => v.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>().HasMany<StudentRequest>().WithOne().HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().HasMany<StudentToGroupAssignment>().WithOne().HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().HasMany<StudentVisit>().WithOne().HasForeignKey(v => v.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }
    }
}
