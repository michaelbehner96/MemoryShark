namespace MemoryShark.Memory.Allocation
{
    public interface IMemoryDeallocator
    {
        public void Deallocate(long baseAddress);
    }
}
