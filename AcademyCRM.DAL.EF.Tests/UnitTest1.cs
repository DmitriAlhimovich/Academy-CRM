using System;
using System.Linq;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AcademyCRM.DAL.EF.Tests
{
    public class Tests
    {
        private AcademyContext context;

        [SetUp]
        public void Setup()
        {
            var myDatabaseName = "testDb_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AcademyContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            context = new AcademyContext(options);
        }

        [Test]
        public void Group_Schedule_DeleteCascade()
        {
            //var category = new CourseCategory() {Title = ".net"};
            //context.CourseCategories.Add(category);
            //context.SaveChanges();

            var course = new Course() { Title = "testCourse" };
            context.Courses.Add(course);
            context.SaveChanges();



            var group = new StudentGroup() { Title = "testGroup", CourseId = course.Id, };
            context.StudentGroups.Add(group);
            context.SaveChanges();

            var sch = new Schedule() { GroupId = group.Id };
            context.Schedules.Add(sch);
            context.SaveChanges();


            Assert.AreEqual(1, context.StudentGroups.ToList().Count);
            Assert.AreEqual(1, context.Schedules.ToList().Count);


            //act
            context.StudentGroups.Remove(group);
            context.SaveChanges();

            //assert
            Assert.AreEqual(0, context.StudentGroups.ToList().Count);
            Assert.AreEqual(1, context.Schedules.ToList().Count);
        }
    }
}