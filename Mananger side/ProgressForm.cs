using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Server_manager
{
    public partial class ProgressForm : Form
    {
        #region Variables

        // visualize the process of scanning the IP addresses
        private int ipCnt = 1;

        // end of network address
        private static readonly int EOA = 254;

        // get this comp name
        private readonly string compName = Dns.GetHostName();

        // connection string to concatenate and pass to the datagridview in form1
        private static string connString;

        // directory path
        readonly string path = Directory.GetCurrentDirectory();

        // reference to form1
        private MainForm Form1Ref { get; set; }

        // default gateway IP
        private readonly string IP = GetDefaultGateway();

        // regex for ip in format if xxx.xxx.xxx.
        private static readonly Regex ipRegex = new Regex(@"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.");

        #endregion

        #region Constractor

        public ProgressForm(MainForm MainInstance, string userFolder)
        {
            InitializeComponent();
            connString = "";
            path += "\\" + userFolder + "\\" + "Computers.txt";
            toolTip1.SetToolTip(CloseBt, "סגור");
            toolTip1.SetToolTip(MinBt, "מזער");
            Form1Ref = MainInstance;
            progressBar1.Maximum = EOA - 1;
            Percentage.Text = "0.0%";
            Percentage.Left = (Width - Percentage.Width) / 2;
            ScanningPrograss.Text = $"סורק כתובת {ipCnt} מתוך {EOA}";
            ScanningPrograss.Left = (Width - ScanningPrograss.Width) / 2;
            Task.Run(async () => await RunScanner());
        }

        #endregion

        // Get the default gateway of this machine
        public static string GetDefaultGateway()
        {
            try
            {
                IPAddress gateway = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                    .Select(g => g?.Address)
                    .Where(a => a != null)
                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                    .FirstOrDefault();
                return ipRegex.Match(gateway.ToString()).Value;
            }
            catch { }
            return null;
        }

        // initialize the loop that scan the network asynchronously
        private async Task RunScanner()
        {
            List<Task> hostNames = new List<Task>();

            // add a new task to hostNames with a given value i
            for (int i = 2; i <= EOA; i++)
                hostNames.Add(GetHostNameAsync(i));

            // start the processes when they all done
            await Task.WhenAll(hostNames);

            Invoke(new MethodInvoker(async () =>
            {
                CleanAndWriteToFile();
                await Form1Ref.TableFillerAsync();
                Close();
            }));
        }

        // get host name and connection status
        private async Task GetHostNameAsync(int index)
        {
            try
            {
                IPHostEntry hostEntry = await Dns.GetHostEntryAsync(IP + index);
                string hostName = hostEntry.HostName.Trim();
                if (hostName != null)
                {
                    PingReply reply = await new Ping().SendPingAsync(IP + index);
                    bool isCompConnected = reply.Status == IPStatus.Success;
                    string connected = isCompConnected ? "מחובר לרשת" : "אינו מחובר לרשת";
                    if (hostName.Equals(compName)) { hostName += " [מחשב זה]"; }
                    connString += $"{IP + index},{hostName},{connected}" + "\n";
                }
            }
            catch { }
            finally
            {
                Invoke(new MethodInvoker(() =>
                {
                    ++ipCnt;
                    Text = $"סורק {(float)ipCnt * 100 / EOA:F1}%";
                    Percentage.Text = $"{(float)ipCnt * 100 / EOA:F1}%";
                    Percentage.ForeColor = Color.FromArgb((int)((float)ipCnt / EOA * 10), (int)((float)ipCnt / EOA * 178), (int)((float)ipCnt / EOA * 40));
                    Percentage.Left = (Width - Percentage.Width) / 2;
                    ScanningPrograss.Text = $"סורק כתובת {ipCnt} מתוך {EOA}";// $"סורק כתובת {++ipCnt} מתוך {EOA} ({ipCnt * 100 / EOA:0.0}%)";
                    ScanningPrograss.Left = (Width - ScanningPrograss.Width) / 2;
                    progressBar1.PerformStep();
                }));
            }
        }

        // write the data to the file Computers in the user folder
        private void CleanAndWriteToFile()
        {
            if (connString.Length > 0)
            {
                FileInfo info = new FileInfo(path);
                if (File.Exists(path))
                    info.Attributes = FileAttributes.Normal;
                
                File.WriteAllText(path, connString.Trim('\n').Trim());

                info.Attributes = FileAttributes.Hidden;
            }
        }

        // on form closing enable the button from form1
        private void ProgressFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1Ref.GetCompNamesButt.Enabled = true;
            Form1Ref.SendButt.Enabled = true;
        }

        #region title bar
        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void MiniButton_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // מקבל מיקום עכבר ושומר אותו במערכת הפעלה
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region taskbar click
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        #endregion

        #region Window activate/deactivate

        private void ProgressForm_Activated(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(40, 40, 45);
            MinBt.BackColor = Color.FromArgb(40, 40, 45);
            CloseBt.BackColor = Color.FromArgb(40, 40, 45);
        }

        private void ProgressForm_Deactivate(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 50, 55);
            MinBt.BackColor = Color.FromArgb(50, 50, 55);
            CloseBt.BackColor = Color.FromArgb(50, 50, 55);
        }

        #endregion
    }
}
