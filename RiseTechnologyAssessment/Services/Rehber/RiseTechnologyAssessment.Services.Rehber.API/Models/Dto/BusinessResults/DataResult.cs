  

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message,int code) : base(success, message,code)
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
