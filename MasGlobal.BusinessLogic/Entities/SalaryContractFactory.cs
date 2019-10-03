using MasGlobal.BusinessLogic.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using static MasGlobal.BusinessLogic.Common.Constants;

namespace MasGlobal.BusinessLogic.Entities
{
    public static class SalaryContractFactory
    {
        public static ISalaryContract Build(ContractType contractType, decimal salary)
        {
            switch (contractType)
            {
                case ContractType.HourlySalaryEmployee:
                    return new HourlySalaryContract(salary);
                    break;
                default:
                    return new MonthlySalaryContract(salary);
                    break;
            }
        }
    }
}
