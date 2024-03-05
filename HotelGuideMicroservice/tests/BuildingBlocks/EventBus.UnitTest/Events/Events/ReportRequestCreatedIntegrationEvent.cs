﻿using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.UnitTest.Events.Events
{
    public class ReportRequestCreatedIntegrationEvent:IntegrationEvent
    {
        public int Id { get; set; }

        public ReportRequestCreatedIntegrationEvent(int id)
        {
            Id = id;
        }
    }
}
