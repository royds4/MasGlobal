using MasGlobal.BusinessLogic.Common;
using MasGlobal.BusinessLogic.DTO;
using MasGlobal.BusinessLogic.Entities;
using MasGlobal.BusinessLogic.Interfaces.DataAccess.Employee;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static MasGlobal.BusinessLogic.Common.Constants;

namespace MasGlobal.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public OperationResult Create(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployees(int? id = null)
        {
            var result = new List<Employee>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(SourceApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeDTO>>(content);
                        foreach (var employee in employees.Where(x => x.Id == (id ?? x.Id)))
                        {
                            result.Add(employee.MapDTOtoEntity(this));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
            return result;
        }

        public OperationResult Modify(Employee modifiedEmployee)
        {
            throw new NotImplementedException();
        }

        public Employee Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
