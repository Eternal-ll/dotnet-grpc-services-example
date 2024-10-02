namespace CardsService.Sdk.Grpc
{
    /// <summary>
    /// Additional metadata (trailers) headers
    /// </summary>
    internal static class MetadataHeaders
    {
        /// <summary>
        /// Header for storing error code
        /// </summary>
        internal const string ErrorCodeHeader = "error-code";
    }
}
