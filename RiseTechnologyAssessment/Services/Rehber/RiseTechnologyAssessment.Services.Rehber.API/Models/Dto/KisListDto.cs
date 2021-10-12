using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.ApiResponse;

namespace RiseTechnologyAssessment.Services.Rehber.API.Models.Dto
{
    public class KisiListDto: IApiListResponseDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
