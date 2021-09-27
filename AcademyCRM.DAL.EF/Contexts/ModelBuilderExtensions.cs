using AcademyCRM.Core.Models;
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
                TopicId = 1,
                Price = 1250,
                Level = CourseLevel.Beginner,
                DurationWeeks = 8
            };

            var course2 = new Course()
            {
                Id = 11,
                Title = "Introduction to Java",
                Description = "Introduction to Java",
                Program = "1. Getting Started",
                TopicId = 2,
                Price = 1550,
                Level = CourseLevel.Beginner,
                DurationWeeks = 7
            };

            var course3 = new Course()
            {
                Id = 12,
                Title = "ASP.NET",
                Description = "Web with ASP.NET",
                Program = "1. Controllers and MVC",
                TopicId = 1,
                Price = 1350,
                Level = CourseLevel.Advanced,
                DurationWeeks = 16
            };

            var course4 = new Course()
            {
                Id = 13,
                Title = "Unity",
                Description = "Unity Game Development",
                Program = "1. What is Unity",
                TopicId = 1,
                Price = 1850,
                Level = CourseLevel.Advanced,
                DurationWeeks = 20
            };

            var course5 = new Course()
            {
                Id = 15,
                Title = "Design Patterns",
                Description = "Design Patterns for Software development",
                Program = "1. Decorator, 2. Bridge",
                TopicId = 1,
                Price = 2850,
                Level = CourseLevel.Expert,
                DurationWeeks = 18
            };

            modelBuilder.Entity<Course>().HasData(course1, course2, course3, course4, course5);

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
                TeacherId = teacher1.Id,
                CourseId = course1.Id
            };
            var group2 = new StudentGroup()
            {
                Id = 2,
                Title = "Java_23_4",
                TeacherId = teacher1.Id,
                CourseId = course2.Id
            };
            modelBuilder.Entity<StudentGroup>().HasData(group1, group2);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Oleg",
                    LastName = "Fedorov"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Andrey",
                    LastName = "Antonov"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Ivan",
                    LastName = "Petrov"
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Sergey",
                    LastName = "Ivashko"
                }
            );

        }
    }
}
