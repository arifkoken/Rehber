using System.Collections.Generic;

namespace RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.ApiResponse
{
    public class ApiListResponseDto<T> where T:IApiListResponseDto
    {
        public int Count { get; set; }
        public IList<T> Lists { get; set; }
    }
}
