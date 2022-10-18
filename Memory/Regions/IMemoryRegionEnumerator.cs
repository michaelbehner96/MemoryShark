namespace MemoryShark.Memory.Regions
{
    public interface IMemoryRegionEnumerator<out TRegionModel>
    {
        public IEnumerable<TRegionModel> EnumerateMemoryRegions();
    }
}