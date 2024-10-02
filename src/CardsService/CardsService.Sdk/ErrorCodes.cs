using System.Collections.Generic;

namespace CardsService.Sdk
{
    internal static class ErrorCodes
    {
        private static readonly Dictionary<ErrorCode, string> _errors;
        public static string GetMessage(ErrorCode errorCode)
            => _errors.ContainsKey(errorCode) ? _errors[errorCode] : _errors[ErrorCode.Unknown];

        static ErrorCodes()
        {
            _errors = new Dictionary<ErrorCode, string>()
            {
                { ErrorCode.Unknown, "Unknown internal error" },
                { ErrorCode.CardTypeNotFound, "Card type not found" },
                { ErrorCode.CardNotFound, "Card not found" },
            };
        }
    }
}
