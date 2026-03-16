using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Subscriber.Application.ValueObjects.Response;

namespace Test.Subscriber.Application.Mappers
{
    public static class SubscriberMapper
    {
        public static void RegisterMapper()
        {
            RegisterResponse();
        }

        private static void RegisterResponse()
        {
            TypeAdapterConfig<Core.Entitites.Subscriber, ActiveSubscriberResponse>
            .NewConfig()
            .Map(dest => dest.PlanName, src => src.SubscriptionPlan!.Name)
            .Map(dest => dest.SubscriptionStartDate, src => src.SubscriptionStartDate);
        }
    }
}
