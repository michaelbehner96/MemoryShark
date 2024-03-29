﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory
{
    public interface IMemoryIO
    {
        byte[] ReadMemory(long address, ulong length);

        void WriteMemory(long address, params byte[] value);
    }
}
