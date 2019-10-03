using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Api.Model;
using MasGlobal.BusinessLogic.Entities;
using MasGlobal.BusinessLogic.Interfaces.DataAccess.Employee;
using Microsoft.AspNetCore.Mvc;

namespace MasGlobal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository repository;
        public EmployeesController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {

            var employees = await repository.GetEmployees();
            var modelEmployees = TranslateToConsumabeModel(employees);
            return Ok(modelEmployees);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var employees = await repository.GetEmployees(id);
            var modelEmployee = TranslateToConsumabeModel(employees);
            if (modelEmployee == null || modelEmployee.Count()==0)
                return NotFound();
            return Ok(modelEmployee);
        }

        private IEnumerable<EmployeeModel> TranslateToConsumabeModel(IEnumerable<Employee> employees)
        {
            return employees.Select(employee => new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                ContractTypeName = employee.ContractType.ToString(),
                AnnualSalary = employee.GetAnnualSalary(),
                RoleName = employee.Role.Name,
                Salary = employee.Salary
            }).ToList();
        }
    }
}
