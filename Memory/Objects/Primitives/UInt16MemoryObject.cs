using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class UInt16MemoryObject : IMemoryObject<ushort>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public UInt16MemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public ushort Read()
        {
            return BitConverter.ToUInt16(memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<ushort>()));
        }

        public void Write(ushort value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
