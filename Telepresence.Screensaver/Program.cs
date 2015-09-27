using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Telepresence.Screensaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check if there were arguments
            if (args.Length > 0)
            {
                // get option in lower case
                string option = args[0].ToLower().Trim();
                string value = null;

                // if option is too long
                if (option.Length > 2)
                {
                    // split value from option
                    value = option.Substring(3).Trim();
                    option = option.Substring(0, 2);
                }
                else if (args.Length > 1)
                {
                    // get option from second argument
                    value = args[1];
                }

                if (option == "/c") // settings mode
                {
                    Settings();
                }
                else if (option == "/p") // preview mode
                {
                    Preview(value);
                }
                else // screensaver mode by default
                {
                    Screensaver();
                }
            }
            else // default to settings mode
            {
                Screensaver();
            }
        }

        static void Preview(string value)
        {
            // check to ensure window handle was provided
            if (value == null)
            {
                MessageBox.Show("Cannot preview without a window handle!", "Telepresence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // create pointer to window handle
            IntPtr handle = new IntPtr(long.Parse(value));

            // run main form in preview mode
            //Application.Run(new Telepresence(handle));
            Application.Run(new Blank(handle));
        }

        static void Settings()
        {
            Application.Run(new Settings());
        }

        static void Screensaver()
        {
            try
            {
                // show and start forms on each screen

                Screen primary = null;
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.Primary)
                    {
                        primary = screen;
                    }
                    else
                    {
#if !DEBUG
                        Blank blank = new Blank(screen.Bounds);
                        blank.Show();
#endif
                    }
                }

                Telepresence telepresence = new Telepresence(primary.Bounds);
                telepresence.Show();

                // continuing running application
                Application.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
