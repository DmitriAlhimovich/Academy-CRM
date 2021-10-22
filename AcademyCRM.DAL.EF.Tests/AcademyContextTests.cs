using System;
using System.Linq;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AcademyCRM.DAL.EF.Tests
{
    public class AcademyContextTests
    {
        private AcademyContext _context;

        [SetUp]
        public void Setup()
        {
            var myDatabaseName = "testDb_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AcademyContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;
            _context = new AcademyContext(options);
        }

        [Test]
        public void Group_Schedule_DeleteCascade()
        {
            //var category = new CourseCategory() {Title = ".net"};
            //context.CourseCategories.Add(category);
            //context.SaveChanges();

            var course = new Course() { Title = "testCourse" };
            _context.Courses.Add(course);
            _context.SaveChanges();



            var group = new StudentGroup() { Title = "testGroup", CourseId = course.Id, };
            _context.StudentGroups.Add(group);
            _context.SaveChanges();

            var sch = new Schedule() { GroupId = group.Id };
            _context.Schedules.Add(sch);
            _context.SaveChanges();


            Assert.AreEqual(1, _context.StudentGroups.ToList().Count);
            Assert.AreEqual(1, _context.Schedules.ToList().Count);


            //act
            _context.StudentGroups.Remove(group);
            _context.SaveChanges();

            //assert
            Assert.AreEqual(0, _context.StudentGroups.ToList().Count);
            Assert.AreEqual(1, _context.Schedules.ToList().Count);
        }
    }
}