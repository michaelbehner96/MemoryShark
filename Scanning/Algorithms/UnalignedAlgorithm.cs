using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Scanning.Algorithms
{
    public class UnalignedAlgorithm : IScanAlgorithm
    {
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

                for (byte* currentSourcePointer = beginningSourcePointer; currentSourcePointer < endSourcePointer; matchIndex++, currentSourcePointer++)
                {
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
