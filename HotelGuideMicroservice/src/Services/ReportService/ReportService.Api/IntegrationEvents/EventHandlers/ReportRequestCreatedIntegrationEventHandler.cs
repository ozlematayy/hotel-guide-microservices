using EventBus.Base.Abstraction;
using ReportService.Api.IntegrationEvents.Events;

namespace ReportService.Api.IntegrationEvents.EventHandlers
{
    public class ReportRequestCreatedIntegrationEventHandler : IIntegrationEventHandler<ReportRequestCreatedIntegrationEvent>
    {
        private readonly IConfiguration _configuration;
        private readonly IEventBus _eventBus;
        private readonly ILogger<ReportRequestCreatedIntegrationEventHandler> _logger;

        public ReportRequestCreatedIntegrationEventHandler(IConfiguration configuration, IEventBus eventBus, ILogger<ReportRequestCreatedIntegrationEventHandler> logger)
        {
            _configuration = configuration;
            _eventBus = eventBus;
            _logger = logger;
        }

        public Task Handle(ReportRequestCreatedIntegrationEvent @event)
        {
            try
            {
                if (@event.Status.Equals("Hazırlanıyor", StringComparison.OrdinalIgnoreCase))
                {
                    // report preparation....

                    _logger.LogInformation($"Rapor talebi alındı - UUID: {@event.UUID}, Konum: {@event.Status}");

                    @event.Status = "Tamamlandı";

                    var preparedEvent = new ReportRequestCreatedIntegrationEvent
                    {
                        UUID = @event.UUID,
                        RequestedDate = @event.RequestedDate,
                        Status = @event.Status
                    };
                    _eventBus.Publish(preparedEvent);
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Rapor talebi işlenirken bir hata oluştu - UUID: {@event.UUID}, Hata: {ex.Message}");
                throw;
            }
        }
    }
}
