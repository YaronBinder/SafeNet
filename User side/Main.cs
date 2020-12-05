using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace UserSide
{
    partial class Server
    {
        readonly static Regex IP = new Regex(@"^[1-9]{1,3}\.[1-9]{1,3}\.[1-9]{1,3}\.[1-9]{1,3}$");
        public static void Main()
        {
            //RunCommand("netsh advfirewall firewall set rule group=\"Network Discovery\" new enable=Yes");
            Thread blockingCycle = new Thread(new ThreadStart(BlockingCycle.CheckFiles));
            blockingCycle.Start();
            SocketListener.StartListening();
        }
 
        /// <summary>
        /// Run the command prompt without visible window
        /// </summary>
        /// <param name="cmd">The command to execute</param>
        public static void RunCommand(string cmd)
        {
            new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    Arguments = "/C " + cmd,
                    Verb = "runas"
                }
            }.Start();
        }
    }
}
