using MasGlobal.BusinessLogic.Common;
using MasGlobal.BusinessLogic.Interfaces.BusinessLogic;
using MasGlobal.BusinessLogic.Interfaces.BusinessLogic.Employee;
using MasGlobal.BusinessLogic.Interfaces.DataAccess.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static MasGlobal.BusinessLogic.Common.Constants;

namespace MasGlobal.BusinessLogic.Entities
{
    public class Employee:IEmployeeOperations,IEmployeeSalaryCalculations
    {
        private ISalaryContract salaryContract;
        private IEmployeeRepository employeeRepository;

        public Employee(int id, string name, string contractTypeName, decimal hourlySalary, decimal monthlySalary,Role role, IEmployeeRepository employeeRepository)
        {
            Id = id;
            Name = name;
            ContractType = (ContractType)Enum.Parse(typeof(ContractType), contractTypeName);
            Salary = ContractType.Equals(ContractType.HourlySalaryEmployee) ? hourlySalary : monthlySalary;
            RoleId = role.Id;
            Role = role;
            this.employeeRepository = employeeRepository;
            salaryContract = SalaryContractFactory.Build(ContractType, Salary);
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ContractType ContractType { get; private set; }
        public decimal Salary { get; private set; }
        public int RoleId { get; private set; }
        public virtual Role Role { get; private set; }

        public OperationResult Add()
        {
            return employeeRepository.Create(this);
        }


        public Employee Delete()
        {
            return employeeRepository.Remove(Id);
        }

        public OperationResult Edit()
        {
            return employeeRepository.Modify(this);
        }

        public decimal GetAnnualSalary()
        {
            return salaryContract.CalculateAnnualSalary();
        }
    }
}
