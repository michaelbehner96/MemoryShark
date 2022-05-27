namespace Sharkbytes.Core
{
    public interface IAlgorithm
    {
        long[]? FindMatches(byte[] bytes, byte?[] signature);
    }
}

