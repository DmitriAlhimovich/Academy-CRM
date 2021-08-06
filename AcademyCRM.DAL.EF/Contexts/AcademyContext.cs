using AcademyCRM.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.DAL.EF.Contexts
{
    public class AcademyContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<StudentGroup> StudentGroups { get; set; } = default!;

        public DbSet<Teacher> Teachers { get; set; } = default!;

        public AcademyContext()
        {
            
        }
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AcademyCrmDb;Trusted_Connection=True;");
        }
    }
}
