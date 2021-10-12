using IResult = RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults.IResult;

namespace RiseTechnologyAssessment.Services.Rehber.API.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
