using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Telepresence.Screensaver
{
    public partial class Settings : Form
    {
        #region Constructor

        // constructor loads settings
        public Settings()
        {
            InitializeComponent();

            LoadSettings();
        }

        #endregion

        #region Setting loading and saving

        // saves settings to the registry
        private void SaveSettings()
        {
            // create or get subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\droud\\Telepresence");

            // save values
        }

        private void LoadSettings()
        {
            // create or get subkey
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\droud\\Telepresence");

            try
            {
                // set about text
                lblVersion.Text = "Version " + this.ProductVersion + " by droud.";
            }
            catch
            {
                // use default values
            }
        }

        #endregion

        #region Form and control events

        // handle ok button
        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Close();
        }

        #endregion

    }
}
