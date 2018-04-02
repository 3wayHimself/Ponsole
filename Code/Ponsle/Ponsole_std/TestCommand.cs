using System.ComponentModel.Composition;
using PonsleAPI;

namespace Ponsle_std
{

    [Export(typeof(ICommand))]
    public class TestCommand : ICommand
    {
        private Output output = new Output();

        public bool RequiresArgs => false;

        public string commandName => "testcmd";

        public int argumentLimit => 0;

        public void Run(string[] args)
        {
            output.Put("this command is working");
        }
    }
}
