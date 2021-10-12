using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults;
namespace RiseTechnologyAssessment.Services.Rehber.API.Business.Abstract
{
    public interface IKisiService
    {
        IDataResult<KisiBilgiDto> KisiOlustur(KisiOlusturDto kisiOlusturDto);
        IResult KisiSil(int kisiId);
        IDataResult<KisiEkBilgiDto> KisiBilgisiOlustur(KisiEkBilgiOlusturDto kisiOlusturDto);
        IResult KisiEkBilgiSil(int kisiEkBilgiId);
        IDataResult<Models.Dto.ApiResponse.ApiListResponseDto<KisiListDto>> Listele();
        IDataResult<KisiDetayDto> Detay(int id);
        IDataResult<KonumaGoreRaporDto> KonumaGoreRehberVerileri(int raporId, int konumId);

   
    }
}
