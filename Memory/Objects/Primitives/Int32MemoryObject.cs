using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class Int32MemoryObject : IMemoryObject<int>
    {
        private readonly IMemoryIO memoryIO;

        public long Address { get; set; }

        public Int32MemoryObject(IMemoryIO memoryIO, long address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public int Read()
        {
            return BitConverter.ToInt32(memoryIO.ReadMemory(Address, (ulong)Marshal.SizeOf<int>()));
        }

        public void Write(int value)
        {
            memoryIO.WriteMemory(Address, BitConverter.GetBytes(value));
        }
    }
}
