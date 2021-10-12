namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message,int code) : base(true, message,code)
        {
        }
        public SuccessResult() : base(true)
        {
        }
    }
}
