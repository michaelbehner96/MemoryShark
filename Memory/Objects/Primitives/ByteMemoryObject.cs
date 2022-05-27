using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class ByteMemoryObject : IMemoryObject<byte>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public ByteMemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public byte Read()
        {
            return memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<byte>())[0];
        }

        public void Write(byte value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
