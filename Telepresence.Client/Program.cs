using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telepresence.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (RuntimePolicyHelper.LegacyV2RuntimeEnabledSuccessfully == false)
            {
                // we have a problem!
                MessageBox.Show("Cannot enable V2 runtime crap!");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Telepresence());
        }
    }
}
