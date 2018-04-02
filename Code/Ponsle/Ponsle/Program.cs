using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponsle
{
    class Program
    {
        private static ContextMenu menu;
        private static MenuItem mnuExit;
        private static NotifyIcon notificationIcon;

        static void Main(string[] args)
        {
            // load the tray icon first
            Thread notifyThread = new Thread(
            delegate ()
            {
                menu = new ContextMenu();
                mnuExit = new MenuItem("Exit");
                menu.MenuItems.Add(0, mnuExit);

                notificationIcon = new NotifyIcon()
                {
                    Icon = Properties.Resources.Services,
                    ContextMenu = menu,
                    Text = "Ponsle"
                };
                mnuExit.Click += new EventHandler(mnuExit_Click);

                notificationIcon.Visible = true;
                Application.Run();
            }
        );

            notifyThread.Start();

            new _Main().Main(args.Length, args);
            notificationIcon.Dispose();
            Environment.Exit(0); // Whenn the _Main class exits shutdown the program
        }

        static void mnuExit_Click(object sender, EventArgs e)
        {
            notificationIcon.Dispose();
            Environment.Exit(0);
        }
    }
}
