using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MasGlobal.BusinessLogic.Common;
using MasGlobal.BusinessLogic.Entities;

namespace MasGlobal.BusinessLogic.Interfaces.DataAccess.Employee
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Entities.Employee>> GetEmployees(int? id=null);
        OperationResult Create(Entities.Employee newEmployee);
        OperationResult Modify(Entities.Employee modifiedEmployee);
        Entities.Employee Remove(int id);
    }
}
