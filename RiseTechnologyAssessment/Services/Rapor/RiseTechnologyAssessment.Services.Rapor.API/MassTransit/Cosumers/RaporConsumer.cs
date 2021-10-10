using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using RiseTechnologyAssessment.Services.Rapor.API.MassTransit.Dto;

namespace RiseTechnologyAssessment.Services.Rapor.API.MassTransit.Cosumers
{ 
    
    public class RaporConsumer : IConsumer<RaporMessage>
    {

        ILogger<RaporConsumer> _logger;
        public RaporConsumer(ILogger<RaporConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RaporMessage> context)
        {
            _logger.LogInformation("Value: {Id}", context.Message.Id);
            //Todo Rehber uygulamasının KonumaGöreKişiler Endpointine request at
            //Todo Update edilecek talep bul ve verileri güncelle
        }
    }
}
