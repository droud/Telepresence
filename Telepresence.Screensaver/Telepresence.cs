using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Collections;
using iConfServer.NET.HelperClasses;

namespace Telepresence.Screensaver
{
    public partial class Telepresence : Form
    {
        #region Interop and external call imports
        
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
        
        #endregion

        #region Constructors

        // constructor for display
        public Telepresence(Rectangle Bounds)
        {
            InitializeComponent();

            this.Bounds = Bounds;

            LoadSettings();

            Refresh();
        }

        // constructor for preview
        public Telepresence(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            LoadSettings(); // sets _path

            Refresh();
        }

        #endregion

        #region Settings loading

        // loads settings from the registry
        private void LoadSettings()
        {
            // Get the value stored in the Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\droud\\Telepresence");
            try
            {
                // load settings
            }
            catch
            {
                // use defaults
           }
        }

        #endregion

        #region Form and control events

        // prepares form and calls local machine
        private void Telepresence_Load(object sender, EventArgs e)
        {
#if !DEBUG
            // hide cursor
            Cursor.Hide();

            // make sure form is on top
            this.TopMost = true;
#endif
            // call localhost
            var localip = "192.168.1.2";
            _iCLocalClient.Call(localip, 9990, 0, 0, "Screensaver", null, localip, 0, 0, 0, "");

            // first display
            Refresh();
        }

        private void Telepresence_FormClosing(object sender, FormClosingEventArgs e)
        {
            _iCLocalClient.Disconnect();
            _iCRemoteClient.Disconnect();
        }
        #endregion

        private void _iCClient_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _iCRemoteClient_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _iCLocalClient_SocketError(Exception ex)
        {

        }

        private void _iCLocalClient_CallRejected(string RejectionMessage)
        {

        }

        private void _iCLocalClient_ClientDisconnected(object sender, string ipAddress, int port)
        {

        }

        private void _iCLocalClient_TextMessageReceived(string messageReceived)
        {
        }

        private void _iCLocalClient_CallAccepted(string acceptMessage)
        {
            // connect to the remote ip

            var localip = "192.168.1.2";
            if (string.IsNullOrWhiteSpace(acceptMessage) == false)
            {
                Invoke(new MethodInvoker(delegate
                {
                    _iCRemoteClient.Call(acceptMessage, 9990, 0, 0, "Screensaver", null, localip, 0, 0, 0, "");
                    _iCRemoteClient.Mute(true);
                }));
            }
        }
    }
}
