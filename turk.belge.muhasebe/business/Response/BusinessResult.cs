using entity;
using entity.abstraction;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace business.Response
{
    public abstract class ABusinessResult
    {
        public bool IsSucceeded { get; internal set; } = false;
        public List<ABusinessError>? Errors { get; internal set; } = null;
    }


    public class BusinessResult : ABusinessResult
    {
        public static BusinessResult Success() { return new BusinessResult() { IsSucceeded = true }; }
        public static BusinessResult Fail(ABusinessError error) { return new BusinessResult() { IsSucceeded = false, Errors = new List<ABusinessError>() { error } }; }
        public static BusinessResult Fail(params ABusinessError[] errors) { return new BusinessResult() { IsSucceeded = false, Errors = new List<ABusinessError>(errors) }; }




    }

    public class BusinessResult<TData> : ABusinessResult 
    {
        public TData? Data { get; internal set; }


        public static BusinessResult<TData> Success(TData data) { return new BusinessResult<TData> { IsSucceeded = true, Data = data }; }
        public static BusinessResult<TData> Fail(ABusinessError error) { return new BusinessResult<TData> { IsSucceeded = false, Errors = new List<ABusinessError>() { error } }; }
        public static BusinessResult<TData> Fail(params ABusinessError[] errors) { return new BusinessResult<TData> { IsSucceeded = false, Errors = new List<ABusinessError>(errors) }; }
    }


}
