using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.JsonSerialization
{
    [Serializable]
    internal class JDepartment
    {
        public string DepartmentName { get; set; }
        public List<JEmployee> Employees { get; set; }
    }
}
