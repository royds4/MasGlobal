using MasGlobal.BusinessLogic.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.BusinessLogic.Entities
{
    public class HourlySalaryContract : ISalaryContract
    {
        public HourlySalaryContract(decimal hourlySalary)
        {
            HourlySalary = hourlySalary;
        }
        public decimal HourlySalary { get; private set; }
        public decimal CalculateAnnualSalary()
        {
            return 120 * HourlySalary * 12;
        }
    }
}
