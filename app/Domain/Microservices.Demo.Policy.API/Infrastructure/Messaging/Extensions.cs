﻿using Microservices.Demo.Policy.API.Infrastructure.Messaging.RabbitMq.Outbox;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.DependencyInjection.ServiceCollection;
using RawRabbit.Instantiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Messaging
{
    public static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddRawRabbit(new RawRabbitOptions
            {
                ClientConfiguration = new RawRabbit.Configuration.RawRabbitConfiguration
                {
                    Username = "guest",
                    Password = "guest",
                    VirtualHost = "/",
                    Port = 5672,
                    Hostnames = new List<string> { "localhost" },
                    RequestTimeout = TimeSpan.FromSeconds(10),
                    PublishConfirmTimeout = TimeSpan.FromSeconds(1),
                    RecoveryInterval = TimeSpan.FromSeconds(1),
                    PersistentDeliveryMode = true,
                    AutoCloseConnection = true,
                    AutomaticRecovery = true,
                    TopologyRecovery = true,
                    Exchange = new RawRabbit.Configuration.GeneralExchangeConfiguration
                    {
                        Durable = true,
                        AutoDelete = false,
                        Type = RawRabbit.Configuration.Exchange.ExchangeType.Topic
                    },
                    Queue = new RawRabbit.Configuration.GeneralQueueConfiguration
                    {
                        Durable = true,
                        AutoDelete = false,
                        Exclusive = false
                    }
                }
            });

            services.AddScoped<IEventPublisher, OutboxEventPublisher>();
            services.AddSingleton<Outbox>();
            services.AddHostedService<OutboxSendingService>();
            return services;
        }
    }
}
