using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.IntegrationEvents.Events
{
    public class ReportRequestCreatedIntegrationEvent : IntegrationEvent
    {
        public int UUID { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; }
        public ReportRequestCreatedIntegrationEvent()
        {

        }
        public ReportRequestCreatedIntegrationEvent(int uuid, DateTime requestedDate, string status)
        {
            UUID = uuid;
            RequestedDate = requestedDate;
            Status = status;


        }


    }
}
