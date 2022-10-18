using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory
{
    public class DummyMemoryIO : IMemoryIO
    {
        private readonly Random random;

        public DummyMemoryIO(Random random)
        {
            this.random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public byte[] ReadMemory(long address, ulong length)
        {
            byte[] buffer = new byte[length];
            random.NextBytes(buffer);
            return buffer;
        }

        public void WriteMemory(long address, byte[] value)
        {
            // Empty
        }
    }
}
