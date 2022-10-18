using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Allocation
{
    public interface IMemoryAllocator
    {
        public long Allocate(long? baseAddress, uint sizeInBytes);
    }
}
