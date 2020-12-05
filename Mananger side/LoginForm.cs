using System;
using System.IO;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Server_manager
{
    public partial class LoginForm : Form
    {
        #region Variables

        // Current directory path
        private readonly string _GCD = Directory.GetCurrentDirectory();

        // Logon sound
        private readonly string _logonSound = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Media\Windows Logon.wav");

        #endregion

        #region Constractor

        public LoginForm()
        {
            InitializeComponent();
            toolTip1.SetToolTip(CloseBt, "סגור");
            toolTip1.SetToolTip(MinBt, "מזער");
            toolTip1.SetToolTip(passShowExist, "הצג סיסמה");
            toolTip1.SetToolTip(passShowCreate, "הצג סיסמה");
            existPanel.Visible = true;
            createPanel.Visible = false;
            existPanel.BringToFront();
            existPanel.Dock = DockStyle.Fill;
        }

        #endregion

        #region Taskbar click

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

        #region Capslook on

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
        
        #endregion

        #region Form movment

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

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

        #region Exist user text box

        /// <summary>
        /// enter to the password field of the <see cref="existPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordExistBox_Enter(object sender, EventArgs e)
        {
            if (passwordExistBox.Text == "ID Number")
            {
                passwordExistBox.Text = "";
                passwordExistBox.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// leave to the password field of the <see cref="existPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordExistBox_Leave(object sender, EventArgs e)
        {
            if (passwordExistBox.Text == "")
            {
                passwordExistBox.Text = "ID Number";
                passwordExistBox.UseSystemPasswordChar = false;
            }
        }

        /// <summary>
        /// enter to the user name field of the <see cref="existPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserExistBox_Enter(object sender, EventArgs e)
        {
            if (userExistBox.Text == "User Name")
                userExistBox.Text = "";
        }

        /// <summary>
        /// leave to the user name field of the <see cref="existPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserExistBox_Leave(object sender, EventArgs e)
        {
            if (userExistBox.Text == "")
                userExistBox.Text = "User Name";
        }

        #endregion

        #region Create user text box 

        /// <summary> 
        /// enter to the password field of the <see cref="createPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordCreateBox_Enter(object sender, EventArgs e)
        {
            if (passwordCreateBox.Text == "ID Number")
            {
                passwordCreateBox.Text = "";
                passwordCreateBox.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// leave to the password field of the <see cref="createPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordCreateBox_Leave(object sender, EventArgs e)
        {
            if (passwordCreateBox.Text == "")
            {
                passwordCreateBox.Text = "ID Number";
                passwordCreateBox.UseSystemPasswordChar = false;
            }
        }

        /// <summary>
        /// enter to the user name field of the <see cref="createPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCreateBox_Enter(object sender, EventArgs e)
        {
            if (userCreateBox.Text == "User Name")
                userCreateBox.Text = "";
        }

        /// <summary>
        /// leave to the user name field of the <see cref="createPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCreateBox_Leave(object sender, EventArgs e)
        {
            if (userCreateBox.Text == "")
                userCreateBox.Text = "User Name";
        }

        #endregion

        #region Password peek

        /// <summary>
        /// remove the paln text on click on the eye icon
        /// from the <see cref="createPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassShowCreate_Click(object sender, EventArgs e)
        {
            if (passwordCreateBox.UseSystemPasswordChar == false &&
                passwordCreateBox.Text != "ID Number")
            {
                passwordCreateBox.UseSystemPasswordChar = true;
            }
            else
            {
                passwordCreateBox.UseSystemPasswordChar = false;
            }
        }

        /// <summary>
        /// remove the paln text on click on the eye icon
        /// from the <see cref="existPanel"/> 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassShowExist_Click(object sender, EventArgs e)
        {
            if (passwordExistBox.UseSystemPasswordChar == false &&
                passwordExistBox.Text != "ID Number")
            {
                passwordExistBox.UseSystemPasswordChar = true;
            }
            else if(passwordExistBox.UseSystemPasswordChar == true &&
                passwordExistBox.Text != "ID Number")
            {
                passwordExistBox.UseSystemPasswordChar = false;
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Check for correct ID number
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>If the sum of the ID numbers is divided without a remainder</returns>
        private bool IDCheck(string id)
        {
            int idSum = 0;
            int subIdSum = 0;
            int checkDigit = int.Parse(id[id.Length - 1].ToString());
            for (int i = 0; i < id.Length; i++)
            {
                // Check for total summary of the ID number
                int num = int.Parse(id[i].ToString());
                if (i % 2 == 1)
                {
                    num *= 2;
                    if (num > 9)
                        num = (num / 10) + (num % 10);
                }

                idSum += num;

                if (i == id.Length - 2)
                    subIdSum = idSum;
            }
            return idSum % 10 == 0 && (subIdSum + checkDigit) % 10 == 0;
        }

        /// <summary>
        /// If the user is in the password field
        /// he can use the enter key to click <see cref="createButton"/> and <see cref="enterButton"/>
        /// or to exit the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (existPanel.Visible == true)
                    enterButton.PerformClick();
                if (createButton.Visible == true)
                    createButton.PerformClick();
            }
            if (e.KeyCode == Keys.Escape) { Close(); }
        }

        /// <summary>
        /// Show the <see cref="existPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterTab_Click(object sender, EventArgs e)
        {
            createPanel.Visible = false;
            createPanel.Dock = DockStyle.None;
            existPanel.BringToFront();
            existPanel.Visible = true;
            existPanel.Dock = DockStyle.Fill;
            Title.Text = "כניסה למערכת";
            Title.Left = Width / 2 - Title.Width / 2;
        }

        /// <summary>
        /// Show the <see cref="createPanel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateTab_Click(object sender, EventArgs e)
        {
            existPanel.Visible = false;
            existPanel.Dock = DockStyle.None;
            createPanel.BringToFront();
            createPanel.Visible = true;
            createPanel.Dock = DockStyle.Fill;
            Title.Text = "יצירת משתמש חדש";
            Title.Left = Width / 2 - Title.Width / 2;
        }

        /// <summary>
        /// Enter the main window with exist user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterButton_Click(object sender, EventArgs e)
        {
            // change the user name to lowercase
            // only when it isn't default display name
            if (userExistBox.Text != "User Name")
                // convert the user name to lower case
                userExistBox.Text = userExistBox.Text.ToLower();

            // add one zero for check digit
            if(passwordExistBox.TextLength == 8)
                // add 0 at the beggining if the password is 8 digit and need check digit
                passwordExistBox.Text = passwordExistBox.Text.PadLeft(9, '0');

            // Empty fields
            if (userExistBox.Text == "User Name" && passwordExistBox.Text == "ID Number")
            {
                MainForm.ButtonShaker(enterButton);
                MainForm.infoSound.Play();
                if (messageExistLabel.Visible == true)
                    messageExistLabel.Visible = false;
                messageExistLabel.Text = "שדות ריקים";
                messageExistLabel.Location = new Point(Width / 2 - messageExistLabel.Width / 2,
                                                       messageExistLabel.Location.Y);
                messageExistLabel.Visible = true;
            }

            // if the user name is too short
            else if (userExistBox.TextLength < 4 || userExistBox.Text == "User Name")
            {
                MainForm.ButtonShaker(enterButton);
                MainForm.infoSound.Play();
                if (messageExistLabel.Visible == true)
                    messageExistLabel.Visible = false;
                messageExistLabel.Text = "שם משתמש קצר מדי";
                messageExistLabel.Location = new Point((Width / 2) - (messageExistLabel.Width / 2),
                                                       (Height / 4) + messageExistLabel.Height);
                messageExistLabel.Visible = true;
            }

            // if the ID number is too short
            else if (passwordExistBox.TextLength < 8 || passwordExistBox.Text == "ID Number")
            {
                MainForm.ButtonShaker(enterButton);
                MainForm.infoSound.Play();
                if (messageExistLabel.Visible == true)
                    messageExistLabel.Visible = false;
                messageExistLabel.Text = "מספר תעודת זהות קצרה מדי";
                messageExistLabel.Location = new Point((Width / 2) - (messageExistLabel.Width / 2),
                                                       (Height / 4) + messageExistLabel.Height);
                messageExistLabel.Visible = true;
            }

            // if the ID number isn't only numbers
            else if (!int.TryParse(passwordExistBox.Text, out _))
            {
                MainForm.ButtonShaker(enterButton);
                MainForm.infoSound.Play();
                if (messageExistLabel.Visible == true)
                    messageExistLabel.Visible = false;
                messageExistLabel.Text = "יש להכניס לתעודת הזהות" + "\n" + "מספרים בלבד";
                messageExistLabel.Location = new Point((Width / 2) - (messageExistLabel.Width / 2),
                                                       (Height / 4) + (messageExistLabel.Height / 3));
                messageExistLabel.Visible = true;
            }

            // At this point, every input test are OK
            else
            {
                try
                {
                    string userInfoPath = $@"{_GCD}\{userExistBox.Text}\{userExistBox.Text}.txt";

                    // the folder name and user are the same
                    // so if there isn't a folder with the user name
                    // the user isn't exist
                    if (File.Exists(userInfoPath))
                    {
                        using StreamReader reader = new StreamReader(userInfoPath);
                        // אם יש תוכן בקובץ
                        if (reader.Peek() != -1)
                        {
                            string[] userInfo = reader.ReadToEnd().Split('|');
                            
                            // האם שם המשתמש והסיסמה נכונים
                            if (userInfo[0] == userExistBox.Text
                                && StringCipher.Decrypt(userInfo[1], userExistBox.Text) == passwordExistBox.Text)
                            {
                                using SoundPlayer sound = new SoundPlayer(_logonSound);
                                sound.Play();
                                messageExistLabel.Visible = false;
                                reader.Close();
                                NewForm();
                            } 
                            
                            // Password incorrect
                            else
                            {
                                MainForm.ButtonShaker(enterButton);
                                MainForm.infoSound.Play();
                                if (messageExistLabel.Visible == true)
                                    messageExistLabel.Visible = false;
                                messageExistLabel.Text = "סיסמה שגויה";
                                messageExistLabel.Location = new Point((Width / 2) - (messageExistLabel.Width / 2),
                                                                       (Height / 4) + messageExistLabel.Height);
                                messageExistLabel.Visible = true;
                            }
                        }
                        reader.Close();
                    }

                    // if the user isn't exist
                    else
                    {
                        MainForm.ButtonShaker(enterButton);
                        MainForm.infoSound.Play();
                        if (messageExistLabel.Visible == true)
                            messageExistLabel.Visible = false;
                        messageExistLabel.Text = "המשתמש לא קיים במערכת";
                        messageExistLabel.Location = new Point((Width / 2) - (messageExistLabel.Width / 2),
                                                               (Height / 4) + messageExistLabel.Height);
                        messageExistLabel.Visible = true;
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// Enter the main window with new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // change the user name to lowercase
            // only when it isn't default display name
            if (userCreateBox.Text != "User Name")
                // change the user name to lower case
                userCreateBox.Text = userCreateBox.Text.ToLower();
            
            // add one zero for check digit
            if (passwordCreateBox.TextLength == 8)
                // add 0 at the beggining if the password is 8 digit and need check digit
                passwordCreateBox.Text = passwordCreateBox.Text.PadLeft(9, '0');

            // אם השם קצר מידי או שזה שם התצוגה
            if (userCreateBox.TextLength < 4 || userCreateBox.Text == "User Name")
            {
                MainForm.ButtonShaker(createButton);
                MainForm.infoSound.Play();
                if (messageCreateLabel.Visible == true)
                    messageCreateLabel.Visible = false;
                messageCreateLabel.Text = "שם משתמש קצר מדי";
                messageCreateLabel.Location = new Point((Width / 2) - (messageCreateLabel.Width / 2),
                                                        (Height / 4) + messageCreateLabel.Height);
                messageCreateLabel.Visible = true;
            }

            // אם הסיסמה קצרה מדי או שזה שם התצוגה
            else if (passwordCreateBox.TextLength < 8 || passwordCreateBox.Text == "ID Number")
            {
                MainForm.ButtonShaker(createButton);
                MainForm.infoSound.Play();
                if (messageCreateLabel.Visible == true)
                    messageCreateLabel.Visible = false;
                messageCreateLabel.Text = "מספר תעודת זהות קצרה מדי";
                messageCreateLabel.Location = new Point((Width / 2) - (messageCreateLabel.Width / 2),
                                                        (Height / 4) + messageCreateLabel.Height);
                messageCreateLabel.Visible = true;
            }

            // if the password isn't contains only numbers
            else if(!int.TryParse(passwordCreateBox.Text, out _))
            {
                MainForm.ButtonShaker(createButton);
                MainForm.infoSound.Play();
                if (messageCreateLabel.Visible == true)
                    messageCreateLabel.Visible = false;
                messageCreateLabel.Text = "יש להכניס לתעודת הזהות" + "\n" + "מספרים בלבד";
                messageCreateLabel.Location = new Point(Width / 2 - messageCreateLabel.Width / 2,
                                                        (Height / 4) + (messageCreateLabel.Height / 3));
                messageCreateLabel.Visible = true;
            }

            // if the ID number isn't correct
            else if (!IDCheck(passwordCreateBox.Text))
            {
                MainForm.ButtonShaker(createButton);
                MainForm.infoSound.Play();
                if (messageCreateLabel.Visible == true)
                    messageCreateLabel.Visible = false;
                messageCreateLabel.Text = "מספר תעודה הזהות איננו תקין";
                messageCreateLabel.Location = new Point(Width / 2 - messageCreateLabel.Width / 2,
                                                        (Height / 4) + messageCreateLabel.Height);
                messageCreateLabel.Visible = true;
            }

            // if everything is OK, the user will be created
            else
            {
                string userInfo = $@"{_GCD}\{userCreateBox.Text}";

                if (!Directory.Exists(userInfo))
                    Directory.CreateDirectory(userInfo).Attributes |= FileAttributes.Hidden;
                
                if (!File.Exists(userInfo += $@"\{userCreateBox.Text}.txt"))
                {
                    using SoundPlayer sound = new SoundPlayer(_logonSound);
                    sound.Play();
                    File.WriteAllText
                        (
                        userInfo,
                        userCreateBox.Text + "|" + StringCipher.Encrypt(passwordCreateBox.Text, userCreateBox.Text)
                        );

                    new FileInfo(userInfo)
                    {
                        Attributes = FileAttributes.Hidden
                    };

                    messageCreateLabel.Text = "המשתמש נוצר בהצלחה";
                    messageCreateLabel.Location = new Point((Width / 2) - (messageCreateLabel.Width / 2),
                                                            (Height / 4) + messageCreateLabel.Height);
                    messageCreateLabel.Visible = true;
                    NewForm();
                }
                else
                {
                    MainForm.ButtonShaker(createButton);
                    MainForm.infoSound.Play();
                    if (messageCreateLabel.Visible == true)
                        messageCreateLabel.Visible = false;
                    messageCreateLabel.Text = "המשתמש כבר קיים במערכת";
                    messageCreateLabel.Location = new Point(Width / 2 - messageCreateLabel.Width / 2,
                                                            (Height / 4) + messageCreateLabel.Height);
                    messageCreateLabel.Visible = true;
                }
            }

        }

        /// <summary>
        /// Close this window and program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Minimize the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiniButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Window activate/deactivate

        /// <summary>
        /// Event occurred when you enter the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Activated(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(40, 40, 45);
            MinBt.BackColor = Color.FromArgb(40, 40, 45);
            CloseBt.BackColor = Color.FromArgb(40, 40, 45);
        }

        /// <summary>
        /// Event occurred when you leave the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Deactivate(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 50, 55);
            MinBt.BackColor = Color.FromArgb(50, 50, 55);
            CloseBt.BackColor = Color.FromArgb(50, 50, 55);
        }

        #endregion

        #region Create main window

        /// <summary>
        /// create new <see cref="MainForm"/> window
        /// send to it the user name
        /// </summary>
        private void NewForm()
        {
            MainForm mainForm;
            Hide();
            if (userCreateBox.Text != "User Name")
                mainForm = new MainForm(userCreateBox.Text);
            else
                mainForm = new MainForm(userExistBox.Text);
            mainForm.Closed += (s, args) => Close();
            mainForm.Show();
        }

        #endregion

    }
}
