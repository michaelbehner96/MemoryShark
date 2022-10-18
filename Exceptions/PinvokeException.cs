using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryShark.Exceptions
{
    public class PinvokeException : Exception
    {
        public long ErrorCode { get; private set; }

        public PinvokeException(string methodName, long errorCode)
            : base($"Exception thrown when calling '{methodName}' (code 0x{errorCode.ToString("X4")}[{errorCode}])")
        {
            ErrorCode = errorCode;
        }
    }
}
