using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization.XMLSerialization
{
    [Serializable]
    public class XEmployee
    {
        [XmlElement]
        public string EmployeeName { get; set; }
    }
}
