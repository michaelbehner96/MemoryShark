using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Objects
{
    public class LoggingMemoryObjectDecorator<T> : IMemoryObject<T>
    {
        private readonly IMemoryObject<T> memoryObject;

        public LoggingMemoryObjectDecorator(IMemoryObject<T> memoryObject)
        {
            this.memoryObject = memoryObject ?? throw new ArgumentNullException(nameof(memoryObject));
        }

        public T Read()
        {
            Console.WriteLine($"Logging Read of type {typeof(T)}");
            return memoryObject.Read();
        }

        public void Write(T value)
        {
            Console.WriteLine($"Logging Write of type {typeof(T)} of value {value}");
            memoryObject.Write(value);
        }
    }
}
