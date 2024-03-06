using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public int Id { get; private set; }
        [JsonProperty]
        public DateTime CreatedDate { get; private set; }
        public IntegrationEvent()
        {
            Id = 0;
            CreatedDate = DateTime.Now;
        }
        [JsonConstructor]
        public IntegrationEvent(int id, DateTime createdDate)
        {
            Id = id;
            CreatedDate = createdDate;
        }
    }
}
