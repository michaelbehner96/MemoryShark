using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Processes
{
    public interface IProcessHandler
    {
        public Process Process { get; }
        public bool Is64BitProcess { get; }

    }
}
