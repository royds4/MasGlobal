using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Presentation.Models
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
        public int? SelectedEmployeeId { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
