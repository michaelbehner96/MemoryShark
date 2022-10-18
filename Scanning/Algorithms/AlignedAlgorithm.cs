namespace MemoryShark.Scanning.Algorithms
{
    public class AlignedAlgorithm : IScanAlgorithm
    {
        private readonly uint alignmentOffset;

        public AlignedAlgorithm(uint alignmentOffset)
        {
            this.alignmentOffset = alignmentOffset;
        }

        public unsafe long[] FindMatches(byte[] source, byte?[] pattern)
        {
            var matchIndexes = new List<long>();
            fixed (byte* beginningSourcePointer = source) fixed (byte?* beginningPatternPointer = pattern)
            {
                long matchIndex = 0;
                byte* endSourcePointer = beginningSourcePointer + source.LongLength;
                byte?* endPatternPointer = beginningPatternPointer + pattern.LongLength;
                bool matchFound;
                byte?* currentPatternPointer;

                for (byte* currentSourcePointer = beginningSourcePointer; currentSourcePointer < endSourcePointer; matchIndex+= alignmentOffset, currentSourcePointer+= alignmentOffset)
                {
                    // Extra check to avoid alignment issues
                    if (currentSourcePointer >= endSourcePointer)
                        break;

                    matchFound = true;
                    currentPatternPointer = beginningPatternPointer;
                    for (byte* stepSourcePointer = currentSourcePointer; matchFound && currentPatternPointer < endPatternPointer; matchFound = (*currentPatternPointer).HasValue is false || *currentPatternPointer == *stepSourcePointer, currentPatternPointer++, stepSourcePointer++) ;
                    if (matchFound) matchIndexes.Add(matchIndex);
                }
                return matchIndexes.ToArray();
            }
        }
    }
}
