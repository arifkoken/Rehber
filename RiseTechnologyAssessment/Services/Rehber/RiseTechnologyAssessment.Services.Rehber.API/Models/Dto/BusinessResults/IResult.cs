namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        int Code { get; }
    }
}
