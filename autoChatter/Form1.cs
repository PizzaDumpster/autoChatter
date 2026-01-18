using System.Runtime.InteropServices;

namespace autoChatter
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;

        private Point clickPosition;
        private System.Windows.Forms.Timer autoTimer;
        private System.Windows.Forms.Timer countdownTimer;
        private bool positionSet = false;
        private Random random = new Random();
        private List<string> messagePool = new List<string>();
        private int currentMessageIndex = 0;
        private DateTime nextFireTime;
        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
            autoTimer = new System.Windows.Forms.Timer();
            autoTimer.Tick += AutoTimer_Tick;
            
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private async void btnSetPosition_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Status: Move mouse to target in 5 seconds...";
            btnSetPosition.Enabled = false;

            for (int i = 5; i > 0; i--)
            {
                lblStatus.Text = $"Status: Setting position in {i}...";
                await Task.Delay(1000);
            }

            clickPosition = Cursor.Position;
            positionSet = true;
            lblPosition.Text = $"Position: X={clickPosition.X}, Y={clickPosition.Y}";
            lblStatus.Text = "Status: Position set!";
            btnSetPosition.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!positionSet)
            {
                MessageBox.Show("Please set the click position first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text) && !chkRandomize.Checked)
            {
                MessageBox.Show("Please enter a message!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkRandomize.Checked && string.IsNullOrWhiteSpace(txtMessages.Text))
            {
                MessageBox.Show("Please enter messages (one per line)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkRandomize.Checked && !isRunning)
            {
                messagePool = txtMessages.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                currentMessageIndex = 0;
                UpdateMessageListHighlight();
            }

            int intervalMinutes = (int)numInterval.Value;
            autoTimer.Interval = intervalMinutes * 60 * 1000;
            autoTimer.Start();
            countdownTimer.Start();
            isRunning = true;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnSetPosition.Enabled = false;
            txtMessage.Enabled = false;
            txtMessages.Enabled = false;
            numInterval.Enabled = false;
            chkRandomize.Enabled = false;
            btnSetFirst.Enabled = false;
            btnShuffle.Enabled = false;

            PerformAutoChat();
            nextFireTime = DateTime.Now.AddMinutes(intervalMinutes);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            countdownTimer.Stop();
            isRunning = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnSetPosition.Enabled = true;
            txtMessage.Enabled = !chkRandomize.Checked;
            txtMessages.Enabled = chkRandomize.Checked;
            numInterval.Enabled = true;
            chkRandomize.Enabled = true;
            btnSetFirst.Enabled = chkRandomize.Checked && lstMessages.Items.Count > 0;
            btnShuffle.Enabled = chkRandomize.Checked && lstMessages.Items.Count > 0;
            lblStatus.Text = "Status: Stopped";
            
            if (chkRandomize.Checked)
            {
                UpdateMessageList();
            }
        }

        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            PerformAutoChat();
            int intervalMinutes = (int)numInterval.Value;
            nextFireTime = DateTime.Now.AddMinutes(intervalMinutes);
            
            if (chkRandomize.Checked)
            {
                UpdateMessageListHighlight();
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = nextFireTime - DateTime.Now;
            
            if (remaining.TotalSeconds <= 0)
            {
                lblStatus.Text = "Status: Sending...";
            }
            else if (remaining.TotalMinutes >= 1)
            {
                lblStatus.Text = $"Status: Next in {remaining.Minutes:D2}:{remaining.Seconds:D2}";
            }
            else
            {
                lblStatus.Text = $"Status: Next in {remaining.Seconds} seconds";
            }
        }

        private void PerformAutoChat()
        {
            try
            {
                SetCursorPos(clickPosition.X, clickPosition.Y);
                Thread.Sleep(100);

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(50);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(100);

                string messageToSend;
                if (chkRandomize.Checked)
                {
                    if (messagePool.Count > 0)
                    {
                        messageToSend = messagePool[currentMessageIndex];
                        currentMessageIndex++;
                        
                        if (currentMessageIndex >= messagePool.Count)
                        {
                            currentMessageIndex = 0;
                        }
                        
                        UpdateMessageListHighlight();
                    }
                    else
                    {
                        messageToSend = txtMessage.Text;
                    }
                }
                else
                {
                    messageToSend = txtMessage.Text;
                }

                Clipboard.SetText(messageToSend);
                Thread.Sleep(100);
                SendKeys.SendWait("^v");
                Thread.Sleep(100);
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error - {ex.Message}";
            }
        }

        private void ShuffleMessages()
        {
            int n = messagePool.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string temp = messagePool[k];
                messagePool[k] = messagePool[n];
                messagePool[n] = temp;
            }
        }

        private void chkRandomize_CheckedChanged(object sender, EventArgs e)
        {
            txtMessage.Enabled = !chkRandomize.Checked;
            txtMessages.Enabled = chkRandomize.Checked;
            btnLoadFile.Enabled = chkRandomize.Checked;
            lstMessages.Visible = chkRandomize.Checked;
            label3.Visible = chkRandomize.Checked;
            btnSetFirst.Visible = chkRandomize.Checked;
            btnShuffle.Visible = chkRandomize.Checked;
            
            if (chkRandomize.Checked)
            {
                UpdateMessageList();
            }
        }

        private void txtMessages_TextChanged(object sender, EventArgs e)
        {
            if (chkRandomize.Checked && !autoTimer.Enabled)
            {
                UpdateMessageList();
            }
        }

        private void UpdateMessageList()
        {
            lstMessages.Items.Clear();
            var messages = txtMessages.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            foreach (var msg in messages)
            {
                lstMessages.Items.Add(msg);
            }
            btnSetFirst.Enabled = lstMessages.Items.Count > 0 && !autoTimer.Enabled;
            btnShuffle.Enabled = lstMessages.Items.Count > 0 && !autoTimer.Enabled;
        }

        private void UpdateMessageListHighlight()
        {
            lstMessages.Items.Clear();
            
            for (int i = 0; i < messagePool.Count; i++)
            {
                string prefix = "";
                if (i == currentMessageIndex)
                {
                    prefix = "▶ NEXT: ";
                }
                else if (i == (currentMessageIndex + 1) % messagePool.Count)
                {
                    prefix = "◆ AFTER: ";
                }
                
                lstMessages.Items.Add(prefix + messagePool[i]);
            }
            
            if (messagePool.Count > 0)
            {
                lstMessages.TopIndex = Math.Max(0, currentMessageIndex - 2);
            }
        }

        private void btnSetFirst_Click(object sender, EventArgs e)
        {
            if (lstMessages.SelectedIndex >= 0 && lstMessages.SelectedIndex < lstMessages.Items.Count)
            {
                var messages = txtMessages.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                if (lstMessages.SelectedIndex < messages.Count)
                {
                    string selectedMessage = messages[lstMessages.SelectedIndex];
                    messages.RemoveAt(lstMessages.SelectedIndex);
                    messages.Insert(0, selectedMessage);
                    
                    txtMessages.Lines = messages.ToArray();
                    UpdateMessageList();
                    lstMessages.SelectedIndex = 0;
                    
                    lblStatus.Text = "Status: Message moved to first position";
                }
            }
            else
            {
                MessageBox.Show("Please select a message from the list first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessages.Text))
            {
                var messages = txtMessages.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                
                int n = messages.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    string temp = messages[k];
                    messages[k] = messages[n];
                    messages[n] = temp;
                }
                
                txtMessages.Lines = messages.ToArray();
                UpdateMessageList();
                lblStatus.Text = "Status: Messages shuffled";
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Select a text file with messages";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(openFileDialog.FileName);
                        txtMessages.Lines = lines;
                        UpdateMessageList();
                        lblStatus.Text = $"Status: Loaded {lines.Length} messages from file";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
