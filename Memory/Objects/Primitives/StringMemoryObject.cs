using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Objects.Primitives
{
    public class StringMemoryObject : IMemoryObject<string>
    {
        private readonly IMemoryIO memoryIO;

        public long Address { get; set; }
        public Encoding Encoding { get; set; }
        public int MaxLengthInBytes { get; set; }

        public StringMemoryObject(IMemoryIO memoryIO, long address, Encoding encoding, int maxLengthInBytes)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
            this.Address = address;
            this.MaxLengthInBytes = maxLengthInBytes;
        }

        public string Read()
        {
            return Encoding.GetString(memoryIO.ReadMemory(Address, (ulong)MaxLengthInBytes));
        }

        public void Write(string value)
        {
            var bytes = Encoding.GetBytes(value);

            // If our string will take more bytes than specified max, throw error
            // to prevent writing over memory that isn't our intended string.
            if (bytes.Length > MaxLengthInBytes)
                throw new Exception($"The string '{value}' is {bytes.Length} byte(s) in length, which is greater than the set maximum of {MaxLengthInBytes}.");
            
            memoryIO.WriteMemory(Address, Encoding.GetBytes(value));
        }
    }
}
