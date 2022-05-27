using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class Int16MemoryObject : IMemoryObject<short>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public Int16MemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public short Read()
        {
            return BitConverter.ToInt16(memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<short>()));
        }

        public void Write(short value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
