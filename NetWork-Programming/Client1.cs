using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientProgram
{
    class Client1
    {
        static Socket sck;
        static string name = "";
        static IPAddress ip;
        static int port = 9000;
        static Thread rec;
        static string inputPort;

        static void GetData()
        {
            Console.WriteLine("Please Enter your Name : ");
            name = Console.ReadLine();
            Console.Write("Please Enter IP Address of Server: ");
            ip = IPAddress.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Port");
            string inputPort = Console.ReadLine();
        }

        static void Connection()
        {
            try
            {
                port = Convert.ToInt32(inputPort);
            }
            catch
            { port = 9000; }

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Connecting.....");

            IPEndPoint ed = new IPEndPoint(ip, port);

            try
            {
                sck.Connect(ed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected.....");
        }

        static void recv()
        {
            while (true)
            {
                Thread.Sleep(500);
                byte[] Buffer = new byte[255];
                int rec = sck.Receive(Buffer, 0, Buffer.Length, 0);
                Array.Resize(ref Buffer, rec);
                Console.WriteLine(Encoding.Default.GetString(Buffer));
            }
        }

        static void Operation()
        {

            rec = new Thread(recv);
            rec.Start();
         //   byte[] conmsg = Encoding.Default.GetBytes("<" + name + ">" + "Connected");
          //  sck.Send(conmsg, 0, conmsg.Length, 0);
            string str = "Connected";
            while (sck.Connected)
            {
                if(str.Equals("exit"))
                { sck.Close(); break; }
                byte[] sData = Encoding.Default.GetBytes("<" + name + ">" +str);
                sck.Send(sData, 0, sData.Length, 0);
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