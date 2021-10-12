using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract;
using RiseTechnologyAssessment.Services.Rapor.API.Business.Abstract.ServiceAdapter;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Dto.MassTransit;

namespace RiseTechnologyAssessment.Services.Rapor.API.MassTransit.Cosumers
{

    public class RaporConsumer : IConsumer<RaporMessageDto>
    {
        readonly ILogger<RaporConsumer> _logger;
        readonly IRehberServiceAdapter _rehberServiceAdapter;
        readonly IRaporService _raporService;
        public RaporConsumer(ILogger<RaporConsumer> logger,
            IRehberServiceAdapter rehberServiceAdapter,
            IRaporService raporService)
        {
            _logger = logger;
            _rehberServiceAdapter = rehberServiceAdapter;
            _raporService = raporService;
        }

        public async Task Consume(ConsumeContext<RaporMessageDto> context)
        {
            _logger.LogInformation("KonumId: {Id}", context.Message.KonumId +" olarak başarılı bir şekildi geldi.");

            var konumaGoreRaporDto = _rehberServiceAdapter.KonumaGoreRapor(context.Message.RaporId, context.Message.KonumId);
            _raporService.RaporOlustur(konumaGoreRaporDto.Result);
        }
    }
}
