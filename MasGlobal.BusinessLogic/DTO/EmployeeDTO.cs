using MasGlobal.BusinessLogic.Interfaces.DataAccess.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using static MasGlobal.BusinessLogic.Common.Constants;

namespace MasGlobal.BusinessLogic.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }

        public Entities.Employee MapDTOtoEntity(IEmployeeRepository repository)
        {        
            var role = new Entities.Role(RoleId,RoleName,RoleDescription);
            return new Entities.Employee(Id, Name, ContractTypeName, HourlySalary, MonthlySalary, role, repository);
        }
    }
}
