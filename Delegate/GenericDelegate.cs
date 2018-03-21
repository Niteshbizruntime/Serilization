using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvent
{
    /// <summary>
    /// Interest is a public class it contain three Properties P,R,T
    /// "T:DelegatesAndEvent.Interest"
    /// </summary>
   public class Interest
    {
        /// <summary>
        /// 
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double T { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double R { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
   public class GenericDelegate
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Calculation));
        /// <summary>
        /// 
        /// </summary>
        public static Interest obj;
        /// <summary>
        /// 
        /// </summary>
        public static double SI;
        delegate double CalculateSimpleInterest(double para1, double para2, double para3);

             
         public   Func<Interest, double> calcSI = SIObj => (SIObj.P * SIObj.T * SIObj.R) / 100;
    
            Action<double> MyAction = y => Console.Write(y);

           public  Predicate<double> check = d => Valid(d);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
           public static bool Valid(double d)
          {
            return SI == d;
          }

        /// <summary>
        /// 
        /// </summary>
        public void GetValue()
        {try
            {
                Console.Write("Enter value of P : ");
                obj.P = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value of T : ");
                obj.T = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value of R : ");
                obj.R = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException ex)
            { log.Info(ex.Message); }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisplayResult()
        {
            Console.Write("Total Interest of ${0} in {1} year at rate of {2}% APR is ", obj.P, obj.T, obj.T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            GenericDelegate gd = new GenericDelegate();
            obj = new Interest();
            gd.GetValue();
            
            SI = gd.calcSI(obj);
            gd.DisplayResult();
            gd.MyAction(SI);
            Console.ReadKey();
        }
    }

    
   
}
