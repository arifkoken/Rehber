namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults
{
    public class Result:IResult
    {
        public Result(bool success, string message,int code):this(success)
        {
            Message = message;
            Code = code;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
        public int Code { get; }
    }
}
