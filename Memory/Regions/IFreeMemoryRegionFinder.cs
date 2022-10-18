using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Regions
{
    public interface IFreeMemoryRegionFinder<TRegionModel>
    {
        public TRegionModel FindFreeRegion(long? nearThisAddress);
    }
}
