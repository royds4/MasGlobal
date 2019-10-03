using MasGlobal.BusinessLogic.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.BusinessLogic.Entities
{
    public class MonthlySalaryContract : ISalaryContract
    {
        public MonthlySalaryContract(decimal monthlySalary)
        {
            MonthlySalary = monthlySalary;
        }
        public decimal MonthlySalary { get; private set; }
        public decimal CalculateAnnualSalary()
        {
            return MonthlySalary * 12;
        }
    }
}
