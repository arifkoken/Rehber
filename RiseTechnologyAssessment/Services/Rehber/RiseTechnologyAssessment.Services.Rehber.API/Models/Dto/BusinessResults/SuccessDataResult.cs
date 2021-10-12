namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults
{
    public class SuccessDataResult<T>: DataResult<T>
    {
        public SuccessDataResult(T data, string message,int code) : base(data, true, message,code)
        {
        }
        public SuccessDataResult(T data) : base(data, true)
        {
        }
        public SuccessDataResult(string message,int code) : base(default, true, message,code)
        {

        }
        public SuccessDataResult(string listEmpty) : base(default, true)
        {

        }
    }
}
