using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.BinaryISerializable
{
    [Serializable]
    internal class BIEmployee : ISerializable
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FullName", this.EmployeeName + this.EmployeeLastName);
        }
    }
}
