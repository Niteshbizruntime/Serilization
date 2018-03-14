using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{
    public class Employee
    {
        [XmlElement("EmployeeName")]
        public string Name { get; set; }
        [XmlElement("EmployeeAge")]
        public int Age { get; set; }
        [XmlElement("Address")]
        public string Address { get; set; }

    }
    class XmlSerialization3
    {
        static void GetEmployeeDetails(out Employee[] emp)
        {
            Console.WriteLine("Enter Number of Record U Want to Enter : ");
            int n = Convert.ToInt32(Console.ReadLine());
            emp = new Employee[n];
            for (int i = 0; i < n; i++)
            {
                emp[i] = new Employee();
                Console.Write("Enter Name : ");
                emp[i].Name = Console.ReadLine();
                Console.Write("Enter Age : ");
                emp[i].Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Address : ");
                emp[i].Address = Console.ReadLine();
                Console.WriteLine("");
            }
        }

        static void CallSerialization()
        {
            Employee[] emp;
            GetEmployeeDetails(out emp);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee[]));

            TextWriter writer = new StreamWriter(@"EmployeeRecord.xml");

            xmlSerializer.Serialize(writer, emp);

            writer.Close();

        }
        static void CallDeSerialization()
        {
            StreamReader file = null;
            try
            { 
            XmlSerializer reader = new XmlSerializer(typeof(Employee[]));
            file = new StreamReader(@"EmployeeRecord.xml");
            Employee[] obj = (Employee[])reader.Deserialize(file);
            Console.WriteLine("Employee Details After Deserilization:");
            foreach (var emp in obj)
            {
                Console.WriteLine("Employee Name    : " + emp.Name);
                Console.WriteLine("Employee Age     : " + emp.Age);
                Console.WriteLine("Employee Address : " + emp.Address);
                Console.WriteLine("");
            }
            }
            catch (FileNotFoundException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
        static void Main(string[] args)
        {
            
            CallSerialization();
            CallDeSerialization();
            Console.Read();
        }
    }
}
