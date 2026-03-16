using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Subscriber.Application.ValueObjects.Request
{
    public record SubscriberCreated(string Name, string Email, Guid PlanId);
}
