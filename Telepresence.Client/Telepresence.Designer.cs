namespace Telepresence.Client
{
    partial class Telepresence
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._iCClient = new iConfClient.NET.iConfClientDotNet();
            this._iCServer = new iConfServer.NET.iConfServerDotNet();
            this._txtAddress = new System.Windows.Forms.TextBox();
            this._btnConnect = new System.Windows.Forms.Button();
            this._rtbLog = new System.Windows.Forms.RichTextBox();
            this._btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _iCClient
            // 
            this._iCClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._iCClient.AudioJoinDelay = 0;
            this._iCClient.AutoReconnect = false;
            this._iCClient.BackColor = System.Drawing.Color.DimGray;
            this._iCClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._iCClient.CallbackObject = null;
            this._iCClient.EncryptedData = false;
            this._iCClient.Location = new System.Drawing.Point(12, 12);
            this._iCClient.Name = "_iCClient";
            this._iCClient.Size = new System.Drawing.Size(600, 444);
            this._iCClient.TabIndex = 0;
            this._iCClient.Log += new iConfClient.NET.iConfClientDotNet.LogDelegate(this._iCClient_Log);
            this._iCClient.ClientDisconnected += new iConfClient.NET.iConfClientDotNet.ClientDisconnectedDelegate(this._iCClient_ClientDisconnected);
            this._iCClient.SocketError += new iConfClient.NET.iConfClientDotNet.SocketErrorDelegate(this._iCClient_SocketError);
            this._iCClient.CallRejected += new iConfClient.NET.iConfClientDotNet.CallRejectedDelegate(this._iCClient_CallRejected);
            this._iCClient.CallAccepted += new iConfClient.NET.iConfClientDotNet.CallAcceptedDelegate(this._iCClient_CallAccepted);
            this._iCClient.TextMessageReceived += new iConfClient.NET.iConfClientDotNet.TextMessageReceivedDelegate(this._iCClient_TextMessageReceived);
            // 
            // _iCServer
            // 
            this._iCServer.BackColor = System.Drawing.Color.Gray;
            this._iCServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._iCServer.CallbackObject = null;
            this._iCServer.EncryptedData = false;
            this._iCServer.Location = new System.Drawing.Point(24, 24);
            this._iCServer.Name = "_iCServer";
            this._iCServer.Proxy = null;
            this._iCServer.ProxyVideo = null;
            this._iCServer.Size = new System.Drawing.Size(160, 120);
            this._iCServer.TabIndex = 1;
            this._iCServer.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantBitRate;
            this._iCServer.VideoPreviewStarted += new iConfServer.NET.iConfServerDotNet.VideoPreviewStartedDelegate(this._iCServer_VideoPreviewStarted);
            this._iCServer.TextMessageReceived += new iConfServer.NET.iConfServerDotNet.TextMessageReceivedDelegate(this._iCServer_TextMessageReceived);
            this._iCServer.ClientDisconnected += new iConfServer.NET.iConfServerDotNet.ClientDisconnectedDelegate(this._iCServer_ClientDisconnected);
            this._iCServer.ClientConnectionLost += new iConfServer.NET.iConfServerDotNet.ClientConnectionLostDelegate(this._iCServer_ClientConnectionLost);
            this._iCServer.IncomingCall += new iConfServer.NET.iConfServerDotNet.IncomingCallDelegate(this._iCServer_IncomingCall);
            this._iCServer.CannotRunGraph += new iConfServer.NET.iConfServerDotNet.CannotRunGraphDelegate(this._iCServer_CannotRunGraph);
            this._iCServer.Log += new iConfServer.NET.iConfServerDotNet.LogDelegate(this._iCServer_Log);
            // 
            // _txtAddress
            // 
            this._txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtAddress.Location = new System.Drawing.Point(13, 464);
            this._txtAddress.Name = "_txtAddress";
            this._txtAddress.Size = new System.Drawing.Size(198, 20);
            this._txtAddress.TabIndex = 3;
            // 
            // _btnConnect
            // 
            this._btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnConnect.Location = new System.Drawing.Point(12, 490);
            this._btnConnect.Name = "_btnConnect";
            this._btnConnect.Size = new System.Drawing.Size(199, 49);
            this._btnConnect.TabIndex = 4;
            this._btnConnect.Text = "Connect";
            this._btnConnect.UseVisualStyleBackColor = true;
            this._btnConnect.Click += new System.EventHandler(this._btnConnect_Click);
            // 
            // _rtbLog
            // 
            this._rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._rtbLog.Location = new System.Drawing.Point(217, 463);
            this._rtbLog.Name = "_rtbLog";
            this._rtbLog.Size = new System.Drawing.Size(395, 130);
            this._rtbLog.TabIndex = 5;
            this._rtbLog.Text = "";
            // 
            // _btnDisconnect
            // 
            this._btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDisconnect.Location = new System.Drawing.Point(13, 545);
            this._btnDisconnect.Name = "_btnDisconnect";
            this._btnDisconnect.Size = new System.Drawing.Size(199, 48);
            this._btnDisconnect.TabIndex = 6;
            this._btnDisconnect.Text = "Disconnect";
            this._btnDisconnect.UseVisualStyleBackColor = true;
            this._btnDisconnect.Click += new System.EventHandler(this._btnDisconnect_Click);
            // 
            // Telepresence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 605);
            this.Controls.Add(this._btnDisconnect);
            this.Controls.Add(this._rtbLog);
            this.Controls.Add(this._btnConnect);
            this.Controls.Add(this._txtAddress);
            this.Controls.Add(this._iCServer);
            this.Controls.Add(this._iCClient);
            this.Name = "Telepresence";
            this.Text = "Telepresence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Telepresence_FormClosing);
            this.Load += new System.EventHandler(this.Telepresence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private iConfClient.NET.iConfClientDotNet _iCClient;
        private iConfServer.NET.iConfServerDotNet _iCServer;
        private System.Windows.Forms.TextBox _txtAddress;
        private System.Windows.Forms.Button _btnConnect;
        private System.Windows.Forms.RichTextBox _rtbLog;
        private System.Windows.Forms.Button _btnDisconnect;
    }
}

