using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace NewProject
{
    
    /// <summary>
    /// Program is a publis class 
    /// ID string generated is "T:NewProject.Program". 
    /// </summary>
    public class Program
    {
        /// <summary>
     /// I field take int value
     /// ID string generated is "F:NewProject.Program.i".
     /// </summary>
        int i;

        /// <summary>
        /// J field take int value
        /// ID string generated is "F:NewProject.Program.j".
        /// </summary>
        int j;

      
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// Divide Method take two argument and return int value
        /// ID string generated is "M:NewProject.Program.Divide(System.Int32,System.Int32)".
        /// </summary>
        /// <param name="i">First Number</param>
        /// <param name="j">Second Number</param>
        /// <returns>return integer Value</returns>
        public int Divide(int i,int j)
        {
            int c=0;
            BasicConfigurator.Configure();
            try
            {
                if (j == 0)
                    throw new DivideByZeroException("Value should be grater than zero");
                c = i / j;
                return c;
            }
            catch(DivideByZeroException ex)
            {
                log.Error(ex.Message);
                return c;
            }
            
        }

        /// <summary>
        ///  Method GetData-It take values from Console
        /// ID string generated is "M:NewProject.Program.GetData()".
        /// </summary>
        public void GetData()
        {
            BasicConfigurator.Configure();
            x:
            try
            {
                Console.Write("Enter First Number : ");
                i = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                log.Error(ex.Message); goto x;
            }

            y:
            try
            {
                Console.Write("Enter Second Number : ");
                j = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                log.Error(ex.Message); goto y;
            }
           
        }

        /// <summary>
        ///  Method Main-It is entry point of Program
        ///  ID string generated is "M:NewProject.Program.Main(System.string[])".
        /// </summary>
        /// <param name="args">string array</param>
        static void Main(string[] args)
        {
            Program p= new Program(); 
            p.GetData();
            int k=p.Divide(p.i, p.j);
            Console.Write("Result : " + k);
            Console.Read();
        }
    }
}
