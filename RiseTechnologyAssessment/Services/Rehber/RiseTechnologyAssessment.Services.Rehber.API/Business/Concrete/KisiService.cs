

using System.Linq;
using Microsoft.EntityFrameworkCore;
using RiseTechnologyAssessment.Services.Rehber.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rehber.API.Constants;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Db;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Dto.BusinessResults;
using RiseTechnologyAssessment.Services.Rehber.API.Models.Enum;

namespace RiseTechnologyAssessment.Services.Rehber.API.Business.Concrete
{
    public class KisiService : IKisiService
    {
        private readonly RehberContext _context;
        public KisiService(RehberContext context)
        {
            _context = context;
        }
        public IDataResult<KisiBilgiDto> KisiOlustur(KisiOlusturDto kisiOlusturDto)
        {
            var hataResult = BusinessRules.Run(AdSoyadVarMi(kisiOlusturDto.Ad,kisiOlusturDto.Soyad));
            if (hataResult != null)
            {
                return new ErrorDataResult<KisiBilgiDto>(hataResult.Message, 403);
            }
            var kisiAdd = new Kisi()
            {
                Ad = kisiOlusturDto.Ad,
                Soyad = kisiOlusturDto.Soyad,
                SilindiMi = false,
                Firma = kisiOlusturDto.Firma,
                KonumId = kisiOlusturDto.KonumId
            };
            _context.Add(kisiAdd);
            _context.SaveChanges();
            //Todo Konum Adı Ekle ,HttpResponse codunu düzenle
            var konumAd = _context.Konums.FirstOrDefault(x => x.Id == kisiOlusturDto.KonumId).Ad;
            return new SuccessDataResult<KisiBilgiDto>(new KisiBilgiDto() {Id=kisiAdd.Id,Ad=kisiAdd.Ad,Soyad=kisiAdd.Soyad,Firma=kisiAdd.Firma,KonumId=kisiAdd.KonumId,Konum=konumAd }, Messages.Added, 201);
        }

        public IResult KisiSil(int kisiId)
        {
            var findResult = _context.Kisis.FirstOrDefault(x => x.Id == kisiId && x.SilindiMi == false);
            if (findResult == null)
            {
                return new ErrorDataResult<KisiBilgiDto>(Messages.NotFounted, 404);
            }
            findResult.SilindiMi = true;
            var updateKisi = _context.Update(findResult);
            _context.SaveChanges();
            return new SuccessResult(Messages.Deleted, 200);
        }

        public IDataResult<KisiEkBilgiDto> KisiBilgisiOlustur(KisiEkBilgiOlusturDto kisiEkBilgiOlustur)
        {
            IResult hataResult = BusinessRules.Run(BilgiTuruVarMi(kisiEkBilgiOlustur.KisiId, kisiEkBilgiOlustur.EkBilgiTuruId));

            if (hataResult != null)
            {
                return new ErrorDataResult<KisiEkBilgiDto>(hataResult.Message, 403);
            }
            var ekBilgiInsert = new EkBilgi()
            {
                KisiId = kisiEkBilgiOlustur.KisiId,
                EkBilgiTuruId = kisiEkBilgiOlustur.EkBilgiTuruId,
                Deger = kisiEkBilgiOlustur.Deger
            };
            _context.EkBilgis.Add(ekBilgiInsert);
            _context.SaveChanges();
            return new SuccessDataResult<KisiEkBilgiDto>(new KisiEkBilgiDto() {Id=ekBilgiInsert.Id,KisiId=ekBilgiInsert.KisiId,EkBilgiTuruId=ekBilgiInsert.EkBilgiTuruId,Deger=ekBilgiInsert.Deger }, Messages.Added, 201);
        }

