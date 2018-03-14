using log4net.Config;
using System;
using System.IO;
using System.Xml.Serialization;


namespace NewProject
{

    /// <summary>
    /// Student Record is a class it contain fields and property
    /// Generated Id is "T:NewProject.StudentRecord"
    /// </summary>
    public class StudentRecord
    {
        

        [XmlIgnore]
        /// <summary>
        /// Name is a  property ,Used to get and set Name Value and return string
        /// Generated Id is "P:NewProject.StudentRecord.Name"
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// Add is a  property ,Used to get and set Address Value and return string
        /// Generated Id is "P:NewProject.StudentRecord.Add"
        /// </summary>
        public string Add { get; set; }

    }


    /// <summary>
    /// XmlSerialization1 is a main Class
    /// Generated Id is "T:NewProject.XmlSerialization"
    /// </summary>
    public class XmlSerialization2
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// CallSerialization is a method to Perform Serialization
        /// non argument method
        /// Generated Id is "M:NewProject.XmlSerialization1.CallSerialization()"
        /// </summary>
        public void CallSerialization(StudentRecord sObject)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentRecord));
            TextWriter writer = new StreamWriter(@"StudentRecord.xml");
            xmlSerializer.Serialize(writer, sObject);
            Console.WriteLine("Serilization Successful");
            writer.Close();

        }

        /// <summary>
        /// CallDeSerialization is a method to Perform DeSerialization
        /// non argument method
        /// Generated Id is "M:NewProject.XmlSerialization1.CallDeSerialization()"
        /// </summary>
        public StudentRecord CallDeSerialization()
        {
            BasicConfigurator.Configure();
            StreamReader file = null;
            StudentRecord obj;
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(StudentRecord));
                file = new StreamReader(@"StudentRecord.xml");
                obj = (StudentRecord)reader.Deserialize(file);
                return obj;
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex.Message);
                return null;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        /// <summary>
        /// GetData is argumented method take onr argument
        /// Generated Id is "M:NewProject.XmlSerialization1.GetData(argument)
        /// </summary>
        /// <param name="sObject"></param>
        public void GetData(out StudentRecord sObject)
        {
            sObject = new StudentRecord();
            Console.WriteLine("Enter Student Record : ");
            Console.Write("Student Name    : ");
            sObject.SName = Console.ReadLine();
            Console.Write("Address         : ");
            sObject.Add = Console.ReadLine();
        }

        /// <summary>
        /// DisplayData is argumented method take onr argument
        /// Generated Id is "M:NewProject.XmlSerialization1.DisplayData(argument)
        /// </summary>
        /// <param name="obj"></param>
        public void DisplayData(StudentRecord obj)
        {
            Console.WriteLine("Student Record After Deserilization:");
            Console.WriteLine("Name : " + obj.SName);
            Console.WriteLine("Address : " + obj.Add);
        }

       

        /// <summary>
        /// Main Method
        /// Generated Id is "M:NewProject.XmlSerialization1.Main(System.string[])"
        /// </summary>
        /// <param name="args"> string Array</param>
        static void Main(string[] args)
        {
            XmlSerialization2 xmlSer = new XmlSerialization2();
            StudentRecord serobj; 
            xmlSer.GetData(out serobj);
            xmlSer.CallSerialization(serobj);
            StudentRecord deserobj =xmlSer.CallDeSerialization();
            xmlSer.DisplayData(deserobj);
            Console.Read();


        }
    }
  
}
