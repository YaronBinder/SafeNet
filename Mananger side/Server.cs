using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server_manager
{
    partial class Server
    {
        public static bool SendBlockingList(IPAddress address, string blockingList)
        {
            try
            {
                // port number
                Int32 port = 8080;
                // byte array for storing the recived massage
                byte[] recived = new byte[1024];
                // create new IP end point
                IPEndPoint localEndPoint = new IPEndPoint(address, port);
                // create new socket
                Socket sender = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                {
                    SendTimeout = 3000
                };
                // connect to client
                sender.Connect(localEndPoint);
                // encoding the massage from string to byte array
                byte[] messageSent = Encoding.ASCII.GetBytes(blockingList);
                // sending the message and getting the size of the array
                int byteSent = sender.Send(messageSent);
                // new byte array to store the message recived from the client
                byte[] messageReceived = new byte[16];
                // reciving the message from the client
                sender.Receive(messageReceived);
                // saving the massage from the client as an integer
                int recivedMSG = int.Parse(Encoding.ASCII.GetString(messageReceived));
                // closing the socket
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                // in case of the client send back 1, return true, else return false
                return recivedMSG == 1;
            }
            catch { }
            return false;
        }
    }
}
