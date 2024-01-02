using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.BinarySerialization
{
    [Serializable]
    internal class BDepartment
    {
        public string DepartmentName { get; set; }
        public List<BEmployee> Employees { get; set; }
    }
}
