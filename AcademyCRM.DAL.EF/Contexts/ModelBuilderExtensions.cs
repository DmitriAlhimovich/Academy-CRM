using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyCRM.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Vadim",
                LastName = "Korotkov",
                LinkToProfile = "https://www.linkedin.com/feed/"
            };
            var teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Sergey",
                LastName = "Gromov",
                LinkToProfile = "https://www.linkedin.com/feed/"
            };
            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2);

            var group1 = new StudentGroup()
            {
                Id = 1,
                Title = "ASPNET_21_1",
                TeacherId = teacher1.Id
            };
            var group2 = new StudentGroup()
            {
                Id = 2,
                Title = "Java_23_4",
                TeacherId = teacher1.Id
            };
            modelBuilder.Entity<StudentGroup>().HasData(group1, group2);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Oleg",
                    LastName = "Fedorov",
                    GroupId = group1.Id
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Andrey",
                    LastName = "Antonov",
                    GroupId = group1.Id
                }
            );

        }
    }
}
