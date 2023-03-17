using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using Xunit;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests : IDisposable
    {
        private readonly EmployeeFactory _employeeFactory;

        public EmployeeFactoryTests()
        {
            _employeeFactory = new EmployeeFactory();
        }

        public void Dispose()
        {
            
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            var employeeFactory = new EmployeeFactory();

            var employee = (InternalEmployee) employeeFactory
                .CreateEmployee("Wagner", "Dockx");

            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee) employeeFactory.CreateEmployee("Wagner", "Bolfe");

            // Assert
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee) employeeFactory.CreateEmployee("Wagner", "Bolfe");

            // Assert
            Assert.True(employee.Salary >= 2500);
            Assert.True(employee.Salary <= 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee) employeeFactory.CreateEmployee("Wagner", "Bolfe");

            // Assert
            Assert.InRange(employee.Salary, 2500, 3500);
        }


        [Fact(Skip = "Skipping this one for demo purposes")]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee) employeeFactory.CreateEmployee("Wagner", "Bolfe" );
            employee.Salary = 2500.123m;

            // Assert
            Assert.Equal(2500, employee.Salary, 0);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            // Arrange
            var factory = new EmployeeFactory();

            // Act
            var employee = factory.CreateEmployee("Wagner", "Bolfe", "Marvin", true);

            // Assert
            Assert.IsType<ExternalEmployee>(employee);
            //Assert.IsAssignableFrom<Employee>(employee);
        }

    }
}
