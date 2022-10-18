using MemoryShark.Scanning.Algorithms;

namespace MemoryShark.Scanning.Scanners
{
    public interface IScanner
    {
        long[] Scan(IScanAlgorithm algorithm, byte?[] signature);
    }
}

