using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvent
{
    public delegate void Call();
    class DelegateDemo1
    {
        private static string name;
        private static int age;
        private static string gender;
        private static string address;

        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(DelegateAsParameter));
       

        public static void GetStudentData()
        {
            log.Info("Enter Student Details");
            log.Info("Student Name    : ");
            name=Console.ReadLine();
            log.Info("Student Age     : ");
            age = Convert.ToInt32(Console.ReadLine());
            log.Info("Student Gender  : ");
            gender = Console.ReadLine();
            log.Info("Student Address : ");
            address = Console.ReadLine();
        }

        public static void DisplayStudentData()
        {
            log.Info("Display Student Details");
            log.Info("Student Name    : "+name);
            log.Info("Student Age     : "+age);
            log.Info("Student Gender  : "+gender);
            log.Info("Student Address : "+address);
        }

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            Call C1;
            Call C2 =new Call( GetStudentData);
            Call C3 = new Call(DisplayStudentData);
            C1 = C2;
            C1 = C1 + C3;
            C1();
            Console.Read();
        }
    }
}
