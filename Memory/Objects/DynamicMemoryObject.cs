using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Objects
{
    public class DynamicMemoryObject : IMemoryObject<int>
    {
        private Func<long> getAddress;

        public DynamicMemoryObject(Func<long> address)
        {
            this.getAddress = address ?? throw new ArgumentNullException(nameof(address));
        }

        public int Read()
        {
            Console.WriteLine(getAddress.Invoke());
            return 0;
        }

        public void Write(int value)
        {
            throw new NotImplementedException();
        }
    }
}
