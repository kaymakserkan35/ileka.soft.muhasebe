using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Response
{
    public enum ErrorCodeEnum
    {
        ValidationException, DataAccessException, NullException, JunkTableError
    }

    public abstract class ABusinessError
    {

        public ABusinessError(ErrorCodeEnum errorCode)
        {
            this.ErrorCode = errorCode;
        }
        public ErrorCodeEnum ErrorCode { get; internal set; }
        public string ErrorValue { get; internal set; }

        public override string ToString()
        {
            
            return $"{ErrorCode.ToString()} : {ErrorValue}";
        }
    }

    public class NullError : ABusinessError
    {
        public NullError(string errorValue) : base(ErrorCodeEnum.NullException)
        {
            ErrorValue = errorValue;
        }
    }

    public class ValidationError : ABusinessError
    {
        public ValidationError(string errorValue) : base(ErrorCodeEnum.ValidationException)
        {
            this.ErrorValue = errorValue;
        }
    }
    public class DataAccessError : ABusinessError
    {
        public DataAccessError(string errorValue) : base(ErrorCodeEnum.DataAccessException)
        {
            this.ErrorValue = errorValue;
        }
    }
    public class JunkTableListingError : ABusinessError
    {
        public JunkTableListingError(string errorValue) : base(ErrorCodeEnum.JunkTableError)
        {
            this.ErrorValue = errorValue;
        }
    }

}
