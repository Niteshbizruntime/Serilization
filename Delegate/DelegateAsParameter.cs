using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace DelegatesAndEvent
{
   

    public class DelegateAsParameter
    {
        public static double i;
        public static double j;

        public delegate void Operation(double value);
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(DelegateAsParameter));

        public static double Call(Operation operation, double num)
        {
            operation(num);
            return (i + j);
        }

        public static void PercentIncrease(double num)
        {
            i = i + i * (num / 100);
        }

        public static void PerCentDecrease(double num)
        {
            j = j - j * (num / 100);
        }
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("\nEnter First Number : ");
            i = Convert.ToInt32(Console.ReadLine());
            log.Info("\nEnter Second Number : ");
            j = Convert.ToInt32(Console.ReadLine());
            log.Info("\nSum of First and Second Numbers Before Operation is :" + (i + j));
            log.Info("\nEnter Percent U want to increase and Decrease Numbers : ");
            int first = Convert.ToInt32(Console.ReadLine());
            Operation opp= new Operation(PercentIncrease)+ new Operation(PerCentDecrease);
            Call(opp, first);
            log.Info("\nSum of First and Second Numbers After Operation is :" + (i + j));
            Console.Read();
 
    }

   

   

   
}
}
