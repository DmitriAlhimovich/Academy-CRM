using AcademyCRM.DAL.EF.Repositories;
using NUnit.Framework;

namespace AcademyCRM.DAL.EF.Tests
{
    public class CoursesRepositoryTests
    {
        private CoursesRepository underTest; 

        [SetUp]
        public void Setup()
        {
            underTest = new CoursesRepository()
        }

        [Test]
        public void Filter_WhenTitleContains_ShouldFilter()
        {
            
        }
    }
}