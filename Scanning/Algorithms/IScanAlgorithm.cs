namespace MemoryShark.Scanning.Algorithms
{
    public interface IScanAlgorithm
    {
        long[] FindMatches(byte[] bytes, byte?[] pattern);
    }
}

