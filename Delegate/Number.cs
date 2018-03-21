using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvent
{
    /// <summary>
    /// MyClass3 is a public Class 
    /// "T:DelegatesAndEvent.MyClass3"
    /// </summary>
    public class MyClass3
    {
        public delegate void Operation(string message);

        public event Operation operation;

        /// <summary>
        /// this method perform squar operation
        /// "M:DelegatesAndEvent.MyClass3.Square(System.Integer)"
        /// </summary>
        /// <param name="num">it takes integer value</param>
        public void Square(int num)
        {
            if (operation != null)
                operation("\nSquare Formula(X^2=X*X)");

            Console.WriteLine("Square Of {0} is {1}", num,(num*num));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">it takes integer value</param>
        public void Cube(int num)
        {
            if (operation != null)
                operation("\nCube Formula(X^3=X*X*X)");

            Console.WriteLine("Cube of {0} is {1}", num,(num*num*num));
        }

      
    }

    /// <summary>
    /// Number Class Contain Main Method
    /// "T:DelegatesAndEvent.Number"
    /// </summary>
   public class Number
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Calculation));
        /// <summary>
        /// myClass is a private reference variable of MyClass3
        /// "F:DelegatesAndEvent.Number.myClass"
        /// </summary>
        private MyClass3 myClass;

        /// <summary>
        /// value is a private int type field
        /// "F:DelegatesAndEvent.Number.value"
        /// </summary>
        private int value;

        /// <summary>
        /// Number is a Constructor without argument used to initilize field
        /// "M:DelegatesAndEvent.Number.Number()"
        /// </summary>
        /// <param name="val">val is int type</param>
        public Number(int val)
        {
            value = val;
            myClass = new MyClass3();
            myClass.operation += Event;
        }

        /// <summary>
        /// Event is a method with no return type
        /// "M:DelegatesAndEvent.Number.Event(System.String)"
        /// </summary>
        /// <param name="message">messege is string type</param>
        void Event(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// PrintSquare method is used to perform square
        /// "M:DelegatesAndEvent.Number.PrintSquare()"
        /// </summary>
        public void PrintSquare()
        {
            myClass.Square(value);
        }

        /// <summary>
        /// PrintCube method is used to perform Cube
        /// "M:DelegatesAndEvent.Number.PrintCube()"
        /// </summary>
        public void PrintCube()
        {
            myClass.Cube(value);
        }

        /// <summary>
        /// Main method contain String array as Argument
        /// "M:DelegatesAndEvent.Number.Main(System.String[])"
        /// </summary>
        /// <param name="args">it is a string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            i:
            try
            {
                Console.Write("Enter Number : ");
                int n = Convert.ToInt32(Console.ReadLine());
                Number myNumber = new Number(n);
                myNumber.PrintSquare();
                myNumber.PrintCube();
            }
            catch(FormatException ex)
            { log.Error(ex.Message); goto i; }
            Console.Read();
        }
        

    }

}
