namespace RotmgPCap.Packets.DataTypes
{
    internal class ReadResult
    {
        internal readonly int BytesRead;
        internal readonly int StreamPosition;
        internal readonly string StringValue;
        internal readonly object RawValue;
        internal readonly string ErrorMessage;

        internal bool Error => ErrorMessage != null;

        internal ReadResult(int bytesRead, int streamPosition, object result, string errorMessage = null)
        {
            BytesRead = bytesRead;
            StreamPosition = streamPosition;
            ErrorMessage = errorMessage;

            RawValue = result;
            StringValue = result == null ? "null" : result.ToString();
        }

        internal bool TryParseInt(out int result) => int.TryParse(StringValue, out result);
    }
}
