using System;
using System.Collections.Generic;
using System.Text;

namespace CardsService.Sdk.Exceptions
{
    /// <summary>
    /// CardsService domain exception
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Error code
        /// </summary>
        public ErrorCode ErrorCode { get; private set; }
        public ServiceException(ErrorCode errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
