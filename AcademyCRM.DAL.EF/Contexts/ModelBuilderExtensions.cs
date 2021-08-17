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
            var topic1 = new Topic()
            {
                Id = 1,
                Title = ".Net",
                Description = ".Net (ASP.NET, Unity)"
            };
            var topic2 = new Topic()
            {
                Id = 2,
                Title = "Java",
                Description = "Full-stack, JS, Spring"
            };
            modelBuilder.Entity<Topic>().HasData(topic1, topic2);

            var course1 = new Course()
            {
                Id = 10, 
                Title = "Introduction to C#", 
                Description = "Introduction to C#",
                Program = "1. Getting Started",
                TopicId = 1
            };

            var course2 = new Course()
            {
                Id = 11,
                Title = "Introduction to Java",
                Description = "Introduction to Java",
                Program = "1. Getting Started",
                TopicId = 2
            };

            var course3 = new Course()
            {
                Id = 12,
                Title = "ASP.NET",
                Description = "Web with ASP.NET",
                Program = "1. Controllers and MVC",
                TopicId = 1
            };

            var course4 = new Course()
            {
                Id = 13,
                Title = "Unity",
                Description = "Unity Game Development",
                Program = "1. What is Unity",
                TopicId = 1
            };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4);

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
