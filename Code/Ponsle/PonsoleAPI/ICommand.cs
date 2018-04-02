using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonsleAPI
{
    public interface ICommand
    {
        bool RequiresArgs { get; }
        void Run(string[] args);
        string commandName { get; }
        int argumentLimit { get; }
    }
}
