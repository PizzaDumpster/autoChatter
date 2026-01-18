namespace autoChatter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnSetPosition = new Button();
            txtMessage = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            lblStatus = new Label();
            lblPosition = new Label();
            numInterval = new NumericUpDown();
            label1 = new Label();
            chkRandomize = new CheckBox();
            txtMessages = new TextBox();
            label2 = new Label();
            btnLoadFile = new Button();
            lstMessages = new ListBox();
            label3 = new Label();
            btnSetFirst = new Button();
            btnShuffle = new Button();
            ((System.ComponentModel.ISupportInitialize)numInterval).BeginInit();
            SuspendLayout();
            // 
            // btnSetPosition
            // 
            btnSetPosition.Location = new Point(12, 12);
            btnSetPosition.Name = "btnSetPosition";
            btnSetPosition.Size = new Size(200, 40);
            btnSetPosition.TabIndex = 0;
            btnSetPosition.Text = "Set Click Position (5s delay)";
            btnSetPosition.UseVisualStyleBackColor = true;
            btnSetPosition.Click += btnSetPosition_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 88);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Enter message to send";
            txtMessage.Size = new Size(400, 23);
            txtMessage.TabIndex = 1;
            txtMessage.Text = "Hello!";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 280);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 40);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(118, 280);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 40);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 330);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status: Ready";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(12, 55);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(138, 15);
            lblPosition.TabIndex = 5;
            lblPosition.Text = "Position: Not Set";
            // 
            // numInterval
            // 
            numInterval.Location = new Point(12, 251);
            numInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numInterval.Name = "numInterval";
            numInterval.Size = new Size(120, 23);
            numInterval.TabIndex = 6;
            numInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 253);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 7;
            label1.Text = "Interval (minutes)";
            // 
            // chkRandomize
            // 
            chkRandomize.AutoSize = true;
            chkRandomize.Location = new Point(12, 117);
            chkRandomize.Name = "chkRandomize";
            chkRandomize.Size = new Size(265, 19);
            chkRandomize.TabIndex = 8;
            chkRandomize.Text = "Randomize messages (one per line below)";
            chkRandomize.UseVisualStyleBackColor = true;
            chkRandomize.CheckedChanged += chkRandomize_CheckedChanged;
            // 
            // txtMessages
            // 
            txtMessages.Enabled = false;
            txtMessages.Location = new Point(12, 142);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.PlaceholderText = "Enter one message per line";
            txtMessages.ScrollBars = ScrollBars.Vertical;
            txtMessages.Size = new Size(400, 80);
            txtMessages.TabIndex = 9;
            txtMessages.TextChanged += txtMessages_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 10;
            label2.Text = "Message:";
            // 
            // btnLoadFile
            // 
            btnLoadFile.Enabled = false;
            btnLoadFile.Location = new Point(218, 12);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(120, 40);
            btnLoadFile.TabIndex = 11;
            btnLoadFile.Text = "Load from File";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // lstMessages
            // 
            lstMessages.FormattingEnabled = true;
            lstMessages.ItemHeight = 15;
            lstMessages.Location = new Point(418, 142);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(300, 199);
            lstMessages.TabIndex = 12;
            lstMessages.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(418, 124);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 13;
            label3.Text = "Message Queue:";
            label3.Visible = false;
            // 
            // btnSetFirst
            // 
            btnSetFirst.Enabled = false;
            btnSetFirst.Location = new Point(418, 347);
            btnSetFirst.Name = "btnSetFirst";
            btnSetFirst.Size = new Size(120, 30);
            btnSetFirst.TabIndex = 14;
            btnSetFirst.Text = "Set as First";
            btnSetFirst.UseVisualStyleBackColor = true;
            btnSetFirst.Visible = false;
            btnSetFirst.Click += btnSetFirst_Click;
            // 
            // btnShuffle
            // 
            btnShuffle.Enabled = false;
            btnShuffle.Location = new Point(544, 347);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(120, 30);
            btnShuffle.TabIndex = 15;
            btnShuffle.Text = "Shuffle Messages";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Visible = false;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 390);
            Controls.Add(btnShuffle);
            Controls.Add(btnSetFirst);
            Controls.Add(label3);
            Controls.Add(lstMessages);
            Controls.Add(btnLoadFile);
            Controls.Add(label2);
            Controls.Add(txtMessages);
            Controls.Add(chkRandomize);
            Controls.Add(label1);
            Controls.Add(numInterval);
            Controls.Add(lblPosition);
            Controls.Add(lblStatus);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtMessage);
            Controls.Add(btnSetPosition);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Auto Chatter";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)numInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSetPosition;
        private TextBox txtMessage;
        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;
        private Label lblPosition;
        private NumericUpDown numInterval;
        private Label label1;
        private CheckBox chkRandomize;
        private TextBox txtMessages;
        private Label label2;
        private Button btnLoadFile;
        private ListBox lstMessages;
        private Label label3;
        private Button btnSetFirst;
        private Button btnShuffle;
    }
}
