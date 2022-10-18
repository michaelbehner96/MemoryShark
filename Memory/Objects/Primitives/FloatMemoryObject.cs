using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class FloatMemoryObject : IMemoryObject<float>
    {
        private readonly IMemoryIO memoryIO;

        public long Address { get; set; }

        public FloatMemoryObject(IMemoryIO memoryIO, long address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public float Read()
        {
            return BitConverter.ToSingle(memoryIO.ReadMemory(Address, (ulong)Marshal.SizeOf<float>()));
        }

        public void Write(float value)
        {
            memoryIO.WriteMemory(Address, BitConverter.GetBytes(value));
        }
    }
}
