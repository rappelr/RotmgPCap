using System;

namespace RotmgPCap.Util
{
    internal static class TimeUtil
    {
        internal static long CurrentUnix() => new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

        internal static string FormatFullUnix(long unix) => DateTimeOffset.FromUnixTimeSeconds(unix).DateTime.ToLocalTime().ToString();

        internal static string FormatShortUnix(long unix) => DateTimeOffset.FromUnixTimeSeconds(unix).DateTime.ToLocalTime().ToString("HH:mm:ss");
    }
}
