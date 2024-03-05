using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using EventBus.UnitTest.Events.EventHandlers;
using EventBus.UnitTest.Events.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventBus.UnitTest
{
    public class EventBusTests
    {

        private ServiceCollection services;

        public EventBusTests()
        {
            services = new ServiceCollection();
            services.AddLogging(configure => configure.AddConsole());
        }

        
        [Fact]
        public void subscribe_event_on_rabbitmq_test()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);
            });


            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();
           
            eventBus.Subscribe<ReportRequestCreatedIntegrationEvent, ReportRequestCreatedIntegrationEventHandler>();
            eventBus.UnSubscribe<ReportRequestCreatedIntegrationEvent, ReportRequestCreatedIntegrationEventHandler>();

        }
        private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "HotelGuideTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = "IntegrationEvent",
            };
        }
        [Fact]
        public void send_message_to_rabbitmq_test()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);
            });

            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Publish(new ReportRequestCreatedIntegrationEvent(1));
        }
        [Fact]
        public void consume_reportrequestcreated_from_rabbitmq_test()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);
            });

            var sp = services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ReportRequestCreatedIntegrationEvent, ReportRequestCreatedIntegrationEventHandler>();


        }
    }
}