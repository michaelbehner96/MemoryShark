namespace Sharkbytes.Core
{
   
    #region Scanning

    /*
     * So here's my idea of scanning:
     * 
     * - IScanner:
     *      You have a scanner (e.g. WindowsScanner). It's entire job is to 
     *      pass region-sized byte[] to the IAlgorithum (dependency)
     *      
     * - IAlgorithum:
     *      Takes in byte[] and does the logic for pattern matching. Will allow
     *      us to develop complex pattern matching techniques independent of the
     *      scan logic
     *      
     * - IPattern/ISignature:
     *      Some abstraction around a pattern. Patterns usually consist of structured
     *      data and even wildcards. (could just be a byte?[])
     *      
     * 
     * 
     */

    public interface IScanner
    {
        long[]? Scan(IAlgorithm algorithm, byte?[] signature);
    }
    #endregion


}

