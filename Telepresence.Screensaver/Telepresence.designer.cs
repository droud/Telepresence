namespace Telepresence.Screensaver
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
            this._iCLocalClient = new iConfClient.NET.iConfClientDotNet();
            this._iCRemoteClient = new iConfClient.NET.iConfClientDotNet();
            this.SuspendLayout();
            // 
            // _iCLocalClient
            // 
            this._iCLocalClient.AudioJoinDelay = 0;
            this._iCLocalClient.AutoReconnect = false;
            this._iCLocalClient.BackColor = System.Drawing.Color.Gray;
            this._iCLocalClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._iCLocalClient.CallbackObject = null;
            this._iCLocalClient.EncryptedData = false;
            this._iCLocalClient.Location = new System.Drawing.Point(24, 24);
            this._iCLocalClient.Name = "_iCLocalClient";
            this._iCLocalClient.Size = new System.Drawing.Size(320, 240);
            this._iCLocalClient.TabIndex = 0;
            this._iCLocalClient.ClientDisconnected += new iConfClient.NET.iConfClientDotNet.ClientDisconnectedDelegate(this._iCLocalClient_ClientDisconnected);
            this._iCLocalClient.SocketError += new iConfClient.NET.iConfClientDotNet.SocketErrorDelegate(this._iCLocalClient_SocketError);
            this._iCLocalClient.CallRejected += new iConfClient.NET.iConfClientDotNet.CallRejectedDelegate(this._iCLocalClient_CallRejected);
            this._iCLocalClient.CallAccepted += new iConfClient.NET.iConfClientDotNet.CallAcceptedDelegate(this._iCLocalClient_CallAccepted);
            this._iCLocalClient.TextMessageReceived += new iConfClient.NET.iConfClientDotNet.TextMessageReceivedDelegate(this._iCLocalClient_TextMessageReceived);
            this._iCLocalClient.Click += new System.EventHandler(this._iCClient_Click);
            // 
            // _iCRemoteClient
            // 
            this._iCRemoteClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._iCRemoteClient.AudioJoinDelay = 0;
            this._iCRemoteClient.AutoReconnect = false;
            this._iCRemoteClient.BackColor = System.Drawing.Color.DimGray;
            this._iCRemoteClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._iCRemoteClient.CallbackObject = null;
            this._iCRemoteClient.EncryptedData = false;
            this._iCRemoteClient.Location = new System.Drawing.Point(12, 12);
            this._iCRemoteClient.Name = "_iCRemoteClient";
            this._iCRemoteClient.Size = new System.Drawing.Size(616, 456);
            this._iCRemoteClient.TabIndex = 1;
            this._iCRemoteClient.Click += new System.EventHandler(this._iCRemoteClient_Click);
            // 
            // Telepresence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this._iCLocalClient);
            this.Controls.Add(this._iCRemoteClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Telepresence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Telepresence_FormClosing);
            this.Load += new System.EventHandler(this.Telepresence_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private iConfClient.NET.iConfClientDotNet _iCLocalClient;
        private iConfClient.NET.iConfClientDotNet _iCRemoteClient;
    }
}

