using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class Int64MemoryObject : IMemoryObject<long>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public Int64MemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public long Read()
        {
            return BitConverter.ToInt64(memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<long>()));
        }

        public void Write(long value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
