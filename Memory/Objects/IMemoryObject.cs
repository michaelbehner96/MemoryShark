using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Objects
{
    public interface IMemoryObject<TObject>
    {
        TObject Read();
        void Write(TObject value);
    }
}
