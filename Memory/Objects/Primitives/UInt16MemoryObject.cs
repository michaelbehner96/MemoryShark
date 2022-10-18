using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class UInt16MemoryObject : IMemoryObject<ushort>
    {
        private readonly IMemoryIO memoryIO;

        public long Address { get; set; }

        public UInt16MemoryObject(IMemoryIO memoryIO, long address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public ushort Read()
        {
            return BitConverter.ToUInt16(memoryIO.ReadMemory(Address, (ulong)Marshal.SizeOf<ushort>()));
        }

        public void Write(ushort value)
        {
            memoryIO.WriteMemory(Address, BitConverter.GetBytes(value));
        }
    }
}
