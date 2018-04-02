using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponsle.Exceptions;
using PonsleAPI;
using System.Security.Principal;

namespace Ponsle
{
    class _Main
    {
        //string curent_dir = "C:\\";
        bool exit = false;

        private string[] prevCmds = { };

        public Dictionary<string, IPlugin> _Plugins;
        public Dictionary<string, ICommand> _Commands;

        private SmartUtils.ConsoleOutput consoleOutput = new SmartUtils.ConsoleOutput();

        public bool IsElevated
        {
            get
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public void Main(int argc, string[] argv)
        {
            // Reset cd.txt
            if (!System.IO.File.Exists("cd.txt"))
            {
                System.IO.File.Create("cd.txt");
                System.IO.File.WriteAllLines("cd.txt", new string[] { "C:\\" });
            } else
            {
                System.IO.File.WriteAllLines("cd.txt", new string[] { "C:\\" });
            }
            
            // Listen for Ctrl+C

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                exit = true;
            };

            // Title the window

            if (IsElevated)
            {
                Console.Title = "Ponsle (Administrator)";
            } else
            {
                Console.Title = "Ponsle";
            }

            if (new SmartUtils.Specs.Archetecture().Is32BitOS())
            {
                Console.Clear();
                Console.Write("Ponsle doesn't run on 32Bit windows. Sorry!");
            }

            Console.WriteLine("Loading libaries");
            new SmartUtils.ConsoleOutput().PrintNewLine();

            //load libs
            if (!System.IO.Directory.Exists("Plugins"))
            {
                System.IO.Directory.CreateDirectory("Plugins");
            }

            GenericPluginLoader<IPlugin> loader = new GenericPluginLoader<IPlugin>("Plugins");
            _Plugins = new Dictionary<string, IPlugin>();
            IEnumerable<IPlugin> plugins = loader.Plugins;
            foreach (var item in plugins)
            {
                Console.WriteLine("Importing libary: " + item.pluginInfo.Name);
                _Plugins.Add(item.pluginInfo.Name, item);
                item.Init();
                Console.WriteLine("Imported libary: " + item.pluginInfo.Name);
            }

            System.Threading.Thread.Sleep(1500);

            Console.WriteLine("Importing commands");
            new SmartUtils.ConsoleOutput().PrintNewLine();

            GenericPluginLoader<ICommand> cmdloader = new GenericPluginLoader<ICommand>("Plugins");
            _Commands = new Dictionary<string, ICommand>();
            IEnumerable<ICommand> cmds = cmdloader.Plugins;
            foreach (var item in cmds)
            {
                _Commands.Add(item.commandName, item);
                Console.WriteLine("Imported command: " + item.commandName);
            }

            System.Threading.Thread.Sleep(1500);

            // Main

            Console.Clear();
            Console.WriteLine("Ponsle | The open-source C# terminal");
            consoleOutput.PrintNewLine();

            while (!exit)
            {
                Console.Write(new _Vars().CurrentDir + "> "); // Instance a new coppy of _Vars every time to get the current dir
                string cmd = Console.ReadLine();
                if (cmd == "exit") { exit = true; break; }
                try
                {
                    if (!String.IsNullOrEmpty(cmd) || !String.IsNullOrWhiteSpace(cmd))
                    {
                        RunCmd(cmd.Split(new char[] { ' ' }));
                    }
                } catch (P_CommandNotFoundException e)
                {
                    e.PrintExceptionToConsole();
                } catch (P_TooManyArguments e)
                {
                    e.PrintExceptionToConsole();
                }
            }

            Console.Clear();

            // unload libaries

            Console.WriteLine("Ponsle is about to exit. Unloading libaries...");

            foreach (KeyValuePair<string, IPlugin> plugin in _Plugins)
            {
                plugin.Value.Exit();
                Console.WriteLine(plugin.Key + " has been unloaded");
            }

            System.Threading.Thread.Sleep(1500);
        }

        public void RunCmd(string[] command)
        {
            if (command.Length == 0)
            {
                throw new P_CommandNotFoundException();
            }

            // If exception not thrown then continue
            foreach (KeyValuePair<string, ICommand> cmd in _Commands)
            {
                if (cmd.Key == command[0])
                {
                    // yay were working!
                    if (cmd.Value.RequiresArgs && command.Length == 1)
                    {
                        // no arguments supplied
                        throw new P_NoArgumentsException();
                    } else if (cmd.Value.RequiresArgs && (command.Length - 1) > cmd.Value.argumentLimit)
                    {
                        // too many arguments supplied
                        throw new P_TooManyArguments();
                    } else if (!cmd.Value.RequiresArgs && command.Length > 1)
                    {
                        // too many arguments supplied
                        throw new P_TooManyArguments();
                    } else
                    {
                        // if we finally got here then good luck, we can run the command :D
                        string[] cmdargs = command.Skip(1).ToArray(); // we dont need the 1st object (command[0]) so lets remove it
                        cmd.Value.Run(cmdargs);
                        return;
                    }
                }
            }

            // if we never execute a command throw new exception
            throw new P_CommandNotFoundException();
        }
    }
}
