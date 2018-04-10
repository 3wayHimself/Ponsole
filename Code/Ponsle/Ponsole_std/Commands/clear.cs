using PonsleAPI;
using System;
using System.ComponentModel.Composition;

namespace Ponsle_std.Commands
{
    [Export(typeof(ICommand))]
    public class clear : ICommand
    {
        bool ICommand.RequiresArgs => false;

        string ICommand.commandName => "clear";

        int ICommand.argumentLimit => 0;

        void ICommand.Run(string[] args)
        {
            Console.Clear();
        }
    }
}
