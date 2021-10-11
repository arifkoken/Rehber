using System;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.ApiResponse;

namespace RiseTechnologyAssessment.Services.Rapor.API.Models.Dto
{
    public class RaporListDto : IApiListResponseDto
    { 
        public int RaporId { get; set; }
        public DateTime TalepZamani { get; set; }
        public string Durum { get; set; }

    }
}
