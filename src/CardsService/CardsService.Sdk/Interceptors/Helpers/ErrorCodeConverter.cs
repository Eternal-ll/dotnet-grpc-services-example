using Grpc.Core;

namespace CardsService.Sdk.Interceptors.Helpers
{
    internal static class ErrorCodeConverter
    {
        public static StatusCode ConvertToStatusCode(this ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.Unknown: return StatusCode.Unknown;
                case ErrorCode.CardTypeNotFound: return StatusCode.InvalidArgument;
                case ErrorCode.CardNotFound: return StatusCode.NotFound;
                default: return StatusCode.Unknown;
            }
        }
    }
}
