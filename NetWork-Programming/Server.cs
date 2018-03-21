using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ServerProgram
{


    class Server
    {
        static Byte[] Buffer { get; set; }
        static Socket sck;
        static Socket Accepted;
        static void Connection()
        {
            Console.WriteLine("Server");
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
            sck.Listen(1);
            Console.WriteLine("The server is running at port 1234...");
            Console.WriteLine("Waiting for a connection.....");

            Accepted = sck.Accept();
            Console.WriteLine("Connection accepted from " + Accepted.RemoteEndPoint);

            Byte[] con = Encoding.Default.GetBytes("Connected Successfull");
            Accepted.Send(con, 0, con.Length, 0);
        }

        static void Operation()
        {
            String str = "", str2 = "";
            while (!str.Equals("stop"))
            {
                Buffer = new Byte[Accepted.SendBufferSize];
                int bytesread = Accepted.Receive(Buffer);
                Byte[] formattd = new Byte[bytesread];
                for (int i = 0; i < bytesread; i++)
                {
                    formattd[i] = Buffer[i];
                }
                str = Encoding.ASCII.GetString(formattd);
                Console.WriteLine("client says: " + str);
                Console.Write("Enter Text : ");
                str2 = Console.ReadLine();
                Byte[] buf = Encoding.Default.GetBytes(str2);
                Accepted.Send(buf, 0, buf.Length, 0);
                Console.WriteLine("Send Successfull");

            }
        }
        static void Main(string[] args)
        {
            Connection();
            Operation();
            Console.Read();
            sck.Close();
            Accepted.Close();
        }


    }


}
