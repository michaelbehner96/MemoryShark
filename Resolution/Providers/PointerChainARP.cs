
using MemoryShark.Memory;
using MemoryShark.Processes;
using MemoryShark.Resolution.Data;

namespace MemoryShark.Resolution.Providers
{
    public class PointerChainARP : IAddressResolutionProvider<PointerChainResolutionArgs>
    {
        private readonly IMemoryIO memoryIO;
        private readonly IProcessHandler processHandler;

        public PointerChainARP(IMemoryIO memoryIO, IProcessHandler processHandler)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.processHandler = processHandler ?? throw new ArgumentNullException(nameof(processHandler));
        }

        public long Resolve(PointerChainResolutionArgs resolutionArgs)
        {
            long currentAddress = resolutionArgs.BaseAddress.Invoke();
            for (int i = 0; i < resolutionArgs.Offsets.Length; i++)
            {
                long offsetAddress = currentAddress + resolutionArgs.Offsets[i];

                if (i == resolutionArgs.Offsets.Length - 1)
                    return offsetAddress;

                if (processHandler.Is64BitProcess)
                    currentAddress = BitConverter.ToInt64(memoryIO.ReadMemory(offsetAddress, 8));
                else
                    currentAddress = BitConverter.ToInt32(memoryIO.ReadMemory(offsetAddress, 4));
            }

            return currentAddress;
        }
    }
}
