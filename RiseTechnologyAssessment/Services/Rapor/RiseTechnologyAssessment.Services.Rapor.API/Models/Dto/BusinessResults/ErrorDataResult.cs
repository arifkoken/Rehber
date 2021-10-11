namespace RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.BusinessResults
{
    public class ErrorDataResult<T>: DataResult<T>
    {
        public ErrorDataResult(T data, string message,int code) : base(data, false, message,code)
        {
        }
        public ErrorDataResult(T data) : base(data, false)
        {
        }
        public ErrorDataResult(string message,int code) : base(default, false, message,code)
        {

        }
        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
