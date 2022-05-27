using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class BooleanMemoryObject : IMemoryObject<bool>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public BooleanMemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public bool Read()
        {
            return BitConverter.ToBoolean(memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<bool>()));
        }

        public void Write(bool value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
