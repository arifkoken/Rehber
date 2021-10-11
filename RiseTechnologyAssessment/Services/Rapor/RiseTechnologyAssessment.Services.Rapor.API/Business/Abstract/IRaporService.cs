using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.ApiResponse;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.BusinessResults;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.MassTransit;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract
{
    public interface IRaporService
    {
        IDataResult<RaporMessageDto> TalepOlustur(RaporTalepDto raporTalepDto);

        IResult RaporOlustur(KonumaGoreRaporDto konumaGoreRaporDto);

        IDataResult<ApiListResponseDto<RaporListDto>> Listele();

        IDataResult<RaporDetayDto> Detay(int id);
    }
}
