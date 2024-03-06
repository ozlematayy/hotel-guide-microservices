using AutoMapper;
using EventBus.Base.Abstraction;
using HotelService.Application.IntegrationEvents.Events;
using HotelService.Domain.DTOs;
using HotelService.Domain.Models;
using HotelService.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Features.Queries.Report.GenerateReportQuery
{
    public class GenerateReportQueryHandler : IRequestHandler<GenerateReportQuery>
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<GenerateReportQueryHandler> _logger;
        private readonly IContactRepository _contactRepository;

        public GenerateReportQueryHandler(IEventBus eventBus, ILogger<GenerateReportQueryHandler> logger,IContactRepository contactRepository)
        {
            _eventBus = eventBus;
            _logger = logger;
            _contactRepository = contactRepository;
        }

        public async Task Handle(GenerateReportQuery request, CancellationToken cancellationToken)
        {
            try
            {

                //konumları al:
                var locations = await _contactRepository.GetDistinctLocationsAsync();

                //konumlardaki otel sayısını bul:
                var locationStatistics = new List<LocationStatisticDTO>();

                foreach (var location in locations)
                {
                    var hotelIdsInLocation = await _contactRepository.GetHotelIdsByLocationAsync(location);
                    var hotelsInLocation = hotelIdsInLocation.Count;
                    var numberOfContactPhone = await _contactRepository.GetPhoneNumberCountByLocationAsync(location);

                    locationStatistics.Add(new LocationStatisticDTO
                    {
                        Location = location,
                        HotelCount = hotelsInLocation,
                        NumberCount = numberOfContactPhone
                    });
                }
                // Raporu oluştur
                var reports = locationStatistics.Select(statistic => new ReportDTO
                {
                    Location = statistic.Location,
                    HotelCount = statistic.HotelCount,
                    NumberCount = statistic.NumberCount,
                    RequestedDate = DateTime.Now,
                    Status = "Done"
                }).ToList();
                //
                //


                
                var reportRequestEvent = new ReportRequestCreatedIntegrationEvent(0, DateTime.Now, "Preparing");
                _eventBus.Publish(reportRequestEvent);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while generating report request: {ex.Message}");
                throw;
            }
        }
    }
}
