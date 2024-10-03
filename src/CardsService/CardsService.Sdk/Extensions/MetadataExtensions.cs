using Grpc.Core;

namespace CardsService.Sdk.Extensions
{
    internal static class MetadataExtensions
    {
        public static void Add(this Metadata metadata, string key, ErrorCode value)
            => metadata.Add(key, (int)value);
        public static void Add(this Metadata metadata, string key, int value) =>
            metadata.Add(key, value.ToString());
        public static bool TryGetInt(this Metadata metadata, string key, out int value)
        {
            var intString = metadata.GetValue(key);
            if (intString != null)
            {
                value = int.Parse(intString);
                return true;
            }
            value = 0;
            return false;
        }
        public static bool TryGetErrorCode(this Metadata metadata, string key, out ErrorCode value)
        {
            if (TryGetInt(metadata, key, out var intValue))
            {
                value = (ErrorCode)intValue;
                return true;
            }
            value = ErrorCode.Unknown;
            return false;
        }
    }
}
