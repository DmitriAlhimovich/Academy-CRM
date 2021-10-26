using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyCRM.BLL.Services;
using NUnit.Framework;

namespace AcademyCRM.BLL.Tests
{
    public class CourseCategoryServiceTests
    {
        private CourseCategoryService _underTest;

        [SetUp]
        public void Setup()
        {
            _underTest = new CourseCategoryService(null);
        }

        
    }
}
