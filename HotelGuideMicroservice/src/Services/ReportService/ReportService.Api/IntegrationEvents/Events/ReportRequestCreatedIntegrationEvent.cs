using EventBus.Base.Events;

namespace ReportService.Api.IntegrationEvents.Events
{
    public class ReportRequestCreatedIntegrationEvent:IntegrationEvent
    {
        public Guid UUID { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; }
        public ReportRequestCreatedIntegrationEvent()
        {
            
        }
        public ReportRequestCreatedIntegrationEvent(Guid uuid, DateTime requestedDate, string status)
        {
            UUID = uuid;
            RequestedDate = requestedDate;
            Status = status;
        }

    }
}
