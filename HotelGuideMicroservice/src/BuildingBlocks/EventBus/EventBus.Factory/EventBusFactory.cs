﻿using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Factory
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            //switch (config.EventBusType)
            //{
            //    case EventBusType.RabbitMQ:
            //        return new EventBusRabbitMQ(config, serviceProvider);
            //    //case EventBusType.Azure
            //    //..
            //    default:
            //        return new EventBusRabbitMQ(config, serviceProvider);
            //}

            return new EventBusRabbitMQ(config, serviceProvider);


        }
    }
}
