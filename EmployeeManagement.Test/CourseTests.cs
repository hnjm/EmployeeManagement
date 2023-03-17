using EmployeeManagement.DataAccess.Entities;
using Xunit;

namespace EmployeeManagement.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseContructor_ConstructCourse_IsNewMustBeTrue()
        {
            //Arrange


            //Act
            var course = new Course("Disaster Management 101");

            //Assert
            Assert.True(course.IsNew);
        }
    }
}
