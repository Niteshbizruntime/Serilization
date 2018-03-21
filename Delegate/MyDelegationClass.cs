using log4net.Config;
using System;
namespace DelegatesAndEvent
{
    /// <summary>
    /// My Class is a public class
    /// "T:DeledatesAndEvent.MyClass"
    /// </summary>
    public class MyClass
    {

        public delegate void MyDelegate(string message);

        public event MyDelegate MyEvent;
        /// <summary>
        /// message is a string type field
        /// "F:DeledatesAndEvent.MyClass.message"
        /// </summary>
        public readonly string message;

        /// <summary>
        /// MyClass Constructor is used to initilize field
        /// "M:DeledatesAndEvent.MyClass.MyClass()"
        /// </summary>
        public MyClass()
        { 

           this.message = message;

        }

        /// <summary>
        /// Event method is used to perform event
        /// "M:DeledatesAndEvent.MyClass.Event(System.string)"
        /// </summary>
        /// <param name="msg">it is a string argument</param>
        public void Event(string msg)
        {
            if (MyEvent != null)
                MyEvent(msg);
        }

        /// <summary>
        /// Message method contain string Argument
        /// "M:DeledatesAndEvent.MyClass.Message(System.string)"
        /// </summary>
        /// <param name="message">it is a string type</param>
        public void Message(string message)
        {
                Console.WriteLine("\nYour Message is: {0}", message);
        }

    }

    /// <summary>
    /// MyDelegationClass contain main method
    /// "T:DeledatesAndEvent.MyDelegationClass"
    /// </summary>
    class MyDelegationClass

    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Calculation));
        /// <summary>
        /// It is a main Method
        ///" M:DeledatesAndEvent.MyDelegationClass.Main(System.string[])"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)

        {
            BasicConfigurator.Configure();
            MyClass myClass1 = new MyClass();
            myClass1.MyEvent += new MyClass.MyDelegate(myClass1.Message);
            Console.Write("Please enter a message : ");
            string msg = Console.ReadLine();
            myClass1.Event(msg);
            log.Info("Process Complete");
            Console.Read();

        }

      

    }
    
}
