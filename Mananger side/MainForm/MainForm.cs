using System;
using System.IO;
using System.Net;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Server_manager
{
    public partial class MainForm : Form
    {
        #region Variables

        // סופר את מספר השורות השגויות
        private int _wrongURLCnt = 0;

        // משתנה בוליאני גלובלי שמשומש על ידי הפונקציה לבדיקת שגיאות
        private bool _RTBTextError = false;

        // רגקס של כתובת אינטרנט כללית
        //private readonly static Regex _notUrlRegex = new Regex(@"^https?://(www\.)?\w+\.[A-Za-z]{2,}((\.[A-Za-z]{2,})+)?$");
        private readonly static Regex _notUrlRegex = new Regex(@"^https?://(www\.)?\w+(\.[A-Za-z]{2,}){1,}$");

        // קבלת כתובת תיקיה נוכחית
        private readonly string _GCD = Directory.GetCurrentDirectory();

        // שם התיקיה של המתשמש
        private readonly string _userFolder;

        // זמן לריענון רשימה
        private const int _refreshTime = 1000 * 60 * 10;

        // זמן לסגירת המבנה ופתיחת חלון כניסה
        private const int _closingTime = 1000 * 60 * 30;

        // נתיבים אל קבצי שמע של מערכת ההפעלה
        private static readonly string _criticalSound = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Media\Windows Battery Low.wav");
        private static readonly string _ballonSound = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Media\Windows Balloon.wav");
        private static readonly string _notifySound = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Media\Windows Notify Calendar.wav");

        // אוביקט שמע
        public static readonly SoundPlayer infoSound = new SoundPlayer(_ballonSound);
        private readonly SoundPlayer _errorSound = new SoundPlayer(_criticalSound);
        private readonly SoundPlayer _notificationSound = new SoundPlayer(_notifySound);

        #endregion

        #region Constractor

        public MainForm(string userFolder)
        {
            InitializeComponent();

            // pictureBox1 animation
            PictureBounce();

            // disable refresh button on init
            RefreshList.Enabled = false;

            // שרשור תיקיה נוכחית עם תיקית שם המשתמש
            _GCD += "\\" + userFolder + "\\";

            // מילוי הטבלה בהפעלה
            TableFillerAsync().GetAwaiter();

            // מוסיף לזמן יעד שעה יותר מהזמן התחלה
            Time2.Value = Time1.Value.AddHours(1);

            // החלה של שם המשתמש למשתנה המקומי
            _userFolder = userFolder;

            // הגדרה של מחזור הזמן של הטיימר לביצוע ריענון של רשימת המחשבים
            RefreshTimer.Interval = _refreshTime;

            // הגדרה של מחזור הזמן של הטיימר לביצוע סגירת החלון הראשי, ופתיחת חלון כניסה
            CloseTimer.Interval = _closingTime;

            // ניתנת הערות לכפתורי סגירה ומזעור של החלון
            toolTip1.SetToolTip(CloseBt, "סגור");
            toolTip1.SetToolTip(MinToTrayBt, "מזער למגש היישומים");
            toolTip1.SetToolTip(MinBt, "מזער");

            // ניתנת הערה לשעון 1
            toolTip1.SetToolTip(Time1, "לחצן ימני לקביעת הזמן הנוכחי");
            toolTip1.SetToolTip(Time2, "לחצן ימני לקביעת הזמן הנוכחי");

            // שם המשתמש
            toolTip1.SetToolTip(TitleBar, $"מחובר בתור - {userFolder}");
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Make button to shake in a case of and error
        /// </summary>
        ///<param name="button">The button to be shaken</param>
        public static async void ButtonShaker(Button button)
        {
            int d = 2, t = 1;
            for (int i = 0; i < 6; i++)
            {
                button.Left += d;
                await Task.Delay(t);
                button.Left -= d * 2;
                await Task.Delay(t);
                button.Left += d;
                await Task.Delay(t);
                t *= 2;
            }
        }

        // כפתור קבל רשימת מחשבים
        private void GetCompNames_Click(object sender, EventArgs e)
        {
            GetCompNamesButt.Enabled = false;
            SendButt.Enabled = false;
            ProgressForm progress = new ProgressForm(this, _userFolder);
            progress.Show();
        }

        // כפתור לריענון הטבלה
        private async void RefreshListAsync_Click(object sender, EventArgs e)
        {
            RefreshList.Enabled = false;
            await TableFillerAsync();
        }

        // כפתור לשליחה ללקוח את רשימת האתרים שיש לחסום
        private async void SendButtAsync_Click(object sender, EventArgs e)
        {
            try
            {
                /* ~ ~ ~ ~ ~ ~ ~ ~ תיקון קלט מהמשתמש ~ ~ ~ ~ ~ ~ ~ ~ */
                // replace comma with dot
                urlListBox.Text = urlListBox.Text.Replace(',', '.');
                // replace 2 dots with 1
                urlListBox.Text = urlListBox.Text.Replace("..", ".");
                // replace backslash with slash
                urlListBox.Text = urlListBox.Text.Replace('\\', '/');
                // remove two enter key
                urlListBox.Text = urlListBox.Text.Replace("\n\n", "\n");
                // trimming slash at the beggining ot at the end
                urlListBox.Text = urlListBox.Text.Trim('/');
                // trimming white space
                urlListBox.Text = urlListBox.Text.Trim();

                // הצגה של שגיאות בתוך הרשימה
                FullCheckRTB();

                // מקבל את הכתובת מהבחירה של המשתמש
                IPAddress address = IPAddress.Parse(Table.SelectedRows[0].Cells["address"].Value?.ToString());

                // מוודא כי המחשב אכן מחובר לרשת
                PingReply reply = await new Ping().SendPingAsync(address);
                bool isConn = reply.Status == IPStatus.Success;

                // חישוב זמני החסימה
                long time1 = Time1.Value.Ticks;
                long time2 = Time2.Value.Ticks;
                string totalTime = time1 + ">" + time2 + "|\n";
                string list = _userFolder + "|\n" + (timeCheck.Checked ? totalTime : string.Empty) + urlListBox.Text;

                // מוודא חיבוריות של המחשב הנבחר
                if (!isConn)
                {
                    ButtonShaker(SendButt);
                    _errorSound.Play();
                    Message("אין חיבור לרשת", "המחשב אינו מחובר לרשת, הרשימה לא נשלחה",
                        MessageBoxIcon.Information, MessageBoxButtons.OK);
                }

                // בודק האם הרשימה ריקה, במידה וכן מסיר את החסימות מהמחשב
                else if (urlListBox.TextLength < 1)
                {
                    await SendListHandlerAsync(address, _userFolder + $"|{(timeCheck.Checked ? "timed clear" : "clear")}");
                }

                // בודק שאין כתובות אינטרנט שגויות
                else if (_RTBTextError)
                {
                    ButtonShaker(SendButt);
                    string message = _wrongURLCnt <= 1 ? "נראה שקיימת כתובת אחת שגוייה"
                        : $"נראה כי קיימות {_wrongURLCnt} כתובות URL שגויות";
                    string caption = "כתובת URL שגוייה";
                    _notificationSound.Play();
                    Message(caption, message, MessageBoxIcon.Information, MessageBoxButtons.OK);
                    _wrongURLCnt = 0;
                }

                // בודק האם הרשימה הנוכחית זהה לקיימת, במידה וכן ישאל האם לשלוח
                else if (IsFileMatchRTB())
                {
                    string message = "לא בוצעו שינוי, האם לשלוח בכל זאת?";
                    string caption = "לא בוצעו שינויים";
                    _notificationSound.Play();
                    DialogResult result = Message(caption, message, MessageBoxIcon.Question, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        await SendListHandlerAsync(address, list);
                    }
                }

                // אם הגענו לפה, הכל תקין :)
                else
                {
                    await SendListHandlerAsync(address, list);
                }
            }

            catch
            {
                ButtonShaker(SendButt);
                infoSound.Play();
            }
        }

        // סגירה של החלון
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // מזעור למגש המשימות
        private void MinimizeToTray_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
            _notificationSound.Play();
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(0);
        }

        // מזעור לשורת המשימות
        private void MiniButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Rich text box input check

        // run on each line of the rich text box
        private void FullCheckRTB()
        {
            _RTBTextError = false;
            if (urlListBox.Lines.Length > 1)
            {
                foreach (string line in urlListBox.Lines)
                {
                    // make sure not to mark empty string as an error
                    if (line.Length > 0)
                    {
                        CheckRTBText(line);
                    }
                }
            }
            else
            {
                CheckRTBText(urlListBox.Text);
            }
        }

        /// <summary>
        /// run on each character of the line from <see cref="FullCheckRTB"/>
        /// </summary>
        /// <param name="line"></param>
        private void CheckRTBText(string line)
        {
            Match match = _notUrlRegex.Match(line);
            int start = 0;
            int end = urlListBox.Text.LastIndexOf(line);
            if (!match.Success)
            {
                _wrongURLCnt++;
                _RTBTextError = true;
                while (start <= end)
                {
                    urlListBox.Find(line, start, urlListBox.TextLength, RichTextBoxFinds.WholeWord);
                    urlListBox.SelectionColor = Color.White;
                    urlListBox.SelectionBackColor = Color.Red;
                    start = urlListBox.Text.IndexOf(line, start) + 1;
                }
            }
        }

        // מחזיר את צבע הקטע של הטקסט בתיבת הטקסט לאחר שהפכה להיות אדומה
        private void UrlListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            urlListBox.SelectionColor = Color.Black;
            urlListBox.SelectionBackColor = Color.FromArgb(150, 160, 200);
        }

        #endregion

        #region Table

        // ממלא את תיבת הטקסט ברשימת הכתובות של אותו מחשב שנבחר מהרשימה
        private void Table_SelectionChanged(object sender, EventArgs e)
        {
            // reset the Sendbutt text
            SendButt.Text = "שלח רשימת חסימות";

            // if the table is empty
            if (Table.SelectedRows.Count == 0) return;

            // if the row is empty
            if (Table.SelectedRows[0].Cells["address"].Value?.ToString() == null)
            {
                urlListBox.Text = string.Empty;
                urlListBox.ReadOnly = true;
                return;
            }

            urlListBox.ReadOnly = false;
            string fileName = Table.SelectedRows[0].Cells["address"].Value?.ToString();
            fileName = _GCD + (timeCheck.Checked ? "timed " : string.Empty) + fileName + ".txt";

            if (File.Exists(fileName))
            {
                BlockingListFiller(fileName);
                if (timeCheck.Checked)
                {
                    using StreamReader reader = new StreamReader(fileName);
                    if (reader.Peek() == -1) { reader.Close(); return; }
                    reader.Close();
                    string time = File.ReadAllLines(fileName)[0].Trim('|');
                    DateTime startTime = new DateTime(long.Parse(time.Split('>')[0]));
                    DateTime endTime = new DateTime(long.Parse(time.Split('>')[1]));
                    Time1.Value = startTime;
                    Time2.Value = endTime;
                }
            }
            else urlListBox.Text = string.Empty;
        }

        // משנה את צבע השורה לפי סטטוס החיבור של אותו מחשב
        private void TableColor()
        {
            foreach (DataGridViewRow row in Table.Rows)
            {
                if ((string)row.Cells["isConnected"].Value == "מחובר לרשת")
                {
                    row.DefaultCellStyle.ForeColor = Color.ForestGreen;
                    row.DefaultCellStyle.SelectionForeColor = Color.SpringGreen;
                }
                else if ((string)row.Cells["isConnected"].Value == "אינו מחובר לרשת")
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 50, 40);
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 40, 20);
                }
            }
        }

        // ממלא נתונים לטבלה שנכתבו בקובץ
        public async Task TableFillerAsync()
        {
            // clear the data grid view
            Table.Rows.Clear();

            string compListPath = _GCD + "Computers.txt";
            if (File.Exists(compListPath) && new FileInfo(compListPath).Length > 6)
            {
                foreach (string line in File.ReadAllLines(compListPath))
                {
                    string ip = line.Split(',')[0];
                    string name = line.Split(',')[1];
                    PingReply reply = await new Ping().SendPingAsync(ip);
                    bool isCompConnected = reply.Status == IPStatus.Success;
                    string connected = isCompConnected ? "מחובר לרשת" : "אינו מחובר לרשת";
                    Table.Rows.Add(ip, name, connected);
                }
            }

            TableColor();
            RefreshList.Enabled = true;
        }

        #endregion

        #region Timers

        // מאפשר או מבטל גישה לבוחר הזמנים ע"פ תיבת הסימון
        private void TimeCheck_CheckStateChanged(object sender, EventArgs e)
        {
            Table_SelectionChanged(null, null);
            if (timeCheck.CheckState == CheckState.Checked)
                Time1.Enabled = Time2.Enabled = true;
            else Time1.Enabled = Time2.Enabled = false;

        }

        // מרענן את הרשימה המחשבים
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshList.PerformClick();
        }

        // סוגר את החלון ומפעיל חלון כניסה ממוזער כאשר החלון ללא שימוש זמן מסויים
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            CloseTimer.Stop();
            LoginForm login;
            login = new LoginForm();
            Hide();
            login.Closed += (s, args) => Close();
            login.Show();
            login.WindowState = FormWindowState.Minimized;
        }

        // set the Time1 time to current time on right click
        private void Time1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Right))
                Time1.Value = DateTime.Now;
        }

        // set the Time2 time to current time on right click
        private void Time2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Right))
                Time2.Value = DateTime.Now;
        }

        #endregion

        #region Blocking list

        // ממלא את הרשימה של האתרים החסומים
        private void BlockingListFiller(string path)
        {
            if (!File.Exists(path)) return;

            // get the file content
            string file = File.ReadAllText(path);

            // determine the SendButt text
            if (file.Length >= 6)
                SendButt.Text = "עדכון רשימת חסימות";
            else SendButt.Text = "שלח רשימת חסימות";

            // fill the urlListBox with the correct text
            if (file.Split('\n')[0].Contains("|"))
                urlListBox.Text = file.Split('|')[1].Trim();
            else urlListBox.Text = file;
        }

        // כותב לתוך הקובץ את הרשימה של הכתובות החסומות
        private void WriteToBlockingListFile()
        {
            try
            {
                string fileName = Table.SelectedRows[0].Cells["address"].Value?.ToString();
                fileName = _GCD + (timeCheck.Checked ? "timed " : string.Empty) + fileName + ".txt";

                if (File.Exists(fileName))
                {
                    new FileInfo(fileName)
                    {
                        Attributes = FileAttributes.Normal
                    };
                }

                if (timeCheck.Checked)
                {
                    string startTime = Time1.Value.Ticks.ToString();
                    string endTime = Time2.Value.Ticks.ToString();
                    string content = urlListBox.TextLength > 0 ? startTime + ">" + endTime + "|\n" + urlListBox.Text : string.Empty;
                    File.WriteAllText(fileName, content);
                }

                else
                {
                    File.WriteAllText(fileName, urlListBox.Text);
                }
                new FileInfo(fileName)
                {
                    Attributes = FileAttributes.Hidden
                };
            }
            catch { }
        }

        /// <summary>
        /// בדיקה האם הטקסט שבקובץ זהה לזה שבתיבת טקסט
        /// </summary>
        /// <returns>The equelity of the rich text box with the text file</returns>
        private bool IsFileMatchRTB()
        {
            string fileName = Table.SelectedRows[0].Cells["address"].Value?.ToString();
            if (!File.Exists($"{_GCD}{fileName}.txt"))
            {
                return false;
            }
            return urlListBox.Text == File.ReadAllText($"{_GCD}{fileName}.txt");
        }

        #endregion

        #region Form activate/deactivate

        // בודק האם החלון לא בשימוש ומפעיל את הטיימר במידה ונעצר
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            RefreshTimer.Start();
            CloseTimer.Start();
            panel1.BackColor = Color.FromArgb(50, 50, 55);
            MinBt.BackColor = Color.FromArgb(50, 50, 55);
            MinToTrayBt.BackColor = Color.FromArgb(50, 50, 55);
            CloseBt.BackColor = Color.FromArgb(50, 50, 55);
        }

        // בודק האם החלון בשימוש ועוצר את הטיימר במידה והופעל
        private void MainForm_Activated(object sender, EventArgs e)
        {
            RefreshTimer.Stop();
            CloseTimer.Stop();
            panel1.BackColor = Color.FromArgb(40, 40, 45);
            MinBt.BackColor = Color.FromArgb(40, 40, 45);
            MinToTrayBt.BackColor = Color.FromArgb(40, 40, 45);
            CloseBt.BackColor = Color.FromArgb(40, 40, 45);
        }

        #endregion

        #region Title bar

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            SystemSounds.Hand.Play();
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            SystemSounds.Hand.Play();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // מקבל מיקום עכבר ושומר אותו במערכת הפעלה
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
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

        #region Sending commands to selected computer

        /// <summary>
        /// Event of click on the <see cref="Table"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Right))
            {
                Point p = Table.PointToClient(MousePosition);
                int row = Table.HitTest(p.X, p.Y).RowIndex;
                if (row >= 0)
                {
                    Table.Rows[Table.Rows[row].Index].Selected = true;
                    string sIP = Table.SelectedRows[0].Cells["address"].Value?.ToString();
                    if (IPAddress.TryParse(sIP, out IPAddress IP))
                    {
                        ContextMenuStrip menu = new ContextMenuStrip
                        {
                            RightToLeft = RightToLeft.Yes,
                            ImageScalingSize = new Size(18, 18),
                            BackColor = Color.FromArgb(65, 70, 90),
                            ForeColor = Color.WhiteSmoke,
                            RenderMode = ToolStripRenderMode.System,
                            Font = new Font("Microsoft JhengHei UI Light", 14F, FontStyle.Regular, GraphicsUnit.Point, 177)
                        };

                        // Get the icon for the menu
                        // If they didn't exist, they will be null
                        Image restart = File.Exists(@"Assets/Restart.png") ? Image.FromFile(@"Assets/Restart.png") : null;
                        Image forceRestart = File.Exists(@"Assets/Force Restart.png") ? Image.FromFile(@"Assets/Force Restart.png") : null;
                        Image lockComp = File.Exists(@"Assets/Lock.png") ? Image.FromFile(@"Assets/Lock.png") : null;
                        Image shutdown = File.Exists(@"Assets/shut down.png") ? Image.FromFile(@"Assets/shut down.png") : null;
                        Image abort = File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                            @"System32\SecurityAndMaintenance.png")) ?
                            Image.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                            @"System32\SecurityAndMaintenance.png")) : null;

                        // Adding items
                        menu.Items.Add("אתחל", restart).Name = "rst";
                        menu.Items.Add("כפה איתחול", forceRestart).Name = "frst";
                        menu.Items.Add("נעל מחשב", lockComp).Name = "lock";
                        menu.Items.Add(new ToolStripSeparator());
                        menu.Items.Add("כבה מחשב", shutdown).Name = "off";
                        menu.Items.Add(new ToolStripSeparator());
                        menu.Items.Add("בטל פקודה", abort).Name = "abort";

                        // Show the menu only inside the Table object, in the position of p (mouse position)
                        menu.Show(Table, p);
                        menu.ItemClicked += new ToolStripItemClickedEventHandler(async (s, e) => await ItemClickedAsync(e, IP));
                    }
                }
            }
        }

        /// <summary>
        /// Send data to the client, and show message according to the sending status
        /// </summary>
        /// <param name="e">The item himself</param>
        /// <param name="IP">The client IP address</param>
        /// <returns>Empty Task</returns>
        private async Task ItemClickedAsync(ToolStripItemClickedEventArgs e, IPAddress IP)
        {
            if (await Task.Run(() => Server.SendBlockingList(IP, e.ClickedItem.Name)))
            {
                infoSound.Play();
                Message("שליחה צלחה", "הפקודה נשלחה בהצלחה", MessageBoxIcon.Information, MessageBoxButtons.OK);
            }
            else
            {
                _errorSound.Play();
                Message("שליחה נכשלה", "הפקודה לא הגיע ליעד", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
        }

        #endregion

        /// <summary>
        /// יצירה של חלון הודעה
        /// </summary>
        /// <param name="caption">Message title</param>
        /// <param name="message">Message body</param>
        /// <param name="icon">Icon type</param>
        /// <param name="buttons">Buttons type</param>
        /// <returns>Button click result</returns>
        private DialogResult Message(string caption, string message, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, caption, buttons, icon,
                   MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        /// <summary>
        /// מבצע ניהול של השליחה
        /// </summary>
        /// <param name="address"></param>
        /// <param name="list"></param>
        /// <returns>Empty task</returns>
        private async Task SendListHandlerAsync(IPAddress address, string list)
        {
            if (await Task.Run(() => Server.SendBlockingList(address, list)))
            {
                infoSound.Play();
                Message("נשלח בהצלחה", "הרשימה נשלחה בהצלחה", MessageBoxIcon.Information, MessageBoxButtons.OK);
                if (list.Contains("clear"))
                {
                    SendButt.Text = "שלח רשימת חסימות";
                    Message("ביטול חסימות", "הוסרו כול החסימות", MessageBoxIcon.Information, MessageBoxButtons.OK);
                }
                else
                {
                    SendButt.Text = "עדכון רשימת חסימות";
                }
                WriteToBlockingListFile();
            }
            else
            {
                _errorSound.Play();
                Message("שליחה נכשלה", "הרשימה לא הגיע ליעד", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
        }

        #region Picture animation

        // just nice little bounce animation
        private async void PictureBounce()
        {
            int d = 1, t = 10;
            while (pictureBox1.Top <= 58)
            {
                pictureBox1.Top += d;
                await Task.Delay(t);
            }
            while (pictureBox1.Top >= 38)
            {
                pictureBox1.Top -= d;
                await Task.Delay(t);
            }
            while (pictureBox1.Top < 47)
            {
                pictureBox1.Top += d;
                await Task.Delay(t);
            }
            pictureBox1.Top = 47;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width - 10, pictureBox1.Size.Height - 10);
                pictureBox1.Top += 5;
                pictureBox1.Left += 5;
            }

            else if (e.Button.HasFlag(MouseButtons.Right))
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width + 10, pictureBox1.Size.Height + 10);
                pictureBox1.Top -= 5;
                pictureBox1.Left -= 5;
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width + 10, pictureBox1.Size.Height + 10);
                pictureBox1.Top -= 5;
                pictureBox1.Left -= 5;
            }

            else if (e.Button.HasFlag(MouseButtons.Right))
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width - 10, pictureBox1.Size.Height - 10);
                pictureBox1.Top += 5;
                pictureBox1.Left += 5;
            }
        }

        #endregion
    }
}