namespace MemoryShark.Resolution.Data
{
    public class PointerChainResolutionArgs
    {
        public long BaseAddress { get; set; }
        public long[] Offsets { get; set; }

        public PointerChainResolutionArgs(long baseAddress, params long[] offsets)
        {
            BaseAddress = baseAddress;
            Offsets = offsets ?? throw new ArgumentNullException(nameof(offsets));
        }
    }
}
