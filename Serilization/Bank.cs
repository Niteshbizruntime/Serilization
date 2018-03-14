using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{

    public class Balance
    {
        public int balance = 10000;  
    }

    class User
   {
    private string name = "Nitesh";
    private string pin;

    public User()
    {
        Console.WriteLine("  <Welcome " + name+">");
        i:
        Console.Write("Enter 4 Digit Pin : ");
        int pin = Convert.ToInt16(Console.ReadLine());
        if (pin == 5678)
        { Menu(); }
        else
        { Console.WriteLine("Enter Correct Pin "); goto i; }

    }

        static void Menu()
        {
               do
                {
                Console.WriteLine("1. WithDraw ");
                Console.WriteLine("2. Deposite ");
                Console.WriteLine("3. CheckBalance ");

                Console.Write("Enter Choice");
                int n = Convert.ToInt16(Console.ReadLine());
                Balance b = new Balance();
                if (n == 1)
                { WithDraw(); }
                else if (n == 2)
                { Deposite(); }
                else if (n == 3)
                { CheckBalance(); }

                Console.Write("D U want to continue Press 1 : ");
            } while (Convert.ToInt16(Console.ReadLine()) == 1);
        }

        static void WithDraw()
        {
            Console.WriteLine("Enter WithDrawl Amount : ");
            int  bal = Convert.ToInt32(Console.ReadLine());
            Balance b = new Balance();
            b.balance = Bank.CallDeSerialization();
            b.balance = b.balance - bal;
            Bank.CallSerialization(b);
            Console.WriteLine("Collect Money ");
        }

        static void Deposite()
        {
            Console.WriteLine("Enter Money U want to Diposite : ");
            int bal = Convert.ToInt32(Console.ReadLine());
            Balance b = new Balance();
            b.balance = Bank.CallDeSerialization();
            b.balance = b.balance + bal;
            Bank.CallSerialization(b);
            Console.WriteLine("Add Successfull ");
        }

        static void CheckBalance()
        {
            Console.WriteLine("Balance" + Bank.CallDeSerialization());
        }
    }

    class Bank
    {
        public static void CallSerialization(Balance b)
        {
                
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Balance));
            TextWriter writer = new StreamWriter(@"Account.xml");
            xmlSerializer.Serialize(writer, b);
            writer.Close();
        }

       public  static int CallDeSerialization()
        {
            StreamReader file = null;
            try
            { 
            XmlSerializer reader = new XmlSerializer(typeof(Balance));
            file = new StreamReader(@"Account.xml");
            Balance obj = (Balance)reader.Deserialize(file);
            return obj.balance;
            }
            catch (FileNotFoundException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally
            {   if(file!=null)
                file.Close(); }
            return 0;
        }

        static void Main(string[] args)
        {
           
            User user = new User();
            Console.WriteLine("Good Bye");
            Console.Read();
        }
    }
}
