
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alchemy;
using Alchemy.Classes;
using System.Net;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace SoketPrj
{

    class Program
    {
        //protected static ConcurrentDictionary<User, string> OnlineUsers = new ConcurrentDictionary<User, string>();

        static void Main(string[] args)
        {
            var srv = new WebSocketServer(80, IPAddress.Any);
            srv.OnReceive = OnReceive;
            srv.OnSend = OnSend;
            srv.OnConnect = OnConnect;
            srv.OnConnected = OnConnected;
            srv.OnDisconnect = OnDisconnect;
            srv.TimeOut = new TimeSpan(0, 5, 0);
            srv.Start();

        var command = string.Empty;
            while (command != "q")
            {
                command = Console.ReadLine();
            }

            srv.Stop();
        }

        private static void OnDisconnect(UserContext context)
        {
            Console.WriteLine("Client Disconnected :" + context.ClientAddress);
        }

        private static void OnConnected(UserContext context)
        {
            Console.WriteLine("Client Connected From :" + context.ClientAddress);
        }

        private static void OnConnect(UserContext context)
        {
            Console.WriteLine("Connecting From :" + context.ClientAddress);
        }

        private static void OnSend(UserContext context)
        {
            Console.WriteLine("client Connected :" + context.ClientAddress);
        }

        private static void OnReceive(UserContext context)
        {
            Console.WriteLine("Received Data From :" + context.ClientAddress);
        }
    }
}
 