        public IResult KisiEkBilgiSil(int kisiEkBilgiId)
        {
            var findResult = _context.EkBilgis.FirstOrDefault(x => x.Id == kisiEkBilgiId && x.SilindiMi == false);
            if (findResult == null)
            {
                return new ErrorDataResult<KisiBilgiDto>(Messages.NotFounted, 404);
            }

            findResult.SilindiMi = true;
            var updatedUser = _context.Update(findResult);
            _context.SaveChanges();
            return new SuccessResult(Messages.Deleted, 200);
        }

        public IDataResult<Models.Dto.ApiResponse.ApiListResponseDto<KisiListDto>> Listele()
        {
            //Todo Filtreleme özelliği olmadığı için Son 100 kayıt eklendi. Filtre özelliği eklendiğinde silinecek.
            var orderedList = _context.Kisis.Where(x=>x.SilindiMi==false).OrderByDescending(x => x.Id).Take(100).ToList();
            var kisiListDtoListe = orderedList.Select(x => new KisiListDto()
            {
                Id = x.Id,
                Ad = x.Ad,
                Soyad = x.Soyad

            });
            var apiResponseList = new Models.Dto.ApiResponse.ApiListResponseDto<KisiListDto>()
            {
                Count = kisiListDtoListe.Count(),
                Lists = kisiListDtoListe.ToList()
            };


            return apiResponseList.Count < 1 ?
                new SuccessDataResult<Models.Dto.ApiResponse.ApiListResponseDto<KisiListDto>>(Messages.ListEmpty) :
                new SuccessDataResult<Models.Dto.ApiResponse.ApiListResponseDto<KisiListDto>>(apiResponseList);
        }

        public IDataResult<KisiDetayDto> Detay(int id)
        {
            var kisi = _context.Kisis.Include(x=>x.EkBilgis).Include(x=>x.Konum).FirstOrDefault(x => x.Id == id);
            if (kisi == null)
            {
                return new ErrorDataResult<KisiDetayDto>(Messages.NotFounted, 404);
            }
            var result = new KisiDetayDto()
            {
                Id = kisi.Id,
                Ad = kisi.Ad,
                Soyad = kisi.Soyad,
                Firma = kisi.Firma,
                KonumId = kisi.KonumId,
                KonumAd = kisi.Konum.Ad,
                EkBilgiListesi=kisi.EkBilgis.Where(x=> x.SilindiMi==false)
                    .Select(x=>new KisiEkBilgiDetayDto{Id=x.Id,
                        EkBilgiTuruId=x.EkBilgiTuruId,
                        EkBilgiTuruAd="",
                        Deger=x.Deger}).ToList()
            };

            return new SuccessDataResult<KisiDetayDto>(result);
        }
     
        public IDataResult<KonumaGoreRaporDto> KonumaGoreRehberVerileri(int raporId, int konumId)
        {
            var kisiler = _context.Kisis.Include(x=>x.EkBilgis).Include(x=>x.Konum).Where(x => x.KonumId == konumId);
           var TopKisiSayisi = kisiler.Count();
           var ToplamTelefonNoSayisi = kisiler.Sum(x =>
               x.EkBilgis.Count(y => y.SilindiMi == false && y.EkBilgiTuruId == EkBilgiTuruTypes.Telefon));
           var result =new KonumaGoreRaporDto() {
                RaporId=raporId,
                TopKisiSayisi= TopKisiSayisi,
                ToplamTelefonNoSayisi= ToplamTelefonNoSayisi
            };
            return new SuccessDataResult<KonumaGoreRaporDto>(result);
        }


        #region Check

        private IResult AdSoyadVarMi(string Ad, string Soyad)
        {

            var result = _context.Kisis.Any(x => x.Ad == Ad && x.Soyad == Soyad &&x.SilindiMi==false);
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists, 403);
            }

            return new SuccessResult();
        }

        private IResult BilgiTuruVarMi (int kisiId, int EkBilgiTuruId)
        {

            var result = _context.EkBilgis.Any(x => x.KisiId == kisiId && x.EkBilgiTuruId == EkBilgiTuruId && x.SilindiMi==false);
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists, 403);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
