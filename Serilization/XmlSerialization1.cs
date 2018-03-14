using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{
    public class StudentRecord
    {

        private string name;
        private string add;
        [XmlIgnore]
        public string SName { get; set; }
        public string Add { get; set; }
    }




    class XmlSerialization1
    {
        static void CallSerialization()
        {
            StudentRecord sObject = new StudentRecord();
            Console.WriteLine("Enter Student Record : ");
            Console.Write("Student Name    : ");
            sObject.SName = Console.ReadLine();
            Console.Write("Address         : ");
            sObject.Add = Console.ReadLine();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentRecord));
            TextWriter writer = new StreamWriter(@"StudentRecord.xml");
            xmlSerializer.Serialize(writer, sObject);
            Console.WriteLine("Serilization Successful");
            writer.Close();

        }

        static void CallDeSerialization()
        {
            StreamReader file = null;
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(StudentRecord));
                file = new StreamReader(@"StudentRecord.xml");
                StudentRecord obj = (StudentRecord)reader.Deserialize(file);
                Console.WriteLine("Student Record After Deserilization:");
                Console.WriteLine("Name : " + obj.SName);
                Console.WriteLine("Address : " + obj.Add);
            }
            catch (FileNotFoundException ex)
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
