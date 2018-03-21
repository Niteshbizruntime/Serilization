using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerProgram
{


    class Server1
    {
      //  static Byte[] Buffer { get; set; }
        static Socket sck;
        static Socket acc;
        static int port = 9000;
        static Thread rec;
        static IPAddress ip;
        static string name;
        static string inputPort;
        static string GetIp()
        {
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] add = ipEntry.AddressList;
            return add[add.Length - 1].ToString();
        }

        static void GetData()
        {
            Console.WriteLine("Your Local Ip is : " + GetIp());
            Console.WriteLine("Please Enter Your Name ");
            name = Console.ReadLine();
            Console.WriteLine("Please Enter Your Host Port");
            inputPort = Console.ReadLine();
        }

        static void Connection()
        {
            try
            {
                port = Convert.ToInt32(inputPort);
            }
            catch
            { port = 9000; }
            ip = IPAddress.Parse(GetIp());
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(ip, port));
            sck.Listen(0);
            acc = sck.Accept();
            
        }
        static void recv()
        {
            while(true)
            {
                Thread.Sleep(500);
                byte[] Buffer = new byte[255];
                int rec = acc.Receive(Buffer, 0, Buffer.Length, 0);
                Array.Resize(ref Buffer, rec);
                Console.WriteLine(Encoding.Default.GetString(Buffer));
            }
        }

        static void Operation()
        {
            rec = new Thread(recv);
            rec.Start();
            string str = "Connected";
            while (true)
            {
                if(str.Equals("exit"))
                { sck.Close(); break; }
                byte[] sData = Encoding.Default.GetBytes("<" + name + ">" +str );
                acc.Send(sData, 0, sData.Length, 0);
                str = Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            GetData();
            Connection();
            Operation();
            Console.ReadKey();
           
        }


    }


}
