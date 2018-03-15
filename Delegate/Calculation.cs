using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
namespace DelegatesAndEvent
{
    public delegate int Calculator(int n);     
   public class Calculation
    {
        
       static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Calculation));
       public  static int number;
            public static int Add(int n)
            {
                number = number + n;
                return number;
            }
            public static int Mul(int n)
            {
                number = number * n;
                return number;
            }
            public static int GetNumber()
            {
                return number;
            }

            public static void Main(string[] args)
            {
                BasicConfigurator.Configure();
                log.Info("Enter Number : ");
                number = Convert.ToInt32(Console.ReadLine());
                Calculator c1 = new Calculator(Add); 
                Calculator c2 = new Calculator(Mul);
                log.Info("\nEnter Number U want to add with First Number: ");
                c1(Convert.ToInt32(Console.ReadLine()));
                log.Info("\nAfter Addition, Number is: " + GetNumber());
                log.Info("\nEnter Number U want to Multiply with Output Number: ");
                c2(Convert.ToInt32(Console.ReadLine()));
                log.Info("\nAfter Multiplication, Number is: " + GetNumber());
                Console.Read();
            }
        }
    
}
