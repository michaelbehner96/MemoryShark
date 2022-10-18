using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class UInt64MemoryObject : IMemoryObject<ulong>
    {
        private readonly IMemoryIO memoryIO;

        public long Address { get; set; }

        public UInt64MemoryObject(IMemoryIO memoryIO, long address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public ulong Read()
        {
            return BitConverter.ToUInt64(memoryIO.ReadMemory(Address, (ulong)Marshal.SizeOf<ulong>()));
        }

        public void Write(ulong value)
        {
            memoryIO.WriteMemory(Address, BitConverter.GetBytes(value));
        }
    }
}
