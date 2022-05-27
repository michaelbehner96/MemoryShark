using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory
{
    public class LoggingMemoryIODecorator : IMemoryIO
    {
        private readonly IMemoryIO memoryIO;

        public LoggingMemoryIODecorator(IMemoryIO memoryIO)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
        }

        public byte[] ReadMemory(long address, int length)
        {
            Console.WriteLine($"Logging ReadMemory for address=0x{address.ToString("X16")}");
            return memoryIO.ReadMemory(address, length);
        }

        public void WriteMemory(long address, byte[] value)
        {
            Console.WriteLine($"Logging WriteMemory for value={String.Join(' ', value.Select(b => b.ToString("X2")))}");
            memoryIO.WriteMemory(address, value);
        }
    }
}
