using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.BusinessLogic.Common
{
    public static class Constants
    {
        public const string SourceApiUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        public enum ContractType
        {
            HourlySalaryEmployee,
            MonthlySalaryEmployee
        }
    }
}
