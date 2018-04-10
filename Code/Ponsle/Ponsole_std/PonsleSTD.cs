using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PonsleAPI;

namespace Ponsle_std
{
    [Export(typeof(IPlugin))]
    public class PonsleSTD : IPlugin
    {
        void IPlugin.Init()
        {
            // do nothing
        }

        void IPlugin.Exit()
        {
            // do nothing
        }

        private PluginInfo _pluginInfo = new PluginInfo("Ponsole STD", 1.0f, new string[] { "Ponsole" }, 1.0f);

        PluginInfo IPlugin.pluginInfo => _pluginInfo;
    }
}
