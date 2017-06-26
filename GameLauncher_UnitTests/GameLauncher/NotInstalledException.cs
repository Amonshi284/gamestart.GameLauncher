using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher
{
    class NotInstalledException : Exception
    {
        public NotInstalledException(string message)
        {
        }
    }
}
