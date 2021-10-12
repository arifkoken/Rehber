namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
