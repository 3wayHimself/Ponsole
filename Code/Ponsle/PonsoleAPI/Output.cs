using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonsleAPI
{
    public class Output
    {

        public void Put(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void Error(string message)
        {

        }
    }
}
