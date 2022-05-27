
using MemoryShark.Memory;
using MemoryShark.Processes;
using MemoryShark.Resolution.Data;
using System.Diagnostics;

namespace MemoryShark.Resolution.Providers
{
    public class ModuleARP : IAddressResolutionProvider<ModuleResolutionArgs>
    {
        private readonly IMemoryIO memoryIO;
        private readonly IProcessHandler processHandler;

        public ModuleARP(IMemoryIO memoryIO, IProcessHandler processHandler)
        {
            this.memoryIO = memoryIO ?? throw new ArgumentNullException(nameof(memoryIO));
            this.processHandler = processHandler ?? throw new ArgumentNullException(nameof(processHandler));
        }

        public long Resolve(ModuleResolutionArgs resolutionArgs)
        {
            if (String.IsNullOrEmpty(resolutionArgs.ModuleName))
                throw new ArgumentNullException(nameof(resolutionArgs.ModuleName), $"{nameof(resolutionArgs.ModuleName)} cannot be null or empty.");

            ProcessModule? module = processHandler.Process.Modules.Cast<ProcessModule>().SingleOrDefault(m => string.Equals(resolutionArgs.ModuleName, m.ModuleName, StringComparison.OrdinalIgnoreCase));

            if (module == null)
                throw new NullReferenceException($"No module named {resolutionArgs.ModuleName} loaded by process ID: {processHandler.Process.Id}.");

            return (long)module.BaseAddress;
        }
    }
}
