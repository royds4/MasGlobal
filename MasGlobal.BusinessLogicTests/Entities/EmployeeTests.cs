using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasGlobal.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MasGlobal.BusinessLogic.Interfaces.DataAccess.Employee;
using MasGlobal.BusinessLogic.DTO;

namespace MasGlobal.BusinessLogic.Entities.Tests
{
    [TestClass()]
    public class EmployeeTests
    {
        private Mock<IEmployeeRepository> repository;
        [TestInitialize]
        public void InitialConfig()
        {
            repository = new Mock<IEmployeeRepository>();
        }
        [TestMethod()]
        public void GetAnnualSalaryTest_Get_Annual_Calculation_By_HourlyContract()
        {
            //Arrange
            var employeeData = new EmployeeDTO
            {
                Id = 1,
                Name = "Felipe",
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 100,
                MonthlySalary = 3000,
                RoleId = 1,
                RoleDescription = "Tests in APP",
                RoleName = "Tester"
            };
            var employeeEntity = employeeData.MapDTOtoEntity(repository.Object);
            var expected = 144000;
            //Act
            var result = employeeEntity.GetAnnualSalary();
            //Assert
            Assert.AreEqual(expected,result);
        }
    }
}

