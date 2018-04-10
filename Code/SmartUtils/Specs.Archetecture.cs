using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SmartUtils.Specs
{
    public class Archetecture
    {
        public bool Is32BitOS()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return false;
            }

            return true;
        }

        public bool Is64BitOS()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return true;
            }

            return false;
        }
        
    }

    
}
