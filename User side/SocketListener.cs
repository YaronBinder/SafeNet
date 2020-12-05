using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace UserSide
{
    partial class Server
    {
        private class SocketListener
        {
            // Incoming data from the client.  
            public static string data = null;

            /// <summary>
            /// Start listening server locali
            /// </summary>
            public static void StartListening()
            {
                // Data buffer for incoming data.  
                byte[] bytes = new Byte[1024];

                // Establish the local endpoint for the socket.  
                // Dns.GetHostName returns the name of the
                // host running the application.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress;
                if (IP.IsMatch(ipHostInfo.AddressList[0].ToString()))
                {
                    ipAddress = ipHostInfo.AddressList[0];
                }
                else
                {
                    ipAddress = ipHostInfo.AddressList[1];
                }

                try
                {
                    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8080);
                    // Create a TCP/IP socket.  
                    Socket listener = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Bind the socket to the local endpoint and
                    // listen for incoming connections.  
                    listener.Bind(localEndPoint);
                    listener.Listen(1);
                    while (true)
                    {
                        // Start listening for connections.
                        // Program is suspended while waiting for an incoming connection.  
                        Socket handler = listener.Accept();
                        data = null;

                        // שומר את ההודעה ושומר את הגודל של הבתים 
                        int bytesRec = handler.Receive(bytes);
                        data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        // שולח פידבק למנהל שההודעה התקבלה
                        handler.Send(Encoding.ASCII.GetBytes("1"));

                        // סוגר את הסוקט
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        WriteBlockingList.Write(data);
                    }
                }
                catch { }
            }
        }
    }
}
