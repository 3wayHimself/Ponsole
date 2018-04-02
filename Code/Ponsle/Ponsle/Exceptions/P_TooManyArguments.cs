using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponsle.Exceptions
{
    class P_TooManyArguments : ApplicationException
    {
        public void PrintExceptionToConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Too many arguments given");
            new _Vars().SetConsoleColor_Default_Foreground();
        }
    }
}
