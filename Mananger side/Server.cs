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
                // פורט
                Int32 port = 8080;
                // מערך ביטים לקבלת תשובה מהלקוח
                byte[] recived = new byte[1024];
                // סוקט
                IPEndPoint localEndPoint = new IPEndPoint(address, port);
                // יצירת הסוקט
                Socket sender = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                {
                    SendTimeout = 3000
                };
                // חיבור ללקוח
                sender.Connect(localEndPoint);
                // קידוד הרשימה למערך של ביטים
                byte[] messageSent = Encoding.ASCII.GetBytes(blockingList);
                // שליחה של המערך וקבלה של גודל המערך שנשלח ללקוח
                int byteSent = sender.Send(messageSent);
                // מערך ביטים לשמירת ההודעה מהלקוח
                byte[] messageReceived = new byte[16];
                // קבלה של ההודעה מהלקוח
                sender.Receive(messageReceived);
                // שמירה של ההודעה מהלקוח
                int recivedMSG = int.Parse(Encoding.ASCII.GetString(messageReceived));
                // סגירת הסוקט
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                // במידה והלקוח קיבל את הרשימה, יוחזר אמת, אחרת יוחזר שקר
                return recivedMSG == 1;
            }
            catch { }
            return false;
        }
    }
}
