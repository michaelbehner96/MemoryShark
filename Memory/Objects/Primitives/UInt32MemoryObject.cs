using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class UInt32MemoryObject : IMemoryObject<uint>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public UInt32MemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public uint Read()
        {
            return BitConverter.ToUInt32(memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<uint>()));
        }

        public void Write(uint value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
