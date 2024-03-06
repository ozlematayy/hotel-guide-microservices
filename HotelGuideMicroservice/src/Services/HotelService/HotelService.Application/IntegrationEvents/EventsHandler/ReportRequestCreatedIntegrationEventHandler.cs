using EventBus.Base.Abstraction;
using HotelService.Application.Features.Queries.Report.GenerateReportQuery;
using HotelService.Application.IntegrationEvents.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.IntegrationEvents.EventsHandler
{
    public class ReportRequestCreatedIntegrationEventHandler : IIntegrationEventHandler<ReportRequestCreatedIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<ReportRequestCreatedIntegrationEventHandler> _logger;

        public ReportRequestCreatedIntegrationEventHandler(IEventBus eventBus, ILogger<ReportRequestCreatedIntegrationEventHandler> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }


        public async Task Handle(ReportRequestCreatedIntegrationEvent @event)
        {

            try
            {
                if (@event.Status.Equals("Preparing", StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogInformation($"Rapor talebi alındı - UUID: {@event.UUID}, Konum: {@event.Status}");

                    //

                    @event.Status = "Done";

                    var preparedEvent = new ReportRequestCreatedIntegrationEvent
                    {
                        UUID = @event.UUID,
                        RequestedDate = @event.RequestedDate,
                        Status = @event.Status
                    };
                    _eventBus.Publish(preparedEvent);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Rapor talebi işlenirken bir hata oluştu - UUID: {@event.UUID}, Hata: {ex.Message}");
                throw;
            }
        }
    }
}
