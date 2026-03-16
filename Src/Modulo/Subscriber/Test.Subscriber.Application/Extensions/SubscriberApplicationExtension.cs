

using Microsoft.Extensions.DependencyInjection;
using Test.Subscriber.Application.Mappers;

namespace Test.Subscriber.Application.Extensions
{
    public static class SubscriberApplicationExtension
    {
        public static IServiceCollection AddSubscriberApplication(this IServiceCollection services)
        {
                services.AddMapper();
                SubscriberMapper.RegisterMapper();


            return services;
        }

    }
}
