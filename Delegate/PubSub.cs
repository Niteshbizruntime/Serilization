using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvent
{
    /// <summary>
    /// It is a publisher class
    /// "T:DelegatesAndEvent.Publisher"
   /// </summary>
    public class Publisher
    {
        public delegate void Wish(string message);
        public event Wish wish;

        /// <summary>
        /// Date is a static property to get and set string value
        /// "P:DelegatesAndEvent.Publisher.Date"
        /// </summary>
        public static string Date { get; set; }
        /// <summary>
        ///  Name is a static property to get and set string value
        /// "P:DelegatesAndEvent.Publisher.Name"
        /// </summary>
        public static string Name { get; set; }
        /// <summary>
        /// Event method take date as argument
        /// "M:DelegatesAndEvent.Publisher.Event(System.string)"
        /// </summary>
        /// <param name="date">it take string value</param>
        public void Event(string date)
        {
            if (Date.Equals(date))
            {

                if (wish != null)
                    wish("    < Todat is " + Name+" >");
                Console.WriteLine("< Wish You Happy " + Name + " >");
            }
            else
            {
                if (wish != null)
                    wish("  < Todat is Nothing >");
            }
        }

        /// <summary>
        /// /// Message method take message as argument
        /// "M:DelegatesAndEvent.Publisher.Message(System.string)"
        /// </summary>
        /// <param name="message"></param>
        public void Message(string message)
        {
            Console.WriteLine(message);
        }

    }

    /// <summary>
    /// it is a Subscriber Class
    /// "T:DelegatesAndEvent.Subscriber"
    /// </summary>
   public  class Subscriber
    {
        /// <summary>
        /// publisher is a private referance variable of Publisher Class
        /// "F:DelegatesAndEvent.Subscriber.publisher"
        /// </summary>
        private Publisher publisher;
        /// <summary>
        /// date is a string variable
        /// "F:DelegatesAndEvent.Subscriber.date"
        /// </summary>
        public string date;
        /// <summary>
        /// Subscriber is a parameter less constructor
        /// "M:DelegatesAndEvent.Subscriber.Subscriber()"
        /// </summary>
        public Subscriber()
        {
           
            publisher = new Publisher();
            Publisher.Wish wis = new Publisher.Wish(publisher.Message);
            publisher.wish += wis;
        }

        /// <summary>
        /// Message is a Parameter less method
        /// "M:DelegatesAndEvent.Subscriber.Message"
        /// </summary>
        public void Message()
        {
            publisher.Event(date);
        }

    }
    /// <summary>
    /// PubSub class contain main method
    /// "T:DelegatesAndEvent.PubSub"
    /// </summary>
    class PubSub
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Calculation));
        /// <summary>
        /// It ia a main meethod take string arry as argument
        /// </summary>
        /// <param name="args">it is a string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            
            Console.WriteLine("Publisher");
            Console.Write("Enter Date (DD/MM/YYYY): ");
            Publisher.Date = Console.ReadLine();
            Console.Write("Enter Festival Name : ");
            Publisher.Name = Console.ReadLine();
            log.Info("Publisher task Complete");

            Console.WriteLine("\nSubscriber1");
            Subscriber sub = new Subscriber();
            Console.Write("Enter Date : ");
            sub.date = Console.ReadLine();
            sub.Message();
            log.Info("Subscriber1 task Complete");

            Console.WriteLine("\nSubscriber2");
            Subscriber sub1 = new Subscriber();
            Console.Write("Enter Date : ");
            sub1.date = Console.ReadLine();
            sub1.Message();
            log.Info("Subscriber2 task Complete");
            Console.Read();
        }
    }
}