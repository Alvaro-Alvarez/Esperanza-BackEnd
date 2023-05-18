using Esperanza.Core.Enums;

namespace Esperanza.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public BusinessException(ErrorCode errorCode) : base()
        {
            ErrorCode = errorCode;
        }
    }
}
