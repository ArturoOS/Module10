using Newtonsoft.Json;
using Serialization.BinaryICloneable;
using Serialization.BinaryISerializable;
using Serialization.BinarySerialization;
using Serialization.JsonSerialization;
using Serialization.XMLSerialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySerialization();

            JsonSerialization();

            XMLSerialization();

            BinaryISerializable();

            BinaryCloneSerialization();
        }

        public static void  BinarySerialization() 
        {
            List<BEmployee> employees = new List<BEmployee>
            {
                new BEmployee(){EmployeeName="BEmloyee1"},
                new BEmployee(){EmployeeName="BEmloyee2"},
                new BEmployee(){EmployeeName="BEmloyee3"}
            };
            BDepartment department = new BDepartment()
            {
                DepartmentName = "BinaryDepartment",
                Employees = employees
            };

            // BinarySerialization
            using (FileStream fs = new FileStream("BinarySerialization.txt", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, department);
            }

            // BinaryDeserialization
            using (FileStream fs = new FileStream("BinarySerialization.txt", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                BDepartment departmentDes = (BDepartment)formatter.Deserialize(fs);
            }
        }
        public static void JsonSerialization()
        {
            List<JEmployee> employees = new List<JEmployee>
            {
                new JEmployee(){EmployeeName="JEmloyee1"},
                new JEmployee(){EmployeeName="JEmloyee2"},
                new JEmployee(){EmployeeName="JEmloyee3"}
            };
            JDepartment department = new JDepartment()
            {
                DepartmentName = "JsonDepartment",
                Employees = employees
            };

            // JsonSerialization
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/JsonSerialization.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, department);
            }

            // JsonDeserialization
            string jsonDepartment = File.ReadAllText(Environment.CurrentDirectory + "/JsonSerialization.txt");
            JDepartment departmentDes = JsonConvert.DeserializeObject<JDepartment>(jsonDepartment);
        }
        public static void XMLSerialization()
        {
            List<XEmployee> employees = new List<XEmployee>
            {
                new XEmployee(){EmployeeName="XEmloyee1"},
                new XEmployee(){EmployeeName="XEmloyee2"},
                new XEmployee(){EmployeeName="XEmloyee3"}
            };
            XDepartment department = new XDepartment()
            {
                DepartmentName = "JsonDepartment",
                Employees = employees
            };

            // XMLSerialization
            XmlSerializer serializer = new XmlSerializer(typeof(XDepartment));
            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/XMLSerialization.txt")) 
            {
                serializer.Serialize(sw, department);
            }

            // XMLDeserialization
            XDepartment departmentDes;
            using (Stream reader = new FileStream(Environment.CurrentDirectory + "/XMLSerialization.txt", FileMode.Open))
            {
                departmentDes = (XDepartment)serializer.Deserialize(reader);
            }
        }
        public static void BinaryISerializable()
        {
            List<BIEmployee> employees = new List<BIEmployee>
            {
                new BIEmployee(){EmployeeName="BIEmloyee1",EmployeeLastName="LastName1"},
                new BIEmployee(){EmployeeName="BEmloyee2",EmployeeLastName="LastName2"},
                new BIEmployee(){EmployeeName="BEmloyee3",EmployeeLastName="LastName3"}
            };

            // BinarySerialization
            using (FileStream fs = new FileStream("BinaryISerializable.txt", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, employees);
            }
        }
        public static void BinaryCloneSerialization()
        {
            List<BCEmployee> employees = new List<BCEmployee>
            {
                new BCEmployee(){EmployeeName="BCEmloyee1"},
                new BCEmployee(){EmployeeName="BCEmloyee2"},
                new BCEmployee(){EmployeeName="BCEmloyee3"}
            };
            BCDepartment department = new BCDepartment()
            {
                DepartmentName = "BinaryDepartment",
                Employees = employees
            };

            BCDepartment departmentClone = department.Clone() as BCDepartment;

            department.DepartmentName = "OriginalDepartment";
            Console.WriteLine("Original Department: " + department.DepartmentName);
            Console.WriteLine("Clone Department: " + departmentClone.DepartmentName);
            Console.ReadLine();
        }
    }
}
