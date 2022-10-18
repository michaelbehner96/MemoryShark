using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Memory.Regions
{
    public interface IMemoryRegionAnalyzer<out TRegionInfoModel>
    {
        public TRegionInfoModel Analyze(long address);
    }
}
