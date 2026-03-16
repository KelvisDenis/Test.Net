using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Subscriber.Application.ValueObjects.Request
{
    public record SubscriberUpdate([property: JsonIgnore] Guid Id, string Name, string Email, Guid PlanId);

}
