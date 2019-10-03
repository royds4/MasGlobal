using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Presentation.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleName { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}
