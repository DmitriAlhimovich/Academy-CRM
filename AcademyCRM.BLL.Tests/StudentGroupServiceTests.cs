using AcademyCRM.BLL.Services;
using AcademyCRM.Core.Models;
using AcademyCRM.DAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyCRM.BLL.Tests
{
    public class StudentGroupServiceTests
    {
        private Mock<IStudentService> studentService;
        private Mock<IStudentRequestService> requestService;
        private Mock<IRepository<StudentGroup>> repository;

        private StudentGroupService underTest;

        [SetUp]
        public void Setup()
        {
            studentService = new Mock<IStudentService>();
            requestService = new Mock<IStudentRequestService>();
            repository = new Mock<IRepository<StudentGroup>>();

            underTest = new StudentGroupService(
                repository.Object, 
                requestService.Object, 
                studentService.Object);
        }

        [Test]
        public void Create_RequestsByCourse_ShouldBeClosed()
        {
            //arrange
            var testCourseId = 1;
            var testGroupId = 11;

            Student student = new();

            var requests = GenerateRequests(testCourseId, student);

            var group = new StudentGroup { Id = testGroupId, CourseId = testCourseId };

            requestService
                .Setup(x => x.GetOpenRequestsByCourse(It.IsAny<int>()))
                .Returns(requests);

            //act
            underTest.Create(group);

            //assert
            Assert.IsTrue(requests.Where(r => r.CourseId == testCourseId).All(r => r.Status == RequestStatus.Closed));            
        }

        [Test]
        public void Create_Students_ShouldBeAssignedToGroup()
        {
            //arrange
            var testCourseId = 1;
            var testGroupId = 11;

            var student = new Student() { GroupId = null };
            List<StudentRequest> requests = GenerateRequests(testCourseId, student);

            var group = new StudentGroup { Id = testGroupId, CourseId = testCourseId };

            requestService
                .Setup(x => x.GetOpenRequestsByCourse(It.IsAny<int>()))
                .Returns(requests);

            //act
            underTest.Create(group);

            //assert
            Assert.AreEqual(testGroupId, student.GroupId);
        }

        private static List<StudentRequest> GenerateRequests(int courseId, Student student)
        {
            return new List<StudentRequest>() {
                new StudentRequest{Status = RequestStatus.Open, CourseId = courseId, Student = student},
                new StudentRequest{Status = RequestStatus.Open, CourseId = courseId, Student = student},
            };
        }
    }
}
