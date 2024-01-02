using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization.XMLSerialization
{
    [Serializable]
    public class XDepartment
    {
        [XmlElement]
        public string DepartmentName { get; set; }
        [XmlElement]
        public List<XEmployee> Employees { get; set; }
    }
}
