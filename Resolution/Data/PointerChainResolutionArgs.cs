namespace MemoryShark.Resolution.Data
{
    public class PointerChainResolutionArgs
    {
        public Func<long> BaseAddress { get; set; }
        public long[] Offsets { get; set; }

        public PointerChainResolutionArgs(Func<long> baseAddress, params long[] offsets)
        {
            BaseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            Offsets = offsets ?? throw new ArgumentNullException(nameof(offsets));
        }
    }
}
