using service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Response
{


    public abstract class AServiceResult
    {
        public bool IsSucceeded { get; internal set; }
        public string[]? ErrorMessages { get; internal set; } = null;
    }

    public class ServiceResult<Tdto> : AServiceResult
    {
        public Tdto? Dto { get; internal set; }

        public static ServiceResult<Tdto> Success(Tdto dto) { return new ServiceResult<Tdto> { Dto = dto, IsSucceeded = true }; }
        public static ServiceResult<Tdto> Fail(params string[] errorMessages) { return new ServiceResult<Tdto> { IsSucceeded = false, ErrorMessages = errorMessages }; }
    }

    public class ServiceResult : AServiceResult
    {
        public static ServiceResult Success() { return new ServiceResult { IsSucceeded = true }; }
        public static ServiceResult Fail(params string[] errorMessages) { return new ServiceResult { IsSucceeded = false, ErrorMessages = errorMessages }; }
    }

}
