using System;
using System.Linq;
using MassTransit;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rapor.API.Constants;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Db;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.ApiResponse;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.BusinessResults;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.MassTransit;

namespace RiseTechnologyAssessment.Services.Rapor.API.Business.Concrete
{
    public class RaporService:IRaporService
    {
        private readonly RaporContext _context;

        public RaporService(RaporContext context)
        {
            _context = context;
        }


        public IDataResult<RaporMessageDto> TalepOlustur(RaporTalepDto raporTalepDto)
        {

            var rapor = new Models.Db.Rapor { KonumId = raporTalepDto.KonumId, KonumAd = raporTalepDto.KonumAd, TalepZamani = DateTime.Now };
            _context.Add(rapor);
            _context.SaveChanges();
            var result =new RaporMessageDto { RaporId = rapor.Id, KonumId = rapor.KonumId };
            return new SuccessDataResult<RaporMessageDto>(result);

        }



        public IResult RaporOlustur(KonumaGoreRaporDto konumaGoreRaporDto)
        {
            var findResult = _context.Rapors.FirstOrDefault(x => x.Id == konumaGoreRaporDto.RaporId);
            if (findResult == null)
            {
                return new ErrorResult();
            }
            findResult.ToplamKisiSayisi = konumaGoreRaporDto.TopKisiSayisi;
            findResult.ToplamTelefonNoSayisi = konumaGoreRaporDto.ToplamTelefonNoSayisi;
            findResult.OlusturmaZamani = DateTime.Now;
            _context.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<ApiListResponseDto<RaporListDto>> Listele()
        {
            // Todo Filtreleme özelliği olmadığı için Take(100) kısıtı kaldırılacak.
            var orderedList = _context.Rapors.OrderByDescending(x => x.Id).Take(100).ToList().Select(x => new RaporListDto()
            {
                RaporId = x.Id,
                TalepZamani = x.TalepZamani,
                Durum = x.OlusturmaZamani == null ? "Hazırlanıyor" : "Tamamlandı"

            });

            var apiResponseList = new ApiListResponseDto<RaporListDto>()
            {
                Count = orderedList.Count(),
                Lists = orderedList.ToList()
            };

            return apiResponseList.Count < 1 ?
                new SuccessDataResult<ApiListResponseDto<RaporListDto>>(Messages.ListEmpty) :
                new SuccessDataResult<ApiListResponseDto<RaporListDto>>(apiResponseList);
        }

        public IDataResult<RaporDetayDto> Detay(int id)
        {
            var rapor = _context.Rapors.FirstOrDefault(x => x.Id == id);
            if (rapor == null)
            {
                return new ErrorDataResult<RaporDetayDto>(Messages.NotFounted, 404);
            }

            if (rapor.OlusturmaZamani == null)
            {
                //Todo Hata Turünün düzenlenmesi gerekiyor.
                return new ErrorDataResult<RaporDetayDto>(Messages.NotReady, 404);
            }

            var result = new RaporDetayDto()
            {
                RaporId = rapor.Id,
                KonumId = rapor.KonumId,
                KonumAd = rapor.KonumAd,
                ToplamKisiSayisi = (int)rapor.ToplamKisiSayisi,
                ToplamTelefonNoSayisi = (int)rapor.ToplamTelefonNoSayisi,
                TalepZamani = rapor.TalepZamani,
                OlusturmaZamani = (DateTime)rapor.OlusturmaZamani,
                Durum = "Tamamlandı"

            };

            return new SuccessDataResult<RaporDetayDto>(result);
        }

        #region Check



        #endregion
    }
}
