namespace SimpleTCPServer
{
    partial class FormServer
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
            this.lblServer = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.txtMsgInput = new System.Windows.Forms.TextBox();
            this.listConnectedIP = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(31, 29);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(66, 15);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "This Server:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(41, 384);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(56, 15);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Message:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(103, 26);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(478, 23);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = "127.0.0.1:5440";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(103, 55);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.ReadOnly = true;
            this.txtBox.Size = new System.Drawing.Size(478, 320);
            this.txtBox.TabIndex = 1;
            // 
            // txtMsgInput
            // 
            this.txtMsgInput.Location = new System.Drawing.Point(103, 381);
            this.txtMsgInput.Name = "txtMsgInput";
            this.txtMsgInput.Size = new System.Drawing.Size(478, 23);
            this.txtMsgInput.TabIndex = 1;
            // 
            // listConnectedIP
            // 
            this.listConnectedIP.FormattingEnabled = true;
            this.listConnectedIP.ItemHeight = 15;
            this.listConnectedIP.Location = new System.Drawing.Point(587, 55);
            this.listConnectedIP.Name = "listConnectedIP";
            this.listConnectedIP.Size = new System.Drawing.Size(169, 319);
            this.listConnectedIP.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(506, 410);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(597, 380);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(681, 381);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listConnectedIP);
            this.Controls.Add(this.txtMsgInput);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblServer);
            this.MaximizeBox = false;
            this.Name = "FormServer";
            this.Text = "TCP/IP Server";
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblServer;
        private Label lblMsg;
        private TextBox txtIp;
        private TextBox txtBox;
        private TextBox txtMsgInput;
        private ListBox listConnectedIP;
        private Button btnSend;
        private Button btnStart;
        private Button btnClose;
    }
}