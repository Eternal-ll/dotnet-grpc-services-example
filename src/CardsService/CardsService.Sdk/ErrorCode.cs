namespace CardsService.Sdk
{
    /// <summary>
    /// Error codes for CardsService domain
    /// </summary>
    public enum ErrorCode : int
    {
        /// <summary>
        /// Unknown internal error
        /// </summary>
        Unknown,
        /// <summary>
        /// Card type not found
        /// </summary>
        CardTypeNotFound,
        /// <summary>
        /// Card not found
        /// </summary>
        CardNotFound,
    }
}
