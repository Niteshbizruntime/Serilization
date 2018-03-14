using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization_and_Deserialization
{
   [Serializable]
    class Student
    { 
       public int rollNo;
       [NonSerialized]
       public string name;
    }
   
   
    class BinarySerialization
    {
        static void CallSerialization()
        {
            FileStream stream = new FileStream("StudentRecord1.txt", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            Student s = new Student();
            Console.WriteLine("Enter Student Details : ");
            Console.Write("RollNo : ");
            s.rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name : ");
            s.name = Console.ReadLine();
            formatter.Serialize(stream, s);
            stream.Close();
            Console.WriteLine("Serialization Successfull : ");
        }

        static void CallDeSerialization()
        {
            FileStream stream = null;
            try
            { 
             stream = new FileStream("StudentRecord1.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            Student s = (Student)formatter.Deserialize(stream);
            Console.WriteLine("\nStudent Record After Deserialization ");
            Console.WriteLine("Rollno: " + s.rollNo);
            Console.WriteLine("Name: " + s.name);
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

        public static void Main(string[] args)
        {
            CallSerialization();
            CallDeSerialization();
            Console.Read();
        }
    }
}
