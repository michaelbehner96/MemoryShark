namespace MemoryShark.Utility
{
    public static class Extensions
    {
        public static string ToHexadecimalAddress(this int i, bool formatAs64Bit = false)
        {
            var format = formatAs64Bit ? "X16" : "X8";
            return "0x" + i.ToString(format);
        }

        public static string ToHexadecimalAddress(this long l, bool formatAs64Bit = false)
        {
            var format = formatAs64Bit ? "X16" : "X8";
            return "0x" + l.ToString(format);
        }

        public static string ToConcatentatedString(this byte[] bytes)
        {
            return String.Join(' ', bytes.Select(b => b.ToString("X2")));
        }

        public static byte?[] ToNullableArray(this byte[] bytes)
        {
            var result = new byte?[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                result[i] = bytes[i];
            }

            return result;
        }

        public static long Kilobytes(long amount)
        {
            return amount * 1024;
        }

        public static long Megabytes(long amount)
        {
            return Kilobytes(amount * 1024);
        }

        public static long Gigabytes(long amount)
        {
            return Megabytes(amount * 1024);
        }

        public static long Align(this long l, long alignment)
        {
            return l + (l % alignment);
        }
    }
}
