using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{
    public class CamereRecord
    {
        [XmlElement("CameraName")]
        public string MakeModel { get; set; }
        [XmlElement("CameraPrice")]
        public string Price { get; set; }
    }

    class XmlSerialization2
    {
        static void CallSerialization()
        {
            CamereRecord sXmlElement = new CamereRecord();
            Console.WriteLine("Enter Camara Detail : ");
            Console.Write("Model Name : ");
            sXmlElement.MakeModel = Console.ReadLine();
            Console.Write("Price      : ");
            sXmlElement.Price = Console.ReadLine();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CamereRecord));
            TextWriter writer = new StreamWriter(@"CamereRecord.xml");
            xmlSerializer.Serialize(writer, sXmlElement);
            writer.Close();

        }
        static void CallDeSerialization()
        {
            StreamReader file = null;
            try
            { 
            XmlSerializer reader = new XmlSerializer(typeof(CamereRecord));
            file = new StreamReader(@"CamereRecord.xml");
            CamereRecord obj = (CamereRecord)reader.Deserialize(file);
            Console.WriteLine("Camera Details After Deserilization:");
            Console.WriteLine("Model Name : " + obj.MakeModel);
            Console.WriteLine("Price : " + obj.Price);
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
