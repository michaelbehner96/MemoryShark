using MemoryShark.Memory;
using MemoryShark.Processes;

namespace MemoryShark.Resolution
{
    public class BasicAddressResolver : IAddressResolver
    {
        private readonly IMemoryIO memoryIO;
        private readonly IProcessHandler processHandler;

        public BasicAddressResolver(IMemoryIO memoryIO, IProcessHandler processHandler)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.processHandler = processHandler ?? throw new ArgumentNullException(nameof(processHandler));
        }

        public long Resolve(long address, params byte[] offsets)
        {
            for (int i = 0; i < offsets.Length; i++)
            {
                byte offset = offsets[i];
                long offsetAddress = address + offset;
                bool isFinalOffset = i == offsets.Length - 1;

                if (isFinalOffset)
                    return offsetAddress;

                if (processHandler.Is64BitProcess)
                    address = BitConverter.ToInt64(memoryIO.ReadMemory(offsetAddress, 8));
                else
                    address = BitConverter.ToInt32(memoryIO.ReadMemory(offsetAddress, 4));
            }

            return address;
        }
    }
}
