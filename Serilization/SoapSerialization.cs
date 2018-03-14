using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
namespace Serialization_and_Deserialization
{

    [Serializable()]
    public class UserRecord
    {

        public int id;
        public string name;
        public string address;
        public double salary;
        [NonSerialized()]
        public string gmail;

        public UserRecord()
        {

            Console.WriteLine("Enter User Details ");
            Console.Write("Id      : ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name    : ");
            name = Console.ReadLine();
            Console.Write("Address : ");
            address = Console.ReadLine();
            Console.Write("Salary  : ");
            salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Gamail  : ");
            gmail = Console.ReadLine();


        }


        public void Print()
        {

            Console.WriteLine("Id      : '{0}'", id);
            Console.WriteLine("Name    : '{0}'", name);
            Console.WriteLine("Address : '{0}'", address);
            Console.WriteLine("Salary  : '{0}'", salary);
            Console.WriteLine("Gmail   : '{0}'", gmail);
        }
    }
    public class SoapSerialization
    {
        static void CallSerialization()
        {
            UserRecord obj = new UserRecord();
            Console.WriteLine("Before serialization the object contains: ");
            obj.Print();
            Stream stream = File.Open("UserRecord.xml", FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        static void CallDeSerialization()
        {
            Stream stream = null;
            try
            { 
             stream = File.Open("UserRecord.xml", FileMode.Open);
            SoapFormatter formatter = new SoapFormatter();
            UserRecord obj = (UserRecord)formatter.Deserialize(stream);
            Console.WriteLine("");
            Console.WriteLine("After deserialization the object contains: ");
            obj.Print();
            }
            catch (FileNotFoundException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        public static void Main()
        {
            CallSerialization();
            CallDeSerialization();
            Console.Read();
           
        }
    }


  
   
}
