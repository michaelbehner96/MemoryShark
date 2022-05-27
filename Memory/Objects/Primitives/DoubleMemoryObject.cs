using System.Runtime.InteropServices;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class DoubleMemoryObject : IMemoryObject<double>
    {
        private readonly IMemoryIO memoryIO;

        public Func<long> Address { get; set; }

        public DoubleMemoryObject(IMemoryIO memoryIO, Func<long> address)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Address = address;
        }

        public double Read()
        {
            return BitConverter.ToDouble(memoryIO.ReadMemory(Address.Invoke(), Marshal.SizeOf<double>()));
        }

        public void Write(double value)
        {
            memoryIO.WriteMemory(Address.Invoke(), BitConverter.GetBytes(value));
        }
    }
}
