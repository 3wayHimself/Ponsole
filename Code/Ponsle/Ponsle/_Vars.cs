using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponsle
{
   class _Vars
    {
        // Vars

        public string CurrentDir = "C:\\";
        public ConsoleColor ConsoleColor_Default_Foreground = ConsoleColor.White;
        public ConsoleColor ConsoleColor_Default_Background = ConsoleColor.Black;

        // public init

       public _Vars()
        {
            UpdateCurrentDir();
        }

        // Voids

        public void UpdateCurrentDir()
        {
            string[] lines = System.IO.File.ReadAllLines(@"cd.txt");
            CurrentDir = lines[0];
        }

        public void SetConsoleColor_Default_Foreground()
        {
            Console.ForegroundColor = ConsoleColor_Default_Foreground;
        }

        public void SetConsoleColor_Default_Background()
        {
            Console.BackgroundColor = ConsoleColor_Default_Background;
        }
    }
}
