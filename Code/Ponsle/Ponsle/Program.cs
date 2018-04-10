using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();


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

            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);

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
