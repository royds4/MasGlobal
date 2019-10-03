using MasGlobal.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.BusinessLogic.Interfaces.BusinessLogic.Employee
{
    public interface IEmployeeOperations
    {
        OperationResult Add();
        OperationResult Edit();
        Entities.Employee Delete();
    }
}
