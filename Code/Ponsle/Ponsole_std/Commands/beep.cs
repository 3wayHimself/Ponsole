using PonsleAPI;
using System;
using System.ComponentModel.Composition;

namespace Ponsle_std.Commands
{
    [Export(typeof(ICommand))]
    public class beep : ICommand
    {
        bool ICommand.RequiresArgs => false;

        string ICommand.commandName => "beep";

        int ICommand.argumentLimit => 0;

        void ICommand.Run(string[] args)
        {
            Console.Beep();
        }
    }
}